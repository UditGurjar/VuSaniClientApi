using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using VuSaniClientApi.Application.Services.HseAppointmentService;
using VuSaniClientApi.Filters;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HseAppointmentController : ControllerBase
    {
        private readonly IHseAppointmentService _hseAppointmentService;

        public HseAppointmentController(IHseAppointmentService hseAppointmentService)
        {
            _hseAppointmentService = hseAppointmentService;
        }

        /// <summary>
        /// Get all HSE Appointments with pagination, search, and filter
        /// </summary>
        [Authorize]
        [HttpGet("get-hseAppointment")]
        [SideBarPermissionAttributeTest("view", 96, "hse_appointment")]
        public async Task<IActionResult> GetHseAppointments(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "",
            string filter = "")
        {
            try
            {
                var result = await _hseAppointmentService.GetHseAppointmentsAsync(page, pageSize, all, search, filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Get a single HSE Appointment by ID
        /// </summary>
        [Authorize]
        [HttpGet("get-hseAppointment/{id}")]
        [SideBarPermissionAttributeTest("view", 96, "hse_appointment")]
        public async Task<IActionResult> GetHseAppointmentById(int id)
        {
            try
            {
                var result = await _hseAppointmentService.GetHseAppointmentByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Create or update an HSE Appointment
        /// </summary>
        [Authorize]
        [HttpPost("create-update-hseAppointment")]
        [SideBarPermissionAttributeTest("create-update", 96, "hse_appointment", "organization")]
        public async Task<IActionResult> CreateUpdateHseAppointment([FromBody] CreateUpdateHseAppointmentRequest request)
        {
            try
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

                var result = await _hseAppointmentService.CreateUpdateHseAppointmentAsync(request, userId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Upload signature for an HSE Appointment
        /// </summary>
        [Authorize]
        [HttpPost("upload-hse-appointment-signature")]
        public async Task<IActionResult> UploadSignature([FromBody] UploadHseAppointmentSignatureRequest request)
        {
            try
            {
                var userId = GetUserId();
                if (!userId.HasValue)
                {
                    return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
                }

                var result = await _hseAppointmentService.UploadSignatureAsync(request, userId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Delete an HSE Appointment (soft delete)
        /// </summary>
        [Authorize]
        [HttpDelete("delete-hseAppointment/{id}")]
        [SideBarPermissionAttributeTest("delete", 96, "hse_appointment", "organization")]
        public async Task<IActionResult> DeleteHseAppointment(int id)
        {
            try
            {
                var userId = GetUserId();
                if (!userId.HasValue)
                {
                    return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
                }

                var result = await _hseAppointmentService.DeleteHseAppointmentAsync(id, userId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Get HSE Hierarchy chart for an organization
        /// </summary>
        [Authorize]
        [HttpGet("get-hse-appointment-chart")]
        [SideBarPermissionAttributeTest("view", 96, "hse_appointment")]
        public async Task<IActionResult> GetHseHierarchy(int organization)
        {
            try
            {
                var result = await _hseAppointmentService.GetHseHierarchyAsync(organization);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Accept or Reject an HSE Appointment (status transition)
        /// </summary>
        [Authorize]
        [HttpPost("update-status")]
        [SideBarPermissionAttributeTest("create-update", 96, "hse_appointment", "organization")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateHseAppointmentStatusRequest request)
        {
            try
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

                var result = await _hseAppointmentService.UpdateStatusAsync(request, userId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Renew an expired HSE Appointment (creates a new record)
        /// </summary>
        [Authorize]
        [HttpPost("renew")]
        [SideBarPermissionAttributeTest("create-update", 96, "hse_appointment", "organization")]
        public async Task<IActionResult> RenewAppointment([FromBody] RenewHseAppointmentRequest request)
        {
            try
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

                var result = await _hseAppointmentService.RenewAppointmentAsync(request, userId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        private int? GetUserId()
        {
            var userId = User.FindFirst("sessionid")?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.TryParse(userId, out var id) ? id : null;
        }
    }
}
