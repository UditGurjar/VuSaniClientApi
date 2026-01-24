using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.LicenseRepository
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly ApplicationDbContext _context;

        public LicenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetLicensesAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            var query =
                from license in _context.Licences
                join user in _context.Users
                    on license.CreatedBy equals user.Id into users
                from user in users.DefaultIfEmpty()
                where license.Deleted == false
                select new { license, user };

            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    (x.license.Name != null && x.license.Name.Contains(search)) ||
                    (x.license.Description != null && x.license.Description.Contains(search)) ||
                    (x.user != null && x.user.Name != null && x.user.Name.Contains(search))
                );
            }

            var total = await query.CountAsync();

            if (!all)
                query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var rawData = await query.ToListAsync();

            // Parse organization JSON strings
            var licenses = rawData.Select(l =>
            {
                List<int> orgIds = new List<int>();
                if (!string.IsNullOrWhiteSpace(l.license.Organization))
                {
                    try
                    {
                        orgIds = JsonSerializer.Deserialize<List<int>>(l.license.Organization) ?? new List<int>();
                    }
                    catch
                    {
                        // If not JSON, try comma-separated
                        if (l.license.Organization.Contains(","))
                        {
                            orgIds = l.license.Organization
                                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => int.TryParse(x.Trim(), out var id) ? id : (int?)null)
                                .Where(x => x.HasValue)
                                .Select(x => x!.Value)
                                .ToList();
                        }
                        else if (int.TryParse(l.license.Organization, out var singleId))
                        {
                            orgIds = new List<int> { singleId };
                        }
                    }
                }

                return new LicenseListDto
                {
                    Id = l.license.Id,
                    Name = l.license.Name,
                    Description = DecodeHelper.DecodeSingle(l.license.Description),
                    Organization = orgIds,
                    IsStatic = l.license.IsStatic,
                    UniqueId = l.license.UniqueId,
                    CreatedBy = l.license.CreatedBy,
                    Created_by = l.user?.Name,
                    Created_by_surname = l.user?.Surname,
                    Created_by_id = l.user?.Id,
                    Created_by_profile = l.user?.Profile
                };
            }).ToList();

            return new
            {
                status = true,
                data = licenses,
                total
            };
        }
    }
}

