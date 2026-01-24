using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.RoleRepository
{
    public interface IRoleRepository
    {
        Task<object> GetRolesAsync(int page, int pageSize, bool all, string search, string filter);
        Task<object> GetRoleByIdAsync(int id);
        Task<object> CreateUpdateRoleAsync(CreateUpdateRoleRequest request, int userId);
    }

}
