using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Infrastructure.Repositories.PermissionsRepository;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Application.Services.SoftwareAccessService
{
    public class SoftwareAccessService : ISoftwareAccessService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISidebarRepository _sidebarRepository;

        public SoftwareAccessService(ApplicationDbContext context, ISidebarRepository sidebarRepository)
        {
            _context = context;
            _sidebarRepository = sidebarRepository;
        }

        public async Task<bool> UpdateSoftwareAccessAsync(UpdateSoftwareAccessDto dto)
        {
            var permissionJson = JsonSerializer.Serialize(dto.Permission ?? new List<SidebarPermissionDto>());

            if (dto.Type?.ToLowerInvariant() == "role")
            {
                var role = await _context.Roles.FindAsync(dto.Id);
                if (role != null)
                {
                    role.Permission = permissionJson;
                    await _context.SaveChangesAsync();
                }

                var usersToUpdate = await _context.Users
                    .Where(u => u.MyOrganization == dto.OrganizationId && u.RoleId == dto.Id && u.SpecialPermission == 0)
                    .ToListAsync();
                foreach (var u in usersToUpdate)
                {
                    u.OrganizationAccess = dto.Organizations;
                    u.Permission = permissionJson;
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                var user = await _context.Users.FindAsync(dto.Id);
                if (user != null)
                {
                    user.OrganizationAccess = dto.Organizations;
                    user.SpecialPermission = 1;
                    user.Permission = permissionJson;
                    await _context.SaveChangesAsync();
                }
            }

            return true;
        }

        public async Task<List<SidebarModuleDto>> GetPermissionAsync(int? id, int? roleId, int? organizationId)
        {
            return await _sidebarRepository.GetSidebarForPermissionAsync(id, roleId, organizationId);
        }
    }
}
