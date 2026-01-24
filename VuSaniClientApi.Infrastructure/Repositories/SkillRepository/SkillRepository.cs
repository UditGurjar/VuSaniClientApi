using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.SkillRepository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetSkillsAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            var query =
                from skill in _context.Skills
                join user in _context.Users
                    on skill.CreatedBy equals user.Id into users
                from user in users.DefaultIfEmpty()
                where skill.Deleted == false
                select new { skill, user };

            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    (x.skill.Name != null && x.skill.Name.Contains(search)) ||
                    (x.skill.Description != null && x.skill.Description.Contains(search)) ||
                    (x.user != null && x.user.Name != null && x.user.Name.Contains(search))
                );
            }

            var total = await query.CountAsync();

            if (!all)
                query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var rawData = await query.ToListAsync();

            // Parse organization JSON strings
            var skills = rawData.Select(s =>
            {
                List<int> orgIds = new List<int>();
                if (!string.IsNullOrWhiteSpace(s.skill.Organization))
                {
                    try
                    {
                        orgIds = JsonSerializer.Deserialize<List<int>>(s.skill.Organization) ?? new List<int>();
                    }
                    catch
                    {
                        // If not JSON, try comma-separated
                        if (s.skill.Organization.Contains(","))
                        {
                            orgIds = s.skill.Organization
                                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => int.TryParse(x.Trim(), out var id) ? id : (int?)null)
                                .Where(x => x.HasValue)
                                .Select(x => x!.Value)
                                .ToList();
                        }
                        else if (int.TryParse(s.skill.Organization, out var singleId))
                        {
                            orgIds = new List<int> { singleId };
                        }
                    }
                }

                return new SkillListDto
                {
                    Id = s.skill.Id,
                    Name = s.skill.Name,
                    Description = DecodeHelper.DecodeSingle(s.skill.Description),
                    Organization = orgIds,
                    SkillsType = s.skill.SkillsType,
                    Industry = s.skill.Industry,
                    IsStatic = s.skill.IsStatic,
                    UniqueId = s.skill.UniqueId,
                    CreatedBy = s.skill.CreatedBy,
                    Created_by = s.user?.Name,
                    Created_by_surname = s.user?.Surname,
                    Created_by_id = s.user?.Id,
                    Created_by_profile = s.user?.Profile
                };
            }).ToList();

            return new
            {
                status = true,
                data = skills,
                total
            };
        }
    }
}

