using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.Repositories.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<object> GetRolesAsync(int page, int pageSize, bool all, string? search, string? filter)
        {
            var query =
       from role in _context.Roles

       join user in _context.Users
           on role.CreatedBy equals user.Id into users
       from user in users.DefaultIfEmpty()

       join org in _context.Organizations
           on role.OrganizationId equals org.Id into orgs
       from org in orgs.DefaultIfEmpty()

       join hierarchy in _context.RoleHierarchies
           on role.Hierarchy equals hierarchy.Id into hierarchies
       from hierarchy in hierarchies.DefaultIfEmpty()

       join qualification in _context.HighestQualifications
           on role.QualificationId equals qualification.Id into qualifications
       from qualification in qualifications.DefaultIfEmpty()

           // ✅ SELF JOIN for ReportToRole (Role -> Role)
       join reportRole in _context.Roles
           on role.ReportToRole equals reportRole.Id.ToString() into reportRoles
       from reportRole in reportRoles.DefaultIfEmpty()

       where role.Deleted == false
       select new
       {
           role,
           user,
           org,
           hierarchy,
           qualification,
           reportRole   // ✅ now exists
       };


            // 🔍 Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    (x.role.Name != null && x.role.Name.Contains(search)) ||
                    (x.role.Description != null && x.role.Description.Contains(search)) ||
                    (x.org != null && x.org.Name != null && x.org.Name.Contains(search)) ||
                    (x.user != null && x.user.Name != null && x.user.Name.Contains(search))
                );
            }

            var total = await query.CountAsync();

            if (!all)
                query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var rawData = await query.ToListAsync();

            // 🧠 Collect all ids
            var allSkillIds = new HashSet<int>();
            var allLicenseIds = new HashSet<int>();

            foreach (var r in rawData)
            {
                allSkillIds.UnionWith(SafeParseIds(r.role.Skills));
                allLicenseIds.UnionWith(SafeParseIds(r.role.License));
            }

            var skills = await _context.Skills
                .Where(x => allSkillIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            var licenses = await _context.Licences
                .Where(x => allLicenseIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

 
            // 🎯 Final shaping
            var roles = rawData.Select(r =>
            {
                var skillIds = SafeParseIds(r.role.Skills);
                var licenseIds = SafeParseIds(r.role.License);

                return new RoleListDto
                {
                    Id = r.role.Id,
                    Unique_id = r.role.UniqueId,

                    Report_to_role = string.IsNullOrEmpty(r.role.ReportToRole) ? null : int.Parse(r.role.ReportToRole),
                    Report_to_role_name = r.reportRole?.Name,

                    Hierarchy = r.role.Hierarchy,
                    Qualification = r.role.QualificationId,

                    Year_of_experience = r.role.YearOfExperience,

                    License = licenseIds,

                    Other_requirements = r.role.OtherRequirements,
                    Select_other_requirements = r.role.SelectOtherRequirements,

                    Name = r.role.Name,
                    Description = r.role.Description,

                    Organization = r.role.OrganizationId,
                    Organization_name = r.org?.Name,

                    //Header_image = r.role,
                    //Footer_image = r.role.FooterImage,
                    //Business_logo = r.role.BusinessLogo,

                    Created_by_id = r.user?.Id,
                    Created_by = r.user?.Name,
                    Created_by_profile = r.user?.Profile,
                    Created_by_surname = r.user?.Surname,

                    Hierarchy_name = r.hierarchy?.Name,
                    Qualification_name = r.qualification?.Name,

                    SkillsDetail = skillIds
                        .Where(id => skills.ContainsKey(id))
                        .Select(id => new IdNameDto { Id = id, Name = skills[id] })
                        .ToList(),

                    LicenseDetail = licenseIds
                        .Where(id => licenses.ContainsKey(id))
                        .Select(id => new IdNameDto { Id = id, Name = licenses[id] })
                        .ToList(),

                 
                };
            }).ToList();

            return new
            {
                status = true,
                data = roles,
                total
            };
        }

        private static List<int> SafeParseIds(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new List<int>();

            value = value.Trim();

            try
            {
                // ✅ Proper JSON array: [1,2,3]
                if (value.StartsWith("["))
                    return JsonSerializer.Deserialize<List<int>>(value) ?? new List<int>();

                // ✅ Comma separated: "1,2,3"
                return value
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.TryParse(x.Trim(), out var i) ? i : (int?)null)
                    .Where(x => x.HasValue)
                    .Select(x => x!.Value)
                    .ToList();
            }
            catch
            {
                // ✅ Never crash API because of bad DB data
                return new List<int>();
            }
        }

        //public async Task<object> GetRolesAsync(int page, int pageSize, bool all, string search, string filter)
        //{
        //    //// Base query: filter deleted roles
        //    //var query = _context.Roles
        //    //    .Where(r => r.Deleted == false)
        //    //    .AsQueryable();

        //    //// Apply search by role name
        //    //if (!string.IsNullOrEmpty(search))
        //    //{
        //    //    query = query.Where(x => x.Name.Contains(search));
        //    //}


        //    //// Optional filter (replace with your actual column logic)
        //    //if (!string.IsNullOrEmpty(filter))
        //    //    query = query.Where(r => r.OrganizationId.ToString() == filter);

        //    //var total = await query.CountAsync();

        //    //// Pagination
        //    //if (!all)
        //    //    query = query.Skip((page - 1) * pageSize).Take(pageSize);

        //    //// Select roles with expanded data like Node.js API
        //    //var data = await query.Select(r => new
        //    //{
        //    //    r.Id,
        //    //    r.Name,
        //    //    r.Description,
        //    //    r.Level,
        //    //    r.Qualification,
        //    //    r.YearOfExperience,
        //    //    r.OtherRequirements,
        //    //    r.SelectOtherRequirements,
        //    //    r.ReportToRole,
        //    //    r.Department,
        //    //    r.Hierarchy,
        //    //    r.License,
        //    //    r.Skills,
        //    //    r.Permission, // JSON string with sidebar permissions
        //    //    r.PreEmployment,
        //    //    r.PostEmployment,
        //    //    r.UniqueId,
        //    //    Organization = r.Organization != null ? new
        //    //    {
        //    //        r.Organization.Id,
        //    //        r.Organization.Name
        //    //    } : null,

        //    //    Licenses = string.IsNullOrEmpty(r.License)
        //    //        ? new List<int>()
        //    //        : JsonSerializer.Deserialize<List<int>>(r.License),
        //    //    SkillsList = string.IsNullOrEmpty(r.Skills)
        //    //        ? new List<int>()
        //    //        : JsonSerializer.Deserialize<List<int>>(r.Skills),
        //    //    Permissions = string.IsNullOrEmpty(r.Permission)
        //    //        ? new List<object>()
        //    //        : JsonSerializer.Deserialize<List<object>>(r.Permission),
        //    //    CreatedBy = r.CreatedBy,
        //    //    CreatedAt = r.CreatedAt,
        //    //    UpdatedBy = r.UpdatedBy,
        //    //    UpdatedAt = r.UpdatedAt
        //    //}).ToListAsync();

        //    //return new
        //    //{
        //    //    total,
        //    //    page,
        //    //    pageSize,
        //    //    data
        //    //};
        //    var query = _context.Roles.AsQueryable();

        //    // Apply search or filters in SQL
        //    if (!string.IsNullOrEmpty(search))
        //        query = query.Where(x => x.Name.Contains(search));

        //    var total = await query.CountAsync();

        //    // Pagination in SQL
        //    if (!all)
        //        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        //    // Materialize query first
        //    var rolesFromDb = await query.ToListAsync();

        //    // Now deserialize JSON in memory
        //    var rolesDto = rolesFromDb.Select(r => new
        //    {
        //        r.Id,
        //        r.Name,
        //        r.Description,
        //        Licenses = string.IsNullOrEmpty(r.License)
        //            ? new List<int>()
        //            : JsonSerializer.Deserialize<List<int>>(r.License)!,
        //        SkillsList = string.IsNullOrEmpty(r.Skills)
        //            ? new List<int>()
        //            : JsonSerializer.Deserialize<List<int>>(r.Skills)!,
        //        Permissions = string.IsNullOrEmpty(r.Permission)
        //            ? new List<object>()
        //            : JsonSerializer.Deserialize<List<object>>(r.Permission)!,
        //        r.CreatedBy,
        //        r.CreatedAt
        //    }).ToList();

        //    return new
        //    {
        //        total,
        //        page,
        //        pageSize,
        //        data = rolesDto
        //    };

        //}

        public async Task<object> CreateUpdateRoleAsync(CreateUpdateRoleRequest request, int userId)
        {
            try
            {
                int? organizationId = request.Organization;

                // Check record if organization is not coming then fetch organization according to department
                if (request.Department.HasValue && !organizationId.HasValue)
                {
                    var deptRecords = await GeneralHelper.GetOrganizationAccordingToDepartmentAsync(_context, request.Department.Value);
                    if (deptRecords.Any())
                    {
                        organizationId = deptRecords[0].OrganizationId;
                    }
                }

                if (!organizationId.HasValue)
                {
                    return new { status = false, message = "Organization is required" };
                }

                // Check that this organization has that particular name or not
                var checkNameWithOrganization = await GeneralHelper.CheckNameInOrganizationAsync(_context, request.Name, organizationId.Value);

                // If id comes in body then it will update the query
                if (request.Id.HasValue)
                {
                    if (checkNameWithOrganization.Any() && checkNameWithOrganization[0].Id != request.Id.Value)
                    {
                        return new { status = false, message = $"Record with {request.Name} already exists" };
                    }

                    // Update Roles
                    var existingRole = await _context.Roles.FindAsync(request.Id.Value);
                    if (existingRole == null)
                    {
                        return new { status = false, message = "Role not found" };
                    }

                    // Update fields
                    existingRole.Level = request.Level;
                    existingRole.Name = request.Name;
                    existingRole.Description = GeneralHelper.EncodeSingle(request.Description);
                    existingRole.OrganizationId = organizationId;
                    existingRole.License = request.License != null ? JsonSerializer.Serialize(request.License) : null;
                    existingRole.Skills = request.Skills != null ? JsonSerializer.Serialize(request.Skills) : null;
                    existingRole.Department = request.Department;
                    existingRole.Hierarchy = request.Hierarchy;
                    existingRole.QualificationId = request.Qualification;
                    existingRole.YearOfExperience = request.Year_of_experience;
                    existingRole.OtherRequirements = request.Other_requirements;
                    existingRole.SelectOtherRequirements = request.Select_other_requirements;
                    existingRole.ReportToRole = request.Report_to_role;
                    existingRole.UpdatedBy = userId;
                    existingRole.UpdatedAt = DateTime.UtcNow;

                    await _context.SaveChangesAsync();

                    // Insert Activity Log
                    await GeneralHelper.InsertActivityLogAsync(_context, userId, "update", "Roles", request.Id.Value);

                    return new { status = true, message = "Record updated successfully" };
                }
                else
                {
                    if (checkNameWithOrganization.Any())
                    {
                        return new { status = false, message = "This record already exists" };
                    }

                    // Generate unique ID
                    var uniqueId = await GeneralHelper.UniqueIdGeneratorAsync(
                        _context,
                        organizationId,
                        request.Department,
                        "ROL",
                        "Roles",
                        "UniqueId",
                        "unique_id"
                    );

                    // Create new role
                    var newRole = new Role
                    {
                        Level = request.Level,
                        Name = request.Name,
                        Description = GeneralHelper.EncodeSingle(request.Description),
                        OrganizationId = organizationId,
                        License = request.License != null ? JsonSerializer.Serialize(request.License) : null,
                        Skills = request.Skills != null ? JsonSerializer.Serialize(request.Skills) : null,
                        Department = request.Department,
                        Hierarchy = request.Hierarchy,
                        QualificationId = request.Qualification,
                        YearOfExperience = request.Year_of_experience,
                        OtherRequirements = request.Other_requirements,
                        SelectOtherRequirements = request.Select_other_requirements,
                        ReportToRole = request.Report_to_role,
                        UniqueId = uniqueId,
                        CreatedBy = userId,
                        CreatedAt = DateTime.UtcNow,
                        Deleted = false
                    };

                    _context.Roles.Add(newRole);
                    await _context.SaveChangesAsync();

                    // Insert Activity Log
                    await GeneralHelper.InsertActivityLogAsync(_context, userId, "create", "Roles", newRole.Id);

                    return new { status = true, message = "Record created successfully" };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
