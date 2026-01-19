using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.PermissionsRepository
{
    public class SidebarRepository : ISidebarRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SidebarRepository(ApplicationDbContext context, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _config = config;
            _httpContextAccessor=httpContextAccessor;
        }

        public async Task<List<SidebarModuleDto>> GetSidebarAsync(int userId)
        {
            var user = await _context.Users
                .Where(x => x.Id == userId)
                .Select(x => new { x.Permission, x.RoleId })    
                .FirstOrDefaultAsync();

            if (user == null) return new List<SidebarModuleDto>();

            string? permissionJson = user.Permission;

            if (permissionJson == null)
            {
                permissionJson = await _context.Roles
                    .Where(x => x.Id == user.RoleId)
                    .Select(x => x.Permission)
                    .FirstOrDefaultAsync();
            }
            var permissions = string.IsNullOrEmpty(permissionJson)
          ? new List<SidebarPermissionDto>()
          : JsonSerializer.Deserialize<List<SidebarPermissionDto>>(permissionJson,
              new JsonSerializerOptions
              {
                  PropertyNameCaseInsensitive = true
              });



            return await GetModulesAsync(permissions ?? new(), 0);
        }

        private async Task<List<SidebarModuleDto>> GetModulesAsync(
            List<SidebarPermissionDto> permissions, int parentId)
        {
            var modules = await _context.Sidebars
                .Where(x => x.ParentId == parentId && x.Deleted == false)
                .OrderBy(x => x.Sequence)
                .Select(x => new SidebarModuleDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Icon = x.Icon,
                    Path = x.Path,
                    Type = x.Type.ToString() // Fix: Convert SidebarType enum to string
                })
                .ToListAsync();

            var result = new List<SidebarModuleDto>();

            foreach (var module in modules)
            {
                if (!string.IsNullOrWhiteSpace(module.Icon))
                {
                    var request = _httpContextAccessor.HttpContext?.Request;
                    if (request != null)
                    {
                        var baseUrl = $"{request.Scheme}://{request.Host}";
                        module.Icon = $"{baseUrl}/{module.Icon.TrimStart('/')}";
                    }
                }

                var modulePermission = permissions
                    .FirstOrDefault(p => p.SidebarId == module.Id);

                module.Permissions = modulePermission?.Permissions ?? new();

                module.Submodules = await GetModulesAsync(permissions, module.Id);

                if (HasTruePermission(module))
                    result.Add(module);
            }

            return result;
        }

        private bool HasTruePermission(SidebarModuleDto module)
        {
            bool selfHasPermission =
                module.Permissions != null &&
                module.Permissions.Values.Any(p =>
                    p.View || p.Edit || p.Delete || p.Create);

            bool childHasPermission =
                module.Submodules != null &&
                module.Submodules.Any(HasTruePermission);

            return selfHasPermission || childHasPermission;
        }

    }

}
