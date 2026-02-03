using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VuSaniClientApi.Application.Services.SoftwareAccessRequestService;
using VuSaniClientApi.Application.Services.SoftwareAccessService;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Controllers
{
    [Route("api/SoftwareAccessRequest")]
    [ApiController]
    [Authorize]
    public class SoftwareAccessRequestController : ControllerBase
    {
        private readonly ISoftwareAccessRequestService _service;
        private readonly ISoftwareAccessService _permissionService;

        public SoftwareAccessRequestController(ISoftwareAccessRequestService service, ISoftwareAccessService permissionService)
        {
            _service = service;
            _permissionService = permissionService;
        }

        private int? GetUserId()
        {
            var userId = User.FindFirst("sessionid")?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userId, out var id) ? id : null;
        }

        /// <summary>Get list of software access requests (or single by id).</summary>
        [HttpGet("get-software-access-request")]
        public async Task<IActionResult> GetSoftwareAccessRequest(
            [FromQuery] int? id,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool all = false,
            [FromQuery] bool grouped = false,
            [FromQuery] string? search = null,
            [FromQuery] string? filter = null)
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return Unauthorized(new { status = false, message = "Unauthorized" });
            var (data, total) = await _service.GetAsync(id, page, pageSize, all, search, filter, userId.Value);
            return Ok(new { status = true, data, totalRecord = total });
        }

        [HttpGet("get-software-access-request/{id}")]
        public async Task<IActionResult> GetSoftwareAccessRequestById([FromRoute] int id, [FromQuery] bool grouped = false)
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return Unauthorized(new { status = false, message = "Unauthorized" });
            var (data, total) = await _service.GetAsync(id, 1, 1, false, null, null, userId.Value);
            if (data is System.Collections.IList list && list.Count == 0)
                return NotFound(new { status = false, message = "Not found" });
            return Ok(new { status = true, data = new[] { data }, totalRecord = total });
        }

        /// <summary>Create or update a software access request.</summary>
        [HttpPost("create-update-software-access-request")]
        public async Task<IActionResult> CreateUpdateSoftwareAccessRequest([FromBody] CreateUpdateSoftwareAccessRequestDto dto)
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return Unauthorized(new { status = false, message = "Unauthorized" });
            await _service.CreateUpdateAsync(dto, userId.Value);
            var status = dto.Id.HasValue ? "Updated" : "Created";
            return Ok(new { status = true, message = $"Record {status} Successfully" });
        }

        /// <summary>Delete a software access request (soft delete).</summary>
        [HttpDelete("delete-software-access-request/{id}")]
        public async Task<IActionResult> DeleteSoftwareAccessRequest(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok)
                return NotFound(new { status = false, message = "Not found" });
            return Ok(new { status = true, message = "Record deleted successfully" });
        }

        /// <summary>Approve or reject a software access request.</summary>
        [HttpPost("update-request-status")]
        public async Task<IActionResult> UpdateRequestStatus([FromBody] UpdateAccessRequestStatusDto dto)
        {
            var userId = GetUserId();
            if (!userId.HasValue)
                return Unauthorized(new { status = false, message = "Unauthorized" });
            await _service.UpdateStatusAsync(dto, userId.Value);
            return Ok(new { status = true, message = "Record approved Successfully" });
        }

        [HttpGet("get-permission")]
        public async Task<IActionResult> GetPermission([FromQuery] int? id, [FromQuery] int? roleId, [FromQuery] int? organizationId)
        {
            var userId = GetUserId();
            var targetId = id ?? userId;
            var data = await _permissionService.GetPermissionAsync(targetId, roleId, organizationId);
            return Ok(new { status = true, data });
        }
    }
}
