using System.Threading.Tasks;

namespace VuSaniClientApi.Application.Services.SkillService
{
    public interface ISkillService
    {
        Task<object> GetSkillsAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

