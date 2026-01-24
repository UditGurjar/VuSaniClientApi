using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.HighestQualificationRepository
{
    public interface IHighestQualificationRepository
    {
        Task<object> GetHighestQualificationsAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

