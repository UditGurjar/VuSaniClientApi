using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.MasterDataRepository
{
    public interface IMasterDataRepository
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
        Task<object> GetReasonForInactiveAsync(int page, int pageSize, bool all, string search, string filter);
        Task<object> GetReasonForInactiveByIdAsync(int id);
    }
}

