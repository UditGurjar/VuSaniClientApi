using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.Repositories.ActivityLogRepository
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetActivityLogsAsync(int page, int pageSize, bool all, string search, string filter, int? userId = null)
        {
            try
            {
                var query = _context.ActivityLogs
                    .Include(a => a.User)
                    .Where(a => !a.Deleted)
                    .AsQueryable();

                // Filter by user if provided
                if (userId.HasValue)
                {
                    query = query.Where(a => a.CreatedBy == userId.Value);
                }

                // Search filter
                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    query = query.Where(a =>
                        (a.Module != null && a.Module.ToLower().Contains(search)) ||
                        (a.Message != null && a.Message.ToLower().Contains(search)) ||
                        (a.Status != null && a.Status.ToLower().Contains(search)) ||
                        (a.User != null && a.User.Name != null && a.User.Name.ToLower().Contains(search))
                    );
                }

                // Status filter
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    query = query.Where(a => a.Status == filter.ToLower());
                }

                // Order by most recent first
                query = query.OrderByDescending(a => a.CreatedAt);

                // Get total count
                var totalRecords = await query.CountAsync();

                // Apply pagination
                List<ActivityLog> activityLogs;
                if (all)
                {
                    activityLogs = await query.ToListAsync();
                }
                else
                {
                    activityLogs = await query
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
                }

                // Map to response
                var data = activityLogs.Select(a => new
                {
                    id = a.Id,
                    status = a.Status,
                    module = a.Module,
                    message = a.Message,
                    createdAt = a.CreatedAt,
                    createdBy = a.CreatedBy,
                    userName = a.User != null ? $"{a.User.Name} {a.User.Surname}".Trim() : "Unknown User"
                }).ToList();

                return new
                {
                    status = true,
                    message = "Activity logs retrieved successfully",
                    data = data,
                    totalRecords = totalRecords,
                    page = page,
                    pageSize = pageSize,
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving activity logs: {ex.Message}", ex);
            }
        }

        public async Task<object> GetActivityLogsByUserIdAsync(int userId, int page, int pageSize)
        {
            try
            {
                var query = _context.ActivityLogs
                    .Include(a => a.User)
                    .Where(a => !a.Deleted && a.CreatedBy == userId)
                    .OrderByDescending(a => a.CreatedAt);

                var totalRecords = await query.CountAsync();

                var activityLogs = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var data = activityLogs.Select(a => new
                {
                    id = a.Id,
                    status = a.Status,
                    module = a.Module,
                    message = a.Message,
                    createdAt = a.CreatedAt,
                    createdBy = a.CreatedBy,
                    userName = a.User != null ? $"{a.User.Name} {a.User.Surname}".Trim() : "Unknown User"
                }).ToList();

                return new
                {
                    status = true,
                    message = "Activity logs retrieved successfully",
                    data = data,
                    totalRecords = totalRecords,
                    page = page,
                    pageSize = pageSize,
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving activity logs for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<ActivityLog> InsertActivityLogAsync(int createdBy, string status, string module, string message)
        {
            try
            {
                var activityLog = new ActivityLog
                {
                    CreatedBy = createdBy,
                    Status = status.ToLower(),
                    Module = module,
                    Message = message,
                    Deleted = false,
                    CreatedAt = DateTime.Now
                };

                _context.ActivityLogs.Add(activityLog);
                await _context.SaveChangesAsync();

                return activityLog;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting activity log: {ex.Message}", ex);
            }
        }
    }
}
