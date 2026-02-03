using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuSaniClientApi.Application.Services.SoftwareAccessService;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Controllers
{
    [Route("api/softwareAccess")]
    [ApiController]
    [Authorize]
    public class SoftwareAccessController : ControllerBase
    {
        private readonly ISoftwareAccessService _service;

        public SoftwareAccessController(ISoftwareAccessService service)
        {
            _service = service;
        }

        [HttpPost("update-software-access")]
        public async Task<IActionResult> UpdateSoftwareAccess([FromBody] UpdateSoftwareAccessDto dto)
        {
            if (dto == null)
                return BadRequest(new { status = false, message = "Invalid input" });
            await _service.UpdateSoftwareAccessAsync(dto);
            return Ok(new { status = true, message = "Record updated successfully" });
        }

        [HttpGet("get-permission")]
        public async Task<IActionResult> GetPermission([FromQuery] int? id, [FromQuery] int? roleId, [FromQuery] int? organizationId)
        {
            var data = await _service.GetPermissionAsync(id, roleId, organizationId);
            return Ok(new { status = true, data });
        }
    }
}
