using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
            try { 
            var result = await _roleService.GetRolesAsync(page, pageSize, all, search, filter);
            return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("get-roles/{id}")]
        [SideBarPermissionAttributeTest("view", 7, "roles")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try { 
            var result = await _roleService.GetRoleByIdAsync(id);
            return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("create-update-role")]
        //[SideBarPermissionAttributeTest("create", 7, "roles", "organization")]
        [SideBarPermissionAttributeTest("create-update", 7, "roles", "organization")]

        public async Task<IActionResult> CreateUpdateRole([FromBody] CreateUpdateRoleRequest request)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = GetUserId();
            if (!userId.HasValue)
            {
                return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
            }

            var result = await _roleService.CreateUpdateRoleAsync(request, userId.Value);
            return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("delete-roles/{id}")]
        [SideBarPermissionAttributeTest("delete", 7, "roles", "organization")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try { 
            var userId = GetUserId();
            if (!userId.HasValue)
            {
                return Unauthorized(new { status = false, message = "Unauthorized: Invalid session" });
            }

            var result = await _roleService.DeleteRoleAsync(id, userId.Value);
            return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
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
