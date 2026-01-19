using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VuSaniClientApi.Application.Services.RoleService;
using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("get-roles")]
        [SidebarPermission("view", 7, "roles")]
        public async Task<IActionResult> GetRoles(
        int page = 1,
        int pageSize = 10,
        bool all = false,
        string search = "",
        string filter = "")
        {
            var result = await _roleService.GetRolesAsync(page, pageSize, all, search, filter);

            return Ok(new
            {
                status = true,
                data = result
            });
        }
    }
}
