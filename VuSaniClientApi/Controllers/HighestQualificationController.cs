using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuSaniClientApi.Application.Services.HighestQualificationService;
using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighestQualificationController : ControllerBase
    {
        private readonly IHighestQualificationService _highestQualificationService;

        public HighestQualificationController(IHighestQualificationService highestQualificationService)
        {
            _highestQualificationService = highestQualificationService;
        }

        [Authorize]
        [HttpGet("get-highest-qualification")]
        [SideBarPermissionAttributeTest("view", 340, "highest_qualification")]
        public async Task<IActionResult> GetHighestQualifications(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string? search = null,
            string? filter = null)
        {
            var result = await _highestQualificationService.GetHighestQualificationsAsync(page, pageSize, all, search, filter);
            return Ok(result);
        }
    }
}

