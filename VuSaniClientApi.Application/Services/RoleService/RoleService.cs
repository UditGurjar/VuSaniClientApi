using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.RoleRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<object> GetRolesAsync(int page, int pageSize, bool all, string search, string filter)
        {
            try
            {
                return await _roleRepository.GetRolesAsync(page, pageSize, all, search, filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> CreateUpdateRoleAsync(CreateUpdateRoleRequest request, int userId)
        {
            try
            {
                return await _roleRepository.CreateUpdateRoleAsync(request, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
