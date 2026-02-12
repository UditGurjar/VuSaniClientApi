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
        [SideBarPermissionAttributeTest("create-update", 96, "hseappointment", "organization")]
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
        [SideBarPermissionAttributeTest("create-update", 96, "hseappointment", "organization")]
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
        [SideBarPermissionAttributeTest("create-update", 96, "hseappointment", "organization")]
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

        // ─── Public endpoints for email-based Accept / Reject (no auth required) ───

        /// <summary>
        /// Accept an HSE Appointment via email link (GET - clicked from email button).
        /// Returns an HTML page confirming the action.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("email-accept")]
        public async Task<IActionResult> EmailAccept([FromQuery] string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return Content(BuildHtmlResponse("Invalid Link", "The action link is invalid or missing.", false), "text/html");

                var result = await _hseAppointmentService.AcceptByTokenAsync(token);

                // Extract status from anonymous object
                var statusProp = result.GetType().GetProperty("status");
                var messageProp = result.GetType().GetProperty("message");
                var success = statusProp != null && (bool)statusProp.GetValue(result)!;
                var message = messageProp?.GetValue(result)?.ToString() ?? "";

                return Content(BuildHtmlResponse(
                    success ? "Appointment Accepted" : "Action Failed",
                    message,
                    success), "text/html");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return Content(BuildHtmlResponse("Error", "An unexpected error occurred. Please try again later.", false), "text/html");
            }
        }

        /// <summary>
        /// Show rejection form when employee clicks Reject in email (GET).
        /// Returns an HTML page with a reason text field.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("email-reject")]
        public IActionResult EmailRejectForm([FromQuery] string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return Content(BuildHtmlResponse("Invalid Link", "The action link is invalid or missing.", false), "text/html");

            var apiBaseUrl = $"{Request.Scheme}://{Request.Host}";
            var html = BuildRejectFormHtml(token, apiBaseUrl);
            return Content(html, "text/html");
        }

        /// <summary>
        /// Submit rejection with reason (POST from the rejection form).
        /// </summary>
        [AllowAnonymous]
        [HttpPost("email-reject")]
        public async Task<IActionResult> EmailRejectSubmit([FromForm] string token, [FromForm] string rejectionReason)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return Content(BuildHtmlResponse("Invalid Link", "The action link is invalid or missing.", false), "text/html");

                if (string.IsNullOrWhiteSpace(rejectionReason))
                {
                    var apiBaseUrl = $"{Request.Scheme}://{Request.Host}";
                    return Content(BuildRejectFormHtml(token, apiBaseUrl, "Please provide a reason for rejection."), "text/html");
                }

                var result = await _hseAppointmentService.RejectByTokenAsync(token, rejectionReason);

                var statusProp = result.GetType().GetProperty("status");
                var messageProp = result.GetType().GetProperty("message");
                var success = statusProp != null && (bool)statusProp.GetValue(result)!;
                var message = messageProp?.GetValue(result)?.ToString() ?? "";

                return Content(BuildHtmlResponse(
                    success ? "Appointment Rejected" : "Action Failed",
                    message,
                    success), "text/html");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return Content(BuildHtmlResponse("Error", "An unexpected error occurred. Please try again later.", false), "text/html");
            }
        }

        // ─── HTML helpers for email action pages ───

        private static string BuildHtmlResponse(string title, string message, bool success)
        {
            var color = success ? "#28a745" : "#dc3545";
            var icon = success ? "&#10004;" : "&#10008;";
            return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <title>{title} - VuSani</title>
</head>
<body style='font-family: Arial, sans-serif; background: #f5f5f5; margin: 0; padding: 40px 20px;'>
    <div style='max-width: 500px; margin: 0 auto; background: white; border-radius: 12px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); padding: 40px; text-align: center;'>
        <div style='width: 60px; height: 60px; border-radius: 50%; background: {color}; color: white; font-size: 30px; line-height: 60px; margin: 0 auto 20px;'>{icon}</div>
        <h2 style='color: #333; margin: 0 0 15px;'>{title}</h2>
        <p style='color: #666; font-size: 16px; line-height: 1.5;'>{message}</p>
        <hr style='border: none; border-top: 1px solid #eee; margin: 25px 0;' />
        <p style='font-size: 12px; color: #999;'>VuSani Employee Management</p>
    </div>
</body>
</html>";
        }

        private static string BuildRejectFormHtml(string token, string apiBaseUrl, string? errorMessage = null)
        {
            var errorHtml = string.IsNullOrEmpty(errorMessage) ? "" :
                $"<div style='background: #f8d7da; color: #721c24; padding: 10px; border-radius: 6px; margin-bottom: 15px; font-size: 14px;'>{errorMessage}</div>";

            return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <title>Reject HSE Appointment - VuSani</title>
</head>
<body style='font-family: Arial, sans-serif; background: #f5f5f5; margin: 0; padding: 40px 20px;'>
    <div style='max-width: 500px; margin: 0 auto; background: white; border-radius: 12px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); padding: 40px;'>
        <div style='text-align: center; margin-bottom: 25px;'>
            <div style='width: 60px; height: 60px; border-radius: 50%; background: #ffc107; color: white; font-size: 30px; line-height: 60px; margin: 0 auto 15px;'>!</div>
            <h2 style='color: #333; margin: 0;'>Reject HSE Appointment</h2>
            <p style='color: #666; font-size: 14px;'>Please provide a reason for rejecting this appointment.</p>
        </div>
        {errorHtml}
        <form method='POST' action='{apiBaseUrl}/api/HseAppointment/email-reject'>
            <input type='hidden' name='token' value='{token}' />
            <div style='margin-bottom: 15px;'>
                <label for='rejectionReason' style='display: block; font-weight: bold; color: #333; margin-bottom: 5px;'>Reason for Rejection <span style='color: red;'>*</span></label>
                <textarea id='rejectionReason' name='rejectionReason' rows='4' required
                    style='width: 100%; padding: 10px; border: 1px solid #ddd; border-radius: 6px; font-family: Arial, sans-serif; font-size: 14px; resize: vertical; box-sizing: border-box;'
                    placeholder='Enter your reason for rejecting this appointment...'></textarea>
            </div>
            <button type='submit'
                style='width: 100%; padding: 12px; background: #dc3545; color: white; border: none; border-radius: 6px; font-size: 16px; cursor: pointer; font-weight: bold;'>
                Submit Rejection
            </button>
        </form>
        <hr style='border: none; border-top: 1px solid #eee; margin: 25px 0;' />
        <p style='font-size: 12px; color: #999; text-align: center;'>VuSani Employee Management</p>
    </div>
</body>
</html>";
        }

        private int? GetUserId()
        {
            var userId = User.FindFirst("sessionid")?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.TryParse(userId, out var id) ? id : null;
        }
    }
}
