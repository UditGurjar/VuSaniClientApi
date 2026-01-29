using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.MasterDataService
{
    public interface IMasterDataService
    {
        Task<object> GetCountriesAsync(bool all = true);
        Task<object> GetStatesAsync(int? countryId = null, bool all = true);
        Task<object> GetCitiesAsync(int? stateId = null, bool all = true);
        Task<object> GetGendersAsync();
        Task<object> GetLanguagesAsync();
        Task<object> GetRacesAsync();
        Task<object> GetEmployeeTypesAsync();
        Task<object> GetBanksAsync();
        Task<object> GetRelationshipsAsync();
        Task<object> GetReasonForInactiveAsync(int page = 1, int pageSize = 10, bool all = false, string search = "", string filter = "");
        Task<object> GetReasonForInactiveByIdAsync(int id);
        Task<object> GetDisabilityAsync(int page = 1, int pageSize = 10, bool all = false, string search = "", string filter = "");
        Task<object> GetDisabilityByIdAsync(int id);
        Task<object> GetDisabilityDropdownAsync();
    }
}

