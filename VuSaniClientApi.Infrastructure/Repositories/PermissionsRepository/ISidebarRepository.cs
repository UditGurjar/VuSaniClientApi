using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.PermissionsRepository
{
    public interface ISidebarRepository
    {
        Task<List<SidebarModuleDto>> GetSidebarAsync(int userId);
        /// <summary>Full sidebar tree with permissions for role or user (Software Access UI). Returns all modules, not filtered by permission.</summary>
        Task<List<SidebarModuleDto>> GetSidebarForPermissionAsync(int? userId, int? roleId, int? organizationId);
    }

}
