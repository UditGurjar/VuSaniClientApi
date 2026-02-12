using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.LocationRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<object> GetLocationsAsync(int page, int pageSize, bool all, string search, string filter)
        {
            return await _locationRepository.GetLocationsAsync(page, pageSize, all, search, filter);
        }

        public async Task<object> GetLocationByIdAsync(int id)
        {
            return await _locationRepository.GetLocationByIdAsync(id);
        }

        public async Task<object> CreateUpdateLocationAsync(CreateUpdateLocationRequest request, int userId)
        {
            return await _locationRepository.CreateUpdateLocationAsync(request, userId);
        }

        public async Task<object> DeleteLocationAsync(int id, int userId)
        {
            return await _locationRepository.DeleteLocationAsync(id, userId);
        }
    }
}
