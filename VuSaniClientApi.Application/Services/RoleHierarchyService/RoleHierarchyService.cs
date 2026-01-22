using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.RoleHierarchyRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.RoleHierarchyService
{
    public class RoleHierarchyService : IRoleHierarchyService
    {
        private readonly IRoleHierarchyRepository _roleHierarchyRepository;
        public RoleHierarchyService(IRoleHierarchyRepository roleHierarchyRepository)
        {
            _roleHierarchyRepository = roleHierarchyRepository;
            
        }
        public async Task<(List<RoleHierarchyListDto> Data, int Total)> GetRoleHierarchyAsync(int page, int pageSize, bool all, string? search, List<int>? allowedOrgIds)
        {
            try
            {
                return await  _roleHierarchyRepository.GetRoleHierarchyAsync(page, pageSize, all, search, allowedOrgIds);
            }
            catch (Exception)
            {

                throw;
            }        }
    }
}
