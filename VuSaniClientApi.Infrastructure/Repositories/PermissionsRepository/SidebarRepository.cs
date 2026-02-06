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
                .Select(x => new { x.Permission, x.RoleId, x.SpecialPermission })    
                .FirstOrDefaultAsync(); 

            if (user == null)
            {
                //Log.Warning("GetSidebarAsync: User not found for userId={UserId}", userId);
                return new List<SidebarModuleDto>();
            }

            string? permissionJson = user.Permission;
            string permissionSource = "user";

            if (string.IsNullOrEmpty(permissionJson))
            {
                permissionJson = await _context.Roles
                    .Where(x => x.Id == user.RoleId)
                    .Select(x => x.Permission)
                    .FirstOrDefaultAsync();
                permissionSource = "role";
            }

            //Serilog.Log.Information("GetSidebarAsync: userId={UserId}, roleId={RoleId}, specialPermission={SpecialPermission}, source={Source}, permissionJson={Json}",
                //userId, user.RoleId, user.SpecialPermission, permissionSource, permissionJson ?? "(null)");

            var permissions = string.IsNullOrEmpty(permissionJson)
                ? new List<SidebarPermissionDto>()
                : JsonSerializer.Deserialize<List<SidebarPermissionDto>>(permissionJson,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            //Serilog.Log.Information("GetSidebarAsync: Deserialized {Count} permission entries", permissions?.Count ?? 0);

            return await GetModulesAsync(permissions ?? new(), 0);
        }

        public async Task<List<SidebarModuleDto>> GetSidebarForPermissionAsync(int? userId, int? roleId, int? organizationId)
        {
            string? permissionJson = null;
            if (roleId.HasValue)
            {
                permissionJson = await _context.Roles
                    .Where(x => x.Id == roleId.Value)
                    .Select(x => x.Permission)
                    .FirstOrDefaultAsync();
            }
            else if (userId.HasValue)
            {
                var user = await _context.Users
                    .Where(x => x.Id == userId.Value)
                    .Select(x => new { x.Permission, x.MyOrganization })
                    .FirstOrDefaultAsync();
                if (user == null) return new List<SidebarModuleDto>();
                permissionJson = user.Permission;
            }

            var permissions = string.IsNullOrEmpty(permissionJson)
                ? new List<SidebarPermissionDto>()
                : JsonSerializer.Deserialize<List<SidebarPermissionDto>>(permissionJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SidebarPermissionDto>();

            return await GetModulesForPermissionAsync(permissions, 0, organizationId);
        }

        private async Task<List<SidebarModuleDto>> GetModulesForPermissionAsync(
            List<SidebarPermissionDto> permissions, int parentId, int? organizationId)
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
                    Type = x.Type.ToString()
                })
                .ToListAsync();

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

                var modulePermission = permissions.FirstOrDefault(p => p.SidebarId == module.Id);
                if (modulePermission != null && organizationId.HasValue && modulePermission.Permissions.TryGetValue(organizationId.Value.ToString(), out var actions))
                    module.Permissions = new Dictionary<string, PermissionActions> { { organizationId.Value.ToString(), actions } };
                else if (modulePermission != null)
                    module.Permissions = modulePermission.Permissions;
                else if (organizationId.HasValue)
                    module.Permissions = new Dictionary<string, PermissionActions>
                    {
                        { organizationId.Value.ToString(), new PermissionActions { View = false, Edit = false, Delete = false, Create = false } }
                    };
                else
                    module.Permissions = new Dictionary<string, PermissionActions>();

                module.Submodules = await GetModulesForPermissionAsync(permissions, module.Id, organizationId);
            }

            return modules;
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
