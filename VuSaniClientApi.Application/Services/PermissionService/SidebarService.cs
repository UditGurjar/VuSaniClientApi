using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.Repositories.PermissionsRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.PermissionService
{
    public class SidebarService : ISidebarService
    {
        private readonly ISidebarRepository _sidebarRepository;
        public SidebarService(ISidebarRepository sidebarRepository)
        {
                _sidebarRepository = sidebarRepository;
        }
        public async Task<List<SidebarModuleDto>> GetSidebarAsync(int userId)
        {
            try
            {
               return await _sidebarRepository.GetSidebarAsync(userId);
            }
            catch (Exception)
            {

                throw;
            }     
        }
    }
}
