using System;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.SkillRepository;

namespace VuSaniClientApi.Application.Services.SkillService
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<object> GetSkillsAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            try
            {
                return await _skillRepository.GetSkillsAsync(page, pageSize, all, search, filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

