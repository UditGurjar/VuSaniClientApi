using System;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.MasterDataRepository;

namespace VuSaniClientApi.Application.Services.MasterDataService
{
    public class MasterDataService : IMasterDataService
    {
        private readonly IMasterDataRepository _masterDataRepository;

        public MasterDataService(IMasterDataRepository masterDataRepository)
        {
            _masterDataRepository = masterDataRepository;
        }

        public async Task<object> GetCountriesAsync(bool all = true)
        {
            try
            {
                return await _masterDataRepository.GetCountriesAsync(all);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetStatesAsync(int? countryId = null, bool all = true)
        {
            try
            {
                return await _masterDataRepository.GetStatesAsync(countryId, all);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetCitiesAsync(int? stateId = null, bool all = true)
        {
            try
            {
                return await _masterDataRepository.GetCitiesAsync(stateId, all);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetGendersAsync()
        {
            try
            {
                return await _masterDataRepository.GetGendersAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetLanguagesAsync()
        {
            try
            {
                return await _masterDataRepository.GetLanguagesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetRacesAsync()
        {
            try
            {
                return await _masterDataRepository.GetRacesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetEmployeeTypesAsync()
        {
            try
            {
                return await _masterDataRepository.GetEmployeeTypesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetBanksAsync()
        {
            try
            {
                return await _masterDataRepository.GetBanksAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetRelationshipsAsync()
        {
            try
            {
                return await _masterDataRepository.GetRelationshipsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetReasonForInactiveAsync(int page = 1, int pageSize = 10, bool all = false, string search = "", string filter = "")
        {
            try
            {
                return await _masterDataRepository.GetReasonForInactiveAsync(page, pageSize, all, search, filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetReasonForInactiveByIdAsync(int id)
        {
            try
            {
                return await _masterDataRepository.GetReasonForInactiveByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

