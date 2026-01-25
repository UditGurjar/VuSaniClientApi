using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuSaniClientApi.Application.Services.MasterDataService;

namespace VuSaniClientApi.Controllers
{
    [Route("api/master-data")]
    [ApiController]
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
    }
}

