using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
            try { 
            
            if (dto == null)
                return BadRequest(new { status = false, message = "Invalid input" });
            
            if (dto.Permission == null || dto.Permission.Count == 0)
            {
                Log.Warning("UpdateSoftwareAccess: Permission list is null or empty!");
            }
            
            await _service.UpdateSoftwareAccessAsync(dto);
            return Ok(new { status = true, message = "Record updated successfully" });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-permission")]
        public async Task<IActionResult> GetPermission([FromQuery] int? id, [FromQuery] int? roleId, [FromQuery] int? organizationId)
        {
            try { 
            var data = await _service.GetPermissionAsync(id, roleId, organizationId);
            return Ok(new { status = true, data });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
