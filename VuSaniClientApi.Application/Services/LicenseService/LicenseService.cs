using System;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.LicenseRepository;

namespace VuSaniClientApi.Application.Services.LicenseService
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licenseRepository;

        public LicenseService(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }

        public async Task<object> GetLicensesAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            try
            {
                return await _licenseRepository.GetLicensesAsync(page, pageSize, all, search, filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

