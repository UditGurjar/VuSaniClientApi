using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuSaniClientApi.Application.Services.MasterDataService;

namespace VuSaniClientApi.Controllers
{
    /// <summary>
    /// Reason For Inactive API - same route as Node.js (api/reasonForInactive) for frontend compatibility.
    /// </summary>
    [Route("api/reasonForInactive")]
    [ApiController]
    public class ReasonForInactiveController : ControllerBase
    {
        private readonly IMasterDataService _masterDataService;

        public ReasonForInactiveController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        /// <summary>
        /// Get all reason for inactive - matches Node GET /api/reasonForInactive/get-reason-for-inactive
        /// </summary>
        [Authorize]
        [HttpGet("get-reason-for-inactive")]
        public async Task<IActionResult> GetReasonForInactive(
            int page = 1,
            int pageSize = 10,
            bool grouped = false,
            bool all = false,
            string search = "",
            string filter = "")
        {
            var result = await _masterDataService.GetReasonForInactiveAsync(page, pageSize, all, search, filter);
            return Ok(result);
        }

        /// <summary>
        /// Get a single reason for inactive by id - matches Node GET /api/reasonForInactive/get-reason-for-inactive/:id
        /// </summary>
        [Authorize]
        [HttpGet("get-reason-for-inactive/{id}")]
        public async Task<IActionResult> GetReasonForInactiveById(int id, bool grouped = false)
        {
            var result = await _masterDataService.GetReasonForInactiveByIdAsync(id);
            return Ok(result);
        }
    }
}
