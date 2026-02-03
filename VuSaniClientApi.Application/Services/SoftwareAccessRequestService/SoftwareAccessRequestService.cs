using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Infrastructure.Repositories.SoftwareAccessRequestRepository;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Application.Services.SoftwareAccessRequestService
{
    public class SoftwareAccessRequestService : ISoftwareAccessRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly ISoftwareAccessRequestRepository _repository;

        public SoftwareAccessRequestService(ApplicationDbContext context, ISoftwareAccessRequestRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<(object Data, int Total)> GetAsync(int? id, int page, int pageSize, bool all, string? search, string? filter, int currentUserId)
        {
            var (data, total) = await _repository.GetAsync(id, page, pageSize, all, search, filter, currentUserId);
            if (id.HasValue && data.Count > 0)
                return (data[0], total);
            return (data, total);
        }

        public async Task<bool> CreateUpdateAsync(CreateUpdateSoftwareAccessRequestDto dto, int currentUserId)
        {
            string? uniqueId = null;
            if (!dto.Id.HasValue)
            {
                uniqueId = await GenerateUniqueIdAsync(dto.Organization, dto.Department);
            }

            if (dto.Id.HasValue)
            {
                return await _repository.UpdateAsync(dto, currentUserId);
            }

            await _repository.CreateAsync(dto, currentUserId, uniqueId);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> UpdateStatusAsync(UpdateAccessRequestStatusDto dto, int currentUserId)
        {
            if (dto.Status?.ToLowerInvariant() == "approved")
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                if (entity != null && entity.UserId.HasValue && entity.SidebarId.HasValue)
                {
                    var user = await _context.Users
                        .Where(x => x.Id == entity.UserId.Value)
                        .Select(x => new { x.OrganizationAccess, x.MyOrganization, x.Permission })
                        .FirstOrDefaultAsync();
                    if (user != null)
                    {
                        var orgList = new List<int> { user.MyOrganization ?? 0 };
                        if (!string.IsNullOrEmpty(user.OrganizationAccess))
                        {
                            try
                            {
                                var parsed = JsonSerializer.Deserialize<List<int>>(user.OrganizationAccess);
                                if (parsed != null) orgList.AddRange(parsed.Where(x => x != 0));
                            }
                            catch { }
                        }

                        var permissions = string.IsNullOrEmpty(user.Permission)
                            ? new List<SidebarPermissionDto>()
                            : JsonSerializer.Deserialize<List<SidebarPermissionDto>>(user.Permission,
                                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SidebarPermissionDto>();

                        var childIds = await _context.Sidebars.Where(x => x.ParentId == entity.SidebarId.Value).Select(x => x.Id).ToListAsync();
                        var subChildIds = await _context.Sidebars.Where(x => x.ParentId != null && childIds.Contains(x.ParentId)).Select(x => x.Id).ToListAsync();
                        var allSidebarIds = new List<int> { entity.SidebarId.Value };
                        allSidebarIds.AddRange(childIds);
                        allSidebarIds.AddRange(subChildIds);

                        var newPerms = orgList.Where(x => x != 0).Distinct().ToDictionary(orgId => orgId.ToString(), _ => new PermissionActions { View = true, Edit = true, Delete = true, Create = true });

                        foreach (var sId in allSidebarIds)
                        {
                            var entry = permissions.FirstOrDefault(p => p.SidebarId == sId);
                            if (entry != null)
                            {
                                foreach (var kv in newPerms)
                                {
                                    if (entry.Permissions.ContainsKey(kv.Key))
                                        entry.Permissions[kv.Key] = kv.Value;
                                    else
                                        entry.Permissions.Add(kv.Key, kv.Value);
                                }
                            }
                            else
                            {
                                permissions.Add(new SidebarPermissionDto { SidebarId = sId, Permissions = new Dictionary<string, PermissionActions>(newPerms) });
                            }
                        }

                        var permissionJson = JsonSerializer.Serialize(permissions);
                        var dbUser = await _context.Users.FindAsync(entity.UserId.Value);
                        if (dbUser != null)
                        {
                            dbUser.Permission = permissionJson;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }

            return await _repository.UpdateStatusAsync(dto.Id, dto.Status ?? "pending", currentUserId);
        }

        private async Task<string> GenerateUniqueIdAsync(int? organizationId, int? departmentId)
        {
            var prefix = "SAR";
            var count = await _context.SoftwareAccessRequests.CountAsync(x => x.Deleted == 0) + 1;
            return $"{prefix}-{organizationId ?? 0}-{departmentId ?? 0}-{count:D5}";
        }
    }
}
