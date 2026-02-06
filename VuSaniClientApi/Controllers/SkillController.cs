using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuSaniClientApi.Application.Services.SkillService;
using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [Authorize]
        [HttpGet("get-skill")]
        [SideBarPermissionAttributeTest("view", 91, "skills")]
        public async Task<IActionResult> GetSkills(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string? search = null,
            string? filter = null)
        {
            try { 
            var result = await _skillService.GetSkillsAsync(page, pageSize, all, search, filter);
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

