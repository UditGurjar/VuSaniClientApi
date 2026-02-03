using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VuSaniClientApi.Application.Services.EmployeeService;
using VuSaniClientApi.Filters;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _environment = environment;
        }

        /// <summary>
        /// Get all employees with pagination and search
        /// </summary>
        [Authorize]
        [HttpGet("get-employee")]
        [SideBarPermissionAttributeTest("view", 16, "users", "my_organization")]
        public async Task<IActionResult> GetEmployees(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "",
            string filter = "")
        {
            var result = await _employeeService.GetEmployeesAsync(page, pageSize, all, search, filter);
            return Ok(result);
        }

        /// <summary>
        /// Get a single employee by ID
        /// </summary>
        [Authorize]
        [HttpGet("get-employee/{id}")]
        [SideBarPermissionAttributeTest("view", 16, "users", "my_organization")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Create a new employee (supports multi-step creation)
        /// </summary>
        [Authorize]
        [HttpPost("create-employee")]
        [SideBarPermissionAttributeTest("create", 16, "users", "my_organization")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateUpdateEmployeeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();
            if (!userId.HasValue)
            {
                return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
            }

            // Validate role requirement for step 1 (Employment Information) - steps are 0-indexed
            if (request.ActiveStep == 1 && !request.Role.HasValue)
            {
                return BadRequest(new { status = false, message = "Role is required for step 1 (Employment Information)." });
            }

            var terminationValidation = ValidateEmploymentTerminationRules(request);
            if (terminationValidation != null)
                return BadRequest(new { status = false, message = terminationValidation });

            // Handle file upload for Profile
            if (request.Profile != null && request.Profile.Length > 0)
            {
                request.ProfilePath = await SaveFileAsync(request.Profile, "users");
                request.Profile = null; // Clear IFormFile after saving
            }

            var result = await _employeeService.CreateEmployeeAsync(request, userId.Value);
            return Ok(result);
        }

        /// <summary>
        /// Update an existing employee (supports multi-step updates)
        /// </summary>
        [Authorize]
        [HttpPost("update-employee")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateEmployee([FromForm] CreateUpdateEmployeeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();
            if (!userId.HasValue)
            {
                return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
            }

            // Validate role requirement for step 1 (Employment Information) - steps are 0-indexed
            if (request.ActiveStep == 1 && !request.Role.HasValue)
            {
                return BadRequest(new { status = false, message = "Role is required for step 1 (Employment Information)." });
            }

            var terminationValidation = ValidateEmploymentTerminationRules(request);
            if (terminationValidation != null)
                return BadRequest(new { status = false, message = terminationValidation });

            // Handle file upload for Profile
            if (request.Profile != null && request.Profile.Length > 0)
            {
                request.ProfilePath = await SaveFileAsync(request.Profile, "users");
                request.Profile = null; // Clear IFormFile after saving
            }

            var result = await _employeeService.UpdateEmployeeAsync(request, userId.Value);
            return Ok(result);
        }

        /// <summary>
        /// Update or remove employee credentials (give/revoke software access). Empty password = remove access.
        /// </summary>
        [Authorize]
        [HttpPost("update-credential")]
        public async Task<IActionResult> UpdateCredential([FromBody] UpdateEmployeeCredentialDto dto)
        {
            if (dto == null || dto.Id <= 0)
                return BadRequest(new { status = false, message = "Invalid input" });

            var result = await _employeeService.UpdateCredentialAsync(dto.Id, string.IsNullOrWhiteSpace(dto.Password) ? null : dto.Password);
            if (!result.Status)
                return NotFound(new { status = false, message = result.Message });
            return Ok(new { status = true, message = result.Message });
        }

        /// <summary>
        /// Get employees that have credentials (software access) - same shape as get-employee, filtered by Password not null.
        /// </summary>
        [Authorize]
        [HttpGet("auth-only")]
        public async Task<IActionResult> GetAuthOnlyEmployees(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "",
            string filter = "")
        {
            var result = await _employeeService.GetEmployeesAsync(page, pageSize, all, search, filter, authOnly: true);
            return Ok(result);
        }

        /// <summary>
        /// Delete an employee (soft delete). Same structure as Node.js: 404 User Not Found, 400 Super Admin, 200 success.
        /// </summary>
        [Authorize]
        [HttpDelete("delete-employee/{id}")]
        [SideBarPermissionAttributeTest("delete", 16, "users", "my_organization")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var userId = GetUserId();
            if (!userId.HasValue)
            {
                return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
            }

            var result = await _employeeService.DeleteEmployeeAsync(id, userId.Value);

            if (!result.Status)
            {
                if (result.Message == "User Not Found")
                    return NotFound(new { status = false, message = result.Message });
                if (result.Message == "You Can't Delete Super Admin")
                    return BadRequest(new { status = false, message = result.Message });
            }

            return Ok(new { status = result.Status, message = result.Message });
        }

        private int? GetUserId()
        {
            var userId = User.FindFirst("sessionid")?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.TryParse(userId, out var id) ? id : null;
        }

        /// <summary>
        /// Validates employment/termination business rules. Returns error message or null if valid.
        /// </summary>
        private static string? ValidateEmploymentTerminationRules(CreateUpdateEmployeeRequest request)
        {
            if (string.Equals(request.EmploymentStatus, "Inactive", StringComparison.OrdinalIgnoreCase))
            {
                if (!request.DateOfTermination.HasValue)
                    return "Date of Termination is required when Employment Status is Inactive.";
            }

            if (string.Equals(request.EmploymentStatus, "Active", StringComparison.OrdinalIgnoreCase)
                && request.DateOfTermination.HasValue
                && !request.ReasonForEmployeeBecomingInactive.HasValue)
            {
                return "Termination Reason is required when Date of Termination is provided.";
            }

            return null;
        }

        private async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                return "profile/default_profile.png";

            var uploadsFolder = Path.Combine(_environment.WebRootPath ?? _environment.ContentRootPath, "public", folder);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{DateTime.UtcNow.Ticks}{fileExtension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"{folder}/{fileName}";
        }
    }
}

