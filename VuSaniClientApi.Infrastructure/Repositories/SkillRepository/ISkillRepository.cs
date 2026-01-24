using System.Collections.Generic;
using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.Repositories.SkillRepository
{
    public interface ISkillRepository
    {
        Task<object> GetSkillsAsync(int page, int pageSize, bool all, string? search, string? filter);
    }
}

