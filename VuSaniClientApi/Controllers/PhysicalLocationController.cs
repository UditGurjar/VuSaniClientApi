using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using VuSaniClientApi.Application.Services.LocationService;
using VuSaniClientApi.Filters;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalLocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public PhysicalLocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Get all Physical Locations with pagination, search, and filter
        /// </summary>
        [Authorize]
        [HttpGet("get-physical-location")]
        [SideBarPermissionAttributeTest("view", 96, "hse_appointment")]
        public async Task<IActionResult> GetLocations(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "",
            string filter = "")
        {
            try
            {
                var result = await _locationService.GetLocationsAsync(page, pageSize, all, search, filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Get a single Physical Location by ID
        /// </summary>
        [Authorize]
        [HttpGet("get-physical-location/{id}")]
        [SideBarPermissionAttributeTest("view", 96, "hse_appointment")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            try
            {
                var result = await _locationService.GetLocationByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Create or update a Physical Location
        /// </summary>
        [Authorize]
        [HttpPost("create-update-physical-location")]
        [SideBarPermissionAttributeTest("create-update", 96, "hse_appointment", "organization")]
        public async Task<IActionResult> CreateUpdateLocation([FromBody] CreateUpdateLocationRequest request)
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

                var result = await _locationService.CreateUpdateLocationAsync(request, userId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a Physical Location (soft delete)
        /// </summary>
        [Authorize]
        [HttpDelete("delete-physical-location/{id}")]
        [SideBarPermissionAttributeTest("delete", 96, "hse_appointment", "organization")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                var userId = GetUserId();
                if (!userId.HasValue)
                {
                    return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
                }

                var result = await _locationService.DeleteLocationAsync(id, userId.Value);
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
