using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using VuSaniClientApi.Application.Services.AppointmentTypeService;
using VuSaniClientApi.Filters;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTypeController : ControllerBase
    {
        private readonly IAppointmentTypeService _appointmentTypeService;

        public AppointmentTypeController(IAppointmentTypeService appointmentTypeService)
        {
            _appointmentTypeService = appointmentTypeService;
        }

        /// <summary>
        /// Get all Appointment Types with pagination and search
        /// </summary>
        [Authorize]
        [HttpGet("get-appointment-type")]
        [SideBarPermissionAttributeTest("view", 96, "hse_appointment")]
        public async Task<IActionResult> GetAppointmentTypes(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "")
        {
            try
            {
                var result = await _appointmentTypeService.GetAppointmentTypesAsync(page, pageSize, all, search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Get a single Appointment Type by ID
        /// </summary>
        [Authorize]
        [HttpGet("get-appointment-type/{id}")]
        [SideBarPermissionAttributeTest("view", 96, "hse_appointment")]
        public async Task<IActionResult> GetAppointmentTypeById(int id)
        {
            try
            {
                var result = await _appointmentTypeService.GetAppointmentTypeByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Create or update an Appointment Type
        /// </summary>
        [Authorize]
        [HttpPost("create-update-appointment-type")]
        [SideBarPermissionAttributeTest("create-update", 96, "hse_appointment")]
        public async Task<IActionResult> CreateUpdateAppointmentType([FromBody] CreateUpdateAppointmentTypeRequest request)
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

                var result = await _appointmentTypeService.CreateUpdateAppointmentTypeAsync(request, userId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Delete an Appointment Type (soft delete)
        /// </summary>
        [Authorize]
        [HttpDelete("delete-appointment-type/{id}")]
        [SideBarPermissionAttributeTest("delete", 96, "hse_appointment")]
        public async Task<IActionResult> DeleteAppointmentType(int id)
        {
            try
            {
                var userId = GetUserId();
                if (!userId.HasValue)
                {
                    return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
                }

                var result = await _appointmentTypeService.DeleteAppointmentTypeAsync(id, userId.Value);
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
