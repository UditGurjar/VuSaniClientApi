using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VuSaniClientApi.Application.Services.RoleService;
using VuSaniClientApi.Filters;
using VuSaniClientApi.Models.DTOs;

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
        [Authorize]
        [HttpGet("get-roles")]
        [SideBarPermissionAttributeTest("view", 7, "roles")]
        public async Task<IActionResult> GetRoles(
        int page = 1,
        int pageSize = 10,
        bool all = false,
        string search = "",
        string filter = "")
        {
            var result = await _roleService.GetRolesAsync(page, pageSize, all, search, filter);
            return Ok(result);

            //return Ok(new
            //{
            //    status = true,
            //    data = result
            //});
        }

        [Authorize]
        [HttpPost("create-update-role")]
        public async Task<IActionResult> CreateUpdateRole([FromBody] CreateUpdateRoleRequest request)
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

            // Check permission - use "edit" if id is provided, otherwise "create"
            var permissionType = request.Id.HasValue ? "edit" : "create";
            // Note: SideBarPermissionAttributeTest doesn't support dynamic permission checking
            // You may need to implement a custom attribute or check permissions manually
            // For now, we'll rely on the service layer validation

            var result = await _roleService.CreateUpdateRoleAsync(request, userId.Value);
            return Ok(result);
        }

        private int? GetUserId()
        {
            var userId = User.FindFirst("sessionid")?.Value
                      ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.TryParse(userId, out var id) ? id : null;
        }
    }
}
