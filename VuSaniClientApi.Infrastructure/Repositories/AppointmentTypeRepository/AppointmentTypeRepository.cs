using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Infrastructure.Helpers;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.AppointmentTypeRepository
{
    public class AppointmentTypeRepository : IAppointmentTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetAppointmentTypesAsync(int page, int pageSize, bool all, string search)
        {
            try
            {
                var query = from at in _context.AppointmentTypes
                            join createdUser in _context.Users on at.CreatedBy equals createdUser.Id into createdGroup
                            from created in createdGroup.DefaultIfEmpty()
                            join updatedUser in _context.Users on at.UpdatedBy equals updatedUser.Id into updatedGroup
                            from updated in updatedGroup.DefaultIfEmpty()
                            where at.Deleted == false
                            select new
                            {
                                at,
                                created,
                                updated
                            };

                // Search filter
                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    query = query.Where(x =>
                        (x.at.Name != null && x.at.Name.ToLower().Contains(search)) ||
                        (x.at.UniqueId != null && x.at.UniqueId.ToLower().Contains(search))
                    );
                }

                // Order by most recent first
                query = query.OrderByDescending(x => x.at.CreatedAt);

                var total = await query.CountAsync();

                // Pagination
                if (!all)
                {
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);
                }

                var rawData = await query.ToListAsync();

                var data = rawData.Select(x => new AppointmentTypeListDto
                {
                    Id = x.at.Id,
                    UniqueId = x.at.UniqueId,
                    Name = x.at.Name,
                    Assignment = DecodeHelper.DecodeSingle(x.at.Assignment),
                    Designated = DecodeHelper.DecodeSingle(x.at.Designated),
                    Applicable = DecodeHelper.DecodeSingle(x.at.Applicable),
                    CreatedBy = x.at.CreatedBy,
                    CreatedByName = x.created != null ? $"{x.created.Name} {x.created.Surname}".Trim() : null,
                    CreatedAt = x.at.CreatedAt,
                    UpdatedBy = x.at.UpdatedBy,
                    UpdatedByName = x.updated != null ? $"{x.updated.Name} {x.updated.Surname}".Trim() : null,
                    UpdatedAt = x.at.UpdatedAt
                }).ToList();

                return new
                {
                    status = true,
                    data = data,
                    total = total,
                    page = page,
                    pageSize = pageSize
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetAppointmentTypeByIdAsync(int id)
        {
            try
            {
                var query = from at in _context.AppointmentTypes
                            join createdUser in _context.Users on at.CreatedBy equals createdUser.Id into createdGroup
                            from created in createdGroup.DefaultIfEmpty()
                            join updatedUser in _context.Users on at.UpdatedBy equals updatedUser.Id into updatedGroup
                            from updated in updatedGroup.DefaultIfEmpty()
                            where at.Id == id && at.Deleted == false
                            select new
                            {
                                at,
                                created,
                                updated
                            };

                var result = await query.FirstOrDefaultAsync();

                if (result == null)
                {
                    return new { status = false, message = "Appointment Type not found" };
                }

                var data = new AppointmentTypeListDto
                {
                    Id = result.at.Id,
                    UniqueId = result.at.UniqueId,
                    Name = result.at.Name,
                    Assignment = DecodeHelper.DecodeSingle(result.at.Assignment),
                    Designated = DecodeHelper.DecodeSingle(result.at.Designated),
                    Applicable = DecodeHelper.DecodeSingle(result.at.Applicable),
                    CreatedBy = result.at.CreatedBy,
                    CreatedByName = result.created != null ? $"{result.created.Name} {result.created.Surname}".Trim() : null,
                    CreatedAt = result.at.CreatedAt,
                    UpdatedBy = result.at.UpdatedBy,
                    UpdatedByName = result.updated != null ? $"{result.updated.Name} {result.updated.Surname}".Trim() : null,
                    UpdatedAt = result.at.UpdatedAt
                };

                return new { status = true, data = new List<AppointmentTypeListDto> { data } };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> CreateUpdateAppointmentTypeAsync(CreateUpdateAppointmentTypeRequest request, int userId)
        {
            try
            {
                // Check if name already exists
                var existingWithName = await _context.AppointmentTypes
                    .Where(a => a.Deleted == false && a.Name == request.Name)
                    .FirstOrDefaultAsync();

                if (request.Id.HasValue && request.Id.Value > 0)
                {
                    // UPDATE
                    if (existingWithName != null && existingWithName.Id != request.Id.Value)
                    {
                        return new { status = false, message = $"Appointment Type with name '{request.Name}' already exists" };
                    }

                    var existing = await _context.AppointmentTypes
                        .FirstOrDefaultAsync(a => a.Id == request.Id.Value && a.Deleted == false);

                    if (existing == null)
                    {
                        return new { status = false, message = "Appointment Type not found" };
                    }

                    existing.Name = request.Name;
                    existing.Assignment = request.Assignment;
                    existing.Designated = request.Designated;
                    existing.Applicable = request.Applicable;
                    existing.UpdatedBy = userId;
                    existing.UpdatedAt = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    // Activity log
                    await GeneralHelper.InsertActivityLogAsync(_context, userId, "update", "Appointment Type", existing.Id);

                    return new { status = true, message = "Appointment Type updated successfully" };
                }
                else
                {
                    // CREATE
                    if (existingWithName != null)
                    {
                        return new { status = false, message = $"Appointment Type with name '{request.Name}' already exists" };
                    }

                    // Generate unique ID
                    var uniqueId = await GeneralHelper.UniqueIdGeneratorAsync(
                        _context,
                        null,
                        null,
                        "APT",
                        "AppointmentTypes",
                        "UniqueId"
                    );

                    var newType = new AppointmentType
                    {
                        UniqueId = uniqueId,
                        Name = request.Name,
                        Assignment = request.Assignment,
                        Designated = request.Designated,
                        Applicable = request.Applicable,
                        CreatedBy = userId,
                        CreatedAt = DateTime.UtcNow,
                        Deleted = false
                    };

                    _context.AppointmentTypes.Add(newType);
                    await _context.SaveChangesAsync();

                    // Activity log
                    await GeneralHelper.InsertActivityLogAsync(_context, userId, "create", "Appointment Type", newType.Id);

                    return new { status = true, message = "Appointment Type created successfully", id = newType.Id };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> DeleteAppointmentTypeAsync(int id, int userId)
        {
            try
            {
                var appointmentType = await _context.AppointmentTypes
                    .FirstOrDefaultAsync(a => a.Id == id && a.Deleted == false);

                if (appointmentType == null)
                {
                    return new { status = false, message = "Appointment Type not found" };
                }

                // Soft delete
                appointmentType.Deleted = true;
                appointmentType.UpdatedBy = userId;
                appointmentType.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // Activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "delete", "Appointment Type", id);

                return new { status = true, message = "Appointment Type deleted successfully" };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
