using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.HighestQualificationService
{
    public interface IHighestQualificationService
    {
        Task<object> GetHighestQualificationsAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

