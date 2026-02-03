using System.Collections.Generic;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.SoftwareAccessService
{
    public interface ISoftwareAccessService
    {
        Task<bool> UpdateSoftwareAccessAsync(UpdateSoftwareAccessDto dto);
        Task<List<SidebarModuleDto>> GetPermissionAsync(int? id, int? roleId, int? organizationId);
    }
}
