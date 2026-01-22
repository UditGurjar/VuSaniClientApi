using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.OrganizationRepository;

namespace VuSaniClientApi.Application.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
        public async Task<object> GetUsersOrganizationAsync(
           int page,
           int pageSize,
           bool all,
           string? search,
           int? userId
       )
        {
            try
            {
                return await _organizationRepository.GetUsersOrganizationAsync(page, pageSize, all, search,userId);
            }
            catch (Exception)
            {

                throw;
            }     
        }
    }
}
