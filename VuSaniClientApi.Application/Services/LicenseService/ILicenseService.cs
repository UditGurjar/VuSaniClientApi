using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.LicenseService
{
    public interface ILicenseService
    {
        Task<object> GetLicensesAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

