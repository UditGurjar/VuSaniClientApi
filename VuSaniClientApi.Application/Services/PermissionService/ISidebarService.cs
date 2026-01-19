using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.PermissionService
{
    public interface ISidebarService
    {
        Task<List<SidebarModuleDto>> GetSidebarAsync(int userId);

    }
}
