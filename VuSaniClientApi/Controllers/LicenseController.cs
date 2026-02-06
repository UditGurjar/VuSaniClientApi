using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VuSaniClientApi.Application.Services.LicenseService;
using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenseService _licenseService;

        public LicenseController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [Authorize]
        [HttpGet("get-license")]
        [SideBarPermissionAttributeTest("view", 136, "license")]
        public async Task<IActionResult> GetLicenses(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string? search = null,
            string? filter = null)
        {
            try { 
            var result = await _licenseService.GetLicensesAsync(page, pageSize, all, search, filter);
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

