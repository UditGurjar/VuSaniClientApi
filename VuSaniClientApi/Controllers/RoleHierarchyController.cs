using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuSaniClientApi.Application.Services.RoleHierarchyService;
using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleHierarchyController : ControllerBase
    {
        private readonly IRoleHierarchyService _roleHierarchyService;
        public RoleHierarchyController(IRoleHierarchyService roleHierarchyService)
        {
            _roleHierarchyService= roleHierarchyService;
        }
        [Authorize]
        [HttpGet("get-role-hierarchy")]
        [SideBarPermissionAttributeTest("view", 339, "rolehierarchy")]
        public async Task<IActionResult> GetRoleHierarchy(
               int page = 1, int pageSize = 10, bool all = false, string? search = null)
        {
            try { 
            var allowedOrgs = HttpContext.Items["additionalData"] as List<string>;
            var orgIds = allowedOrgs?.Select(int.Parse).ToList();

            var (data, total) = await _roleHierarchyService.GetRoleHierarchyAsync(
                page, pageSize, all, search, orgIds
            );

            return Ok(new
            {
                status = true,
                data,
                total
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
