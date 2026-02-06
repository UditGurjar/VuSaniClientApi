using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.HighestQualificationRepository
{
    public class HighestQualificationRepository : IHighestQualificationRepository
    {
        private readonly ApplicationDbContext _context;

        public HighestQualificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetHighestQualificationsAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            try
            {
                var query =
               from qual in _context.HighestQualifications
               join user in _context.Users
                   on qual.CreatedBy equals user.Id into users
               from user in users.DefaultIfEmpty()
               where qual.Deleted == false
               select new { qual, user };

                // Search
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(x =>
                        (x.qual.Name != null && x.qual.Name.Contains(search)) ||
                        (x.qual.Description != null && x.qual.Description.Contains(search)) ||
                        (x.user != null && x.user.Name != null && x.user.Name.Contains(search))
                    );
                }

                var total = await query.CountAsync();

                if (!all)
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);

                var rawData = await query.ToListAsync();

                // Parse organization JSON strings
                var qualifications = rawData.Select(q =>
                {
                    List<int> orgIds = new List<int>();
                    if (!string.IsNullOrWhiteSpace(q.qual.Organization))
                    {
                        try
                        {
                            orgIds = JsonSerializer.Deserialize<List<int>>(q.qual.Organization) ?? new List<int>();
                        }
                        catch
                        {
                            // If not JSON, try comma-separated
                            if (q.qual.Organization.Contains(","))
                            {
                                orgIds = q.qual.Organization
                                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(x => int.TryParse(x.Trim(), out var id) ? id : (int?)null)
                                    .Where(x => x.HasValue)
                                    .Select(x => x!.Value)
                                    .ToList();
                            }
                            else if (int.TryParse(q.qual.Organization, out var singleId))
                            {
                                orgIds = new List<int> { singleId };
                            }
                        }
                    }

                    return new HighestQualificationListDto
                    {
                        Id = q.qual.Id,
                        Name = q.qual.Name,
                        Description = DecodeHelper.DecodeSingle(q.qual.Description),
                        Organization = orgIds,
                        UniqueId = q.qual.UniqueId,
                        CreatedBy = q.qual.CreatedBy,
                        Created_by = q.user?.Name,
                        Created_by_surname = q.user?.Surname,
                        Created_by_id = q.user?.Id,
                        Created_by_profile = q.user?.Profile
                    };
                }).ToList();

                return new
                {
                    status = true,
                    data = qualifications,
                    total
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

