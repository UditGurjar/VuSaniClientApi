using System;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.HighestQualificationRepository;

namespace VuSaniClientApi.Application.Services.HighestQualificationService
{
    public class HighestQualificationService : IHighestQualificationService
    {
        private readonly IHighestQualificationRepository _highestQualificationRepository;

        public HighestQualificationService(IHighestQualificationRepository highestQualificationRepository)
        {
            _highestQualificationRepository = highestQualificationRepository;
        }

        public async Task<object> GetHighestQualificationsAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            try
            {
                return await _highestQualificationRepository.GetHighestQualificationsAsync(page, pageSize, all, search, filter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

