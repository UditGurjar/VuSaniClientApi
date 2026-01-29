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
        /// Delete an employee (soft delete)
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
            return Ok(result);
        }

        private int? GetUserId()
        {
            var userId = User.FindFirst("sessionid")?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.TryParse(userId, out var id) ? id : null;
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

