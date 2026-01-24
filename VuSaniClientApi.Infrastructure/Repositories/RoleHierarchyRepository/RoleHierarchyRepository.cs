using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.RoleHierarchyRepository
{
    public class RoleHierarchyRepository : IRoleHierarchyRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleHierarchyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(List<RoleHierarchyListDto> Data, int Total)> GetRoleHierarchyAsync(
            int page, int pageSize, bool all, string? search, List<int>? allowedOrgIds)
        {
            var query =
                from rh in _context.RoleHierarchies
                join u in _context.Users on rh.CreatedBy equals u.Id into users
                from u in users.DefaultIfEmpty()
                where rh.Deleted == false
                select new { rh, u };

            // 🔍 Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.rh.Name!.Contains(search) ||
                    x.rh.Description!.Contains(search) ||
                    x.u!.Name!.Contains(search));
            }

            var total = await query.CountAsync();

            if (!all)
                query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var rawData = await query.ToListAsync();

            // 🔹 Collect organization ids
            var orgIds = new HashSet<int>();

            foreach (var r in rawData)
            {
                if (!string.IsNullOrEmpty(r.rh.Organization))
                {
                    try
                    {
                        var parsed = JsonSerializer.Deserialize<List<int>>(r.rh.Organization);
                        if (parsed != null)
                            foreach (var id in parsed)
                                orgIds.Add(id);
                    }
                    catch { }
                }
            }

            // 🔹 Fetch organizations
            var orgMap = await _context.Organizations
                .Where(x => orgIds.Contains(x.Id))
                .Select(x => new { x.Id, x.Name, x.BusinessLogo })
                .ToDictionaryAsync(x => x.Id);

            // 🎯 Final shaping (Node getListingData equivalent)
            var result = rawData.Select(r =>
            {
                var details = new List<OrganizationMiniDto>();
                List<int> orgIds = new List<int>();

                if (!string.IsNullOrEmpty(r.rh.Organization))
                {
                    var parsed = JsonSerializer.Deserialize<List<int>>(r.rh.Organization);
                    if (parsed != null)
                    {
                        orgIds = parsed.Distinct().ToList();
                        foreach (var id in orgIds)
                        {
                            if (orgMap.ContainsKey(id))
                            {
                                var o = orgMap[id];
                                details.Add(new OrganizationMiniDto
                                {
                                    Id = o.Id,
                                    Name = o.Name,
                                    Image = o.BusinessLogo
                                });
                            }
                        }
                    }
                }

                return new RoleHierarchyListDto
                {
                    Id = r.rh.Id,
                    Name = r.rh.Name,
                    Description = DecodeHelper.DecodeSingle(r.rh.Description),
                    Level = r.rh.Level,

                    CreatedBy = r.u?.Name,
                    CreatedBySurname = r.u?.Surname,
                    CreatedById = r.u?.Id,
                    CreatedByProfile = r.u?.Profile,

                    Organization = orgIds,
                    Organization_Details = details
                };
            }).ToList();

            return (result, total);
        }
    }

}
