using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuSaniClientApi.Application.Services.DepartmentService;
using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [Authorize]
        [HttpGet("get-departments")]
        [SideBarPermissionAttributeTest("view", 17, "department")]
        public async Task<IActionResult> GetDepartments(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string? search = null,
            string? filter = null)
        {
            try
            {
                var result = await _departmentService.GetDepartmentsAsync(page, pageSize, all, search, filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}

