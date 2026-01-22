using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.RoleHierarchyRepository
{
    public interface IRoleHierarchyRepository
    {
        Task<(List<RoleHierarchyListDto> Data, int Total)> GetRoleHierarchyAsync(
        int page,
        int pageSize,
        bool all,
        string? search,
        List<int>? allowedOrgIds
    );
    }
}
