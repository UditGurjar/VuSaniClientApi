using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Infrastructure.Helpers;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.LocationRepository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetLocationsAsync(int page, int pageSize, bool all, string search, string filter)
        {
            try
            {
                var query = from loc in _context.Locations
                            join createdUser in _context.Users on loc.CreatedBy equals createdUser.Id into createdGroup
                            from created in createdGroup.DefaultIfEmpty()
                            join dept in _context.Department on loc.DepartmentId equals dept.Id into deptGroup
                            from department in deptGroup.DefaultIfEmpty()
                            join parentLoc in _context.Locations on loc.Parent equals parentLoc.Id into parentGroup
                            from parent in parentGroup.DefaultIfEmpty()
                            where loc.Deleted == false
                            select new
                            {
                                loc,
                                created,
                                department,
                                parent
                            };

                // Parse filter JSON (e.g. {"organization": 1, "department": 2})
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    try
                    {
                        var filterObj = JsonSerializer.Deserialize<JsonElement>(filter);

                        if (filterObj.TryGetProperty("organization", out var orgProp))
                        {
                            var orgFilterStr = orgProp.ToString();
                            if (!string.IsNullOrEmpty(orgFilterStr) && int.TryParse(orgFilterStr, out int orgFilterId))
                            {
                                // Filter locations where Organization JSON contains the org ID
                                query = query.Where(x =>
                                    x.loc.Organization != null &&
                                    x.loc.Organization.Contains(orgFilterId.ToString()));
                            }
                        }

                        if (filterObj.TryGetProperty("department", out var deptProp))
                        {
                            var deptFilterStr = deptProp.ToString();
                            if (!string.IsNullOrEmpty(deptFilterStr) && int.TryParse(deptFilterStr, out int deptFilterId))
                            {
                                query = query.Where(x => x.loc.DepartmentId == deptFilterId);
                            }
                        }
                    }
                    catch { /* ignore bad filter JSON */ }
                }

                // Search filter
                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    query = query.Where(x =>
                        (x.loc.Name != null && x.loc.Name.ToLower().Contains(search)) ||
                        (x.loc.UniqueId != null && x.loc.UniqueId.ToLower().Contains(search)) ||
                        (x.loc.Description != null && x.loc.Description.ToLower().Contains(search))
                    );
                }

                // Order by most recent first
                query = query.OrderByDescending(x => x.loc.CreatedAt);

                var total = await query.CountAsync();

                // Pagination
                if (!all)
                {
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);
                }

                var rawData = await query.ToListAsync();

                // Collect all organization IDs for bulk fetch
                var allOrgIds = new HashSet<int>();
                foreach (var r in rawData)
                {
                    if (!string.IsNullOrEmpty(r.loc.Organization))
                    {
                        try
                        {
                            var parsed = JsonSerializer.Deserialize<List<int>>(r.loc.Organization);
                            if (parsed != null)
                                foreach (var id in parsed)
                                    allOrgIds.Add(id);
                        }
                        catch { }
                    }
                }

                // Fetch organizations in a single query
                var orgMap = await _context.Organizations
                    .Where(x => allOrgIds.Contains(x.Id))
                    .Select(x => new { x.Id, x.Name, x.BusinessLogo })
                    .ToDictionaryAsync(x => x.Id);

                // Shape data
                var data = rawData.Select(x =>
                {
                    var orgIds = new List<int>();
                    var orgDetails = new List<OrganizationMiniDto>();

                    if (!string.IsNullOrEmpty(x.loc.Organization))
                    {
                        try
                        {
                            var parsed = JsonSerializer.Deserialize<List<int>>(x.loc.Organization);
                            if (parsed != null)
                            {
                                orgIds = parsed.Distinct().ToList();
                                foreach (var id in orgIds)
                                {
                                    if (orgMap.ContainsKey(id))
                                    {
                                        var o = orgMap[id];
                                        orgDetails.Add(new OrganizationMiniDto
                                        {
                                            Id = o.Id,
                                            Name = o.Name,
                                            Image = o.BusinessLogo
                                        });
                                    }
                                }
                            }
                        }
                        catch { }
                    }

                    return new LocationListDto
                    {
                        Id = x.loc.Id,
                        Unique_Id = x.loc.UniqueId,
                        Name = x.loc.Name,
                        Description = DecodeHelper.DecodeSingle(x.loc.Description),
                        Organization = orgIds,
                        Organization_Details = orgDetails,
                        Department_Id = x.loc.DepartmentId,
                        Department_Name = x.department?.Name,
                        Parent_Id = x.loc.Parent,
                        Parent_Name = x.parent?.Name,
                        Is_Static = x.loc.IsStatic,
                        Created_By_Id = x.created?.Id,
                        Created_By = x.created?.Name,
                        Created_By_Surname = x.created?.Surname,
                        Created_By_Profile = x.created?.Profile,
                        Created_At = x.loc.CreatedAt,
                        Updated_By = x.loc.UpdatedBy,
                        Updated_At = x.loc.UpdatedAt
                    };
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

        public async Task<object> GetLocationByIdAsync(int id)
        {
            try
            {
                var query = from loc in _context.Locations
                            join createdUser in _context.Users on loc.CreatedBy equals createdUser.Id into createdGroup
                            from created in createdGroup.DefaultIfEmpty()
                            join dept in _context.Department on loc.DepartmentId equals dept.Id into deptGroup
                            from department in deptGroup.DefaultIfEmpty()
                            join parentLoc in _context.Locations on loc.Parent equals parentLoc.Id into parentGroup
                            from parent in parentGroup.DefaultIfEmpty()
                            where loc.Id == id && loc.Deleted == false
                            select new
                            {
                                loc,
                                created,
                                department,
                                parent
                            };

                var result = await query.FirstOrDefaultAsync();

                if (result == null)
                {
                    return new { status = false, message = "Location not found" };
                }

                // Parse organization IDs and fetch details
                var orgIds = new List<int>();
                var orgDetails = new List<OrganizationMiniDto>();

                if (!string.IsNullOrEmpty(result.loc.Organization))
                {
                    try
                    {
                        var parsed = JsonSerializer.Deserialize<List<int>>(result.loc.Organization);
                        if (parsed != null)
                        {
                            orgIds = parsed.Distinct().ToList();

                            var orgs = await _context.Organizations
                                .Where(x => orgIds.Contains(x.Id))
                                .Select(x => new { x.Id, x.Name, x.BusinessLogo })
                                .ToListAsync();

                            orgDetails = orgs.Select(o => new OrganizationMiniDto
                            {
                                Id = o.Id,
                                Name = o.Name,
                                Image = o.BusinessLogo
                            }).ToList();
                        }
                    }
                    catch { }
                }

                var data = new LocationListDto
                {
                    Id = result.loc.Id,
                    Unique_Id = result.loc.UniqueId,
                    Name = result.loc.Name,
                    Description = DecodeHelper.DecodeSingle(result.loc.Description),
                    Organization = orgIds,
                    Organization_Details = orgDetails,
                    Department_Id = result.loc.DepartmentId,
                    Department_Name = result.department?.Name,
                    Parent_Id = result.loc.Parent,
                    Parent_Name = result.parent?.Name,
                    Is_Static = result.loc.IsStatic,
                    Created_By_Id = result.created?.Id,
                    Created_By = result.created?.Name,
                    Created_By_Surname = result.created?.Surname,
                    Created_By_Profile = result.created?.Profile,
                    Created_At = result.loc.CreatedAt,
                    Updated_By = result.loc.UpdatedBy,
                    Updated_At = result.loc.UpdatedAt
                };

                return new { status = true, data = new List<LocationListDto> { data } };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> CreateUpdateLocationAsync(CreateUpdateLocationRequest request, int userId)
        {
            try
            {
                // Check if name already exists
                var existingWithName = await _context.Locations
                    .Where(l => l.Deleted == false && l.Name == request.Name)
                    .FirstOrDefaultAsync();

                // Serialize organization list to JSON string
                string? organizationJson = null;
                if (request.Organization != null && request.Organization.Count > 0)
                {
                    organizationJson = JsonSerializer.Serialize(request.Organization);
                }

                if (request.Id.HasValue && request.Id.Value > 0)
                {
                    // UPDATE
                    if (existingWithName != null && existingWithName.Id != request.Id.Value)
                    {
                        return new { status = false, message = $"Location with name '{request.Name}' already exists" };
                    }

                    var existing = await _context.Locations
                        .FirstOrDefaultAsync(l => l.Id == request.Id.Value && l.Deleted == false);

                    if (existing == null)
                    {
                        return new { status = false, message = "Location not found" };
                    }

                    // Prevent self-referencing parent
                    if (request.Parent_Id.HasValue && request.Parent_Id.Value == existing.Id)
                    {
                        return new { status = false, message = "A location cannot be its own parent" };
                    }

                    existing.Name = request.Name;
                    existing.Description = request.Description;
                    existing.DepartmentId = request.Department;
                    existing.Organization = organizationJson;
                    existing.Parent = request.Parent_Id;
                    existing.UpdatedBy = userId;
                    existing.UpdatedAt = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    // Activity log
                    await GeneralHelper.InsertActivityLogAsync(_context, userId, "update", "Location", existing.Id);

                    return new { status = true, message = "Location updated successfully" };
                }
                else
                {
                    // CREATE
                    if (existingWithName != null)
                    {
                        return new { status = false, message = $"Location with name '{request.Name}' already exists" };
                    }

                    // Generate unique ID
                    var uniqueId = await GeneralHelper.UniqueIdGeneratorAsync(
                        _context,
                        null,
                        null,
                        "LOC",
                        "Locations",
                        "UniqueId"
                    );

                    var newLocation = new Location
                    {
                        UniqueId = uniqueId,
                        Name = request.Name,
                        Description = request.Description,
                        DepartmentId = request.Department,
                        Organization = organizationJson,
                        Parent = request.Parent_Id,
                        IsStatic = 0,
                        CreatedBy = userId,
                        CreatedAt = DateTime.UtcNow,
                        Deleted = false
                    };

                    _context.Locations.Add(newLocation);
                    await _context.SaveChangesAsync();

                    // Activity log
                    await GeneralHelper.InsertActivityLogAsync(_context, userId, "create", "Location", newLocation.Id);

                    return new { status = true, message = "Location created successfully", id = newLocation.Id };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> DeleteLocationAsync(int id, int userId)
        {
            try
            {
                var location = await _context.Locations
                    .FirstOrDefaultAsync(l => l.Id == id && l.Deleted == false);

                if (location == null)
                {
                    return new { status = false, message = "Location not found" };
                }

                // Prevent deletion of static (seed) data
                if (location.IsStatic == 1)
                {
                    return new { status = false, message = "Cannot delete static location data" };
                }

                // Check if location is used as parent by other locations
                var hasChildren = await _context.Locations
                    .AnyAsync(l => l.Parent == id && l.Deleted == false);

                if (hasChildren)
                {
                    return new { status = false, message = "Cannot delete location because it has child locations. Please reassign or delete child locations first." };
                }

                // Soft delete
                location.Deleted = true;
                location.UpdatedBy = userId;
                location.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                // Activity log
                await GeneralHelper.InsertActivityLogAsync(_context, userId, "delete", "Location", id);

                return new { status = true, message = "Location deleted successfully" };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
