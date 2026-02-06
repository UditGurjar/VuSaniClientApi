using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuSaniClientApi.Application.Services.MasterDataService;

using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Controllers
{
    [Route("api/master-data")]
    [ApiController]
    [Authorize]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataService _masterDataService;

        public MasterDataController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        /// <summary>
        /// Get all countries
        /// </summary>
        [Authorize]
        [HttpGet("get-countries")]
        public async Task<IActionResult> GetCountries(bool all = true)
        {
            var result = await _masterDataService.GetCountriesAsync(all);
            return Ok(result);
        }

        /// <summary>
        /// Get states/provinces by country (optional filter)
        /// </summary>
        [Authorize]
        [HttpGet("get-states")]
        public async Task<IActionResult> GetStates(int? countryId = null, bool all = true)
        {
            var result = await _masterDataService.GetStatesAsync(countryId, all);
            return Ok(result);
        }

        /// <summary>
        /// Get cities by state (optional filter)
        /// </summary>
        [Authorize]
        [HttpGet("get-cities")]
        public async Task<IActionResult> GetCities(int? stateId = null, bool all = true)
        {
            var result = await _masterDataService.GetCitiesAsync(stateId, all);
            return Ok(result);
        }

        /// <summary>
        /// Get all genders
        /// </summary>
        [Authorize]
        [HttpGet("get-genders")]
        public async Task<IActionResult> GetGenders()
        {
            var result = await _masterDataService.GetGendersAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get all languages
        /// </summary>
        [Authorize]
        [HttpGet("get-languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var result = await _masterDataService.GetLanguagesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get all races
        /// </summary>
        [Authorize]
        [HttpGet("get-races")]
        public async Task<IActionResult> GetRaces()
        {
            var result = await _masterDataService.GetRacesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get all employee types
        /// </summary>
        [Authorize]
        [HttpGet("get-employee-types")]
        public async Task<IActionResult> GetEmployeeTypes()
        {
            var result = await _masterDataService.GetEmployeeTypesAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get all banks
        /// </summary>
        [Authorize]
        [HttpGet("get-banks")]
        public async Task<IActionResult> GetBanks()
        {
            var result = await _masterDataService.GetBanksAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get all relationships (for next of kin)
        /// </summary>
        [Authorize]
        [HttpGet("get-relationships")]
        public async Task<IActionResult> GetRelationships()
        {
            var result = await _masterDataService.GetRelationshipsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get all reason for inactive (paginated, with search and filter) - matches Node get-reason-for-inactive
        /// </summary>
        [Authorize]
        [HttpGet("get-reason-for-inactive")]
       // [SideBarPermissionAttributeTest("view", 374, "reason_for_inactive")]

        public async Task<IActionResult> GetReasonForInactive(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "",
            string filter = "")
        {
            var result = await _masterDataService.GetReasonForInactiveAsync(page, pageSize, all, search, filter);
            return Ok(result);
        }

        /// <summary>
        /// Get a single reason for inactive by id - matches Node get-reason-for-inactive/:id
        /// </summary>
        [Authorize]
        [HttpGet("get-reason-for-inactive/{id}")]
        public async Task<IActionResult> GetReasonForInactiveById(int id)
        {
            var result = await _masterDataService.GetReasonForInactiveByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get disability list (paginated, with search and filter) - matches Node get-disability
        /// </summary>
        [HttpGet("get-disability")]
        [SideBarPermissionAttributeTest("view", 341, "disability")]
        public async Task<IActionResult> GetDisability(
            int page = 1,
            int pageSize = 10,
            bool all = false,
            string search = "",
            string filter = "")
        {
            var result = await _masterDataService.GetDisabilityAsync(page, pageSize, all, search, filter);
            return Ok(result);
        }

        /// <summary>
        /// Get a single disability by id - matches Node get-disability/:id
        /// </summary>
        [HttpGet("get-disability/{id}")]
        public async Task<IActionResult> GetDisabilityById(int id)
        {
            var result = await _masterDataService.GetDisabilityByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get disability dropdown (all non-deleted, id/name/parent) - matches Node get-disability-dropdown
        /// </summary>
        [HttpGet("get-disability-dropdown")]
        public async Task<IActionResult> GetDisabilityDropdown()
        {
            var result = await _masterDataService.GetDisabilityDropdownAsync();
            return Ok(result);
        }

    }
}

