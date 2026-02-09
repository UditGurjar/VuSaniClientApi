using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using VuSaniClientApi.Application.Services.ActivityLogService;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        private readonly IActivityLogService _activityLogService;

        public ActivityLogController(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }

        /// <summary>
        /// Get all activity logs with optional filters
        /// </summary>
        [Authorize]
        [HttpGet("get-activity-logs")]
        public async Task<IActionResult> GetActivityLogs(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "",
            string filter = "",
            int? userId = null)
        {
            try
            {
                var result = await _activityLogService.GetActivityLogsAsync(page, pageSize, all, search, filter, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Get activity logs for a specific user
        /// </summary>
        [Authorize]
        [HttpGet("get-user-activity-logs/{userId}")]
        public async Task<IActionResult> GetUserActivityLogs(int userId, int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await _activityLogService.GetActivityLogsByUserIdAsync(userId, page, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Get activity logs for the currently logged-in user
        /// </summary>
        [Authorize]
        [HttpGet("get-my-activity-logs")]
        public async Task<IActionResult> GetMyActivityLogs(int page = 1, int pageSize = 10)
        {
            try
            {
                var userId = GetUserId();
                if (!userId.HasValue)
                {
                    return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
                }

                var result = await _activityLogService.GetActivityLogsByUserIdAsync(userId.Value, page, pageSize);
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
