using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuSaniClientApi.Application.Services.PermissionService;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SidebarPermissionController : ControllerBase
    {
        private readonly ISidebarService _sidebarService;
        public SidebarPermissionController(ISidebarService sidebarService)
        {
          _sidebarService= sidebarService;
        }

        [HttpGet("sidebar")]
        public async Task<IActionResult> GetSidebar([FromQuery] int userId)
        {
            try
            {
                
                var result = await _sidebarService.GetSidebarAsync(userId);
                

                return Ok(new
                {
                    status = true,
                    data = result
                });

            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
