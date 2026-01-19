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
    }

}
