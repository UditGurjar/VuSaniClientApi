using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.LocationRepository
{
    public interface ILocationRepository
    {
        Task<object> GetLocationsAsync(int page, int pageSize, bool all, string search, string filter);
        Task<object> GetLocationByIdAsync(int id);
        Task<object> CreateUpdateLocationAsync(CreateUpdateLocationRequest request, int userId);
        Task<object> DeleteLocationAsync(int id, int userId);
    }
}
