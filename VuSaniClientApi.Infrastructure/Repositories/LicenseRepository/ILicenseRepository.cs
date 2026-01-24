using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.LicenseRepository
{
    public interface ILicenseRepository
    {
        Task<object> GetLicensesAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

