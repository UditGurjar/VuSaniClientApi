using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.Helpers
{
    public static class GeneralHelper
    {
            public static string? EncodeSingle(string? data)
            {
                if (string.IsNullOrWhiteSpace(data))
                    return null;

                return WebUtility.HtmlEncode(data);
            }

        public static async Task<string> UniqueIdGeneratorAsync(
            ApplicationDbContext context,
            int? organizationId,
            int? departmentId,
            string module,
            string tableName,
            string key,
            string type = "unique_id",
            int? dataId = null)
        {
            try
            {
                module = GetCapitalLetters(module);
                string id = type == "reference" ? "REF:" : "";

                if (organizationId.HasValue)
                {
                    var org = await context.Organizations.FindAsync(organizationId.Value);
                    if (org != null && !string.IsNullOrEmpty(org.Name))
                    {
                        var initials = GetInitials(org.Name);
                        id += initials;
                    }
                }

                if (departmentId.HasValue)
                {
                    var dept = await context.Department.FindAsync(departmentId.Value);
                    if (dept != null && !string.IsNullOrEmpty(dept.Name))
                    {
                        id += "/" + GetInitials(dept.Name);
                    }
                }

                if (!string.IsNullOrEmpty(module))
                {
                    id += "/" + module;
                }

                var year = GetFinancialYear(DateTime.Now);
                if (!string.IsNullOrEmpty(year))
                {
                    id += "/" + year;
                }

                if (dataId.HasValue)
                {
                    id += "/" + dataId.Value;
                }
                else
                {
                    // Get max ID from table using raw SQL
                    var escapedId = id.Replace("'", "''");

                    // Use FromSqlRaw for Roles table specifically
                    if (tableName == "Roles")
                    {
                        var maxRecords = await context.Roles
                            .Where(r => r.UniqueId != null && r.UniqueId.StartsWith(id))
                            .OrderByDescending(r => r.Id)
                            .Select(r => r.UniqueId)
                            .FirstOrDefaultAsync();

                        if (!string.IsNullOrEmpty(maxRecords))
                        {
                            var parts = maxRecords.Split(new[] { id + "/" }, StringSplitOptions.None);
                            if (parts.Length > 1 && int.TryParse(parts[1], out int serialNo))
                            {
                                id += "/" + (serialNo + 1).ToString("000");
                            }
                            else
                            {
                                id += "/001";
                            }
                        }
                        else
                        {
                            id += "/001";
                        }
                    }
                    else
                    {
                        // For other tables, use EF Core
                        string? maxUniqueId = null;

                        switch (tableName.ToLower())
                        {
                            case "skills":
                                maxUniqueId = await context.Skills
                                    .Where(s => s.UniqueId != null && s.UniqueId.StartsWith(id))
                                    .OrderByDescending(s => s.Id)
                                    .Select(s => s.UniqueId)
                                    .FirstOrDefaultAsync();
                                break;

                            case "licence":
                            case "licenses":
                                maxUniqueId = await context.Licences
                                    .Where(l => l.UniqueId != null && l.UniqueId.StartsWith(id))
                                    .OrderByDescending(l => l.Id)
                                    .Select(l => l.UniqueId)
                                    .FirstOrDefaultAsync();
                                break;

                            case "department":
                            case "departments":
                                maxUniqueId = await context.Department
                                    .Where(d => d.UniqueId != null && d.UniqueId.StartsWith(id))
                                    .OrderByDescending(d => d.Id)
                                    .Select(d => d.UniqueId)
                                    .FirstOrDefaultAsync();
                                break;

                            case "highestqualification":
                            case "highest_qualification":
                            case "highestqualifications":
                                maxUniqueId = await context.HighestQualifications
                                    .Where(hq => hq.UniqueId != null && hq.UniqueId.StartsWith(id))
                                    .OrderByDescending(hq => hq.Id)
                                    .Select(hq => hq.UniqueId)
                                    .FirstOrDefaultAsync();
                                break;

                            case "rolehierarchy":
                            case "role_hierarchy":
                            case "rolehierarchies":
                                maxUniqueId = await context.RoleHierarchies
                                    .Where(rh => rh.UniqueId != null && rh.UniqueId.StartsWith(id))
                                    .OrderByDescending(rh => rh.Id)
                                    .Select(rh => rh.UniqueId)
                                    .FirstOrDefaultAsync();
                                break;

                            case "organization":
                            case "organizations":
                                maxUniqueId = await context.Organizations
                                    .Where(o => o.UniqueId != null && o.UniqueId.StartsWith(id))
                                    .OrderByDescending(o => o.Id)
                                    .Select(o => o.UniqueId)
                                    .FirstOrDefaultAsync();
                                break;

                            case "users":
                            case "user":
                                maxUniqueId = await context.Users
                                    .Where(u => u.UniqueId != null && u.UniqueId.StartsWith(id))
                                    .OrderByDescending(u => u.Id)
                                    .Select(u => u.UniqueId)
                                    .FirstOrDefaultAsync();
                                break;

                            default:
                                // For unknown tables, throw exception to force explicit table handling
                                throw new NotSupportedException($"Table '{tableName}' is not supported for unique ID generation. Please add it to the switch statement in GeneralHelper.UniqueIdGeneratorAsync");
                        }

                        if (!string.IsNullOrEmpty(maxUniqueId))
                        {
                            var parts = maxUniqueId.Split(new[] { id + "/" }, StringSplitOptions.None);
                            if (parts.Length > 1 && int.TryParse(parts[1], out int serialNo))
                            {
                                id += "/" + (serialNo + 1).ToString("000");
                            }
                            else
                            {
                                id += "/001";
                            }
                        }
                        else
                        {
                            id += "/001";
                        }
                    }
                }

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetCapitalLetters(string module)
        {
            if (string.IsNullOrEmpty(module))
                return "";

            return new string(module
                .Split(' ')
                .Where(word => word.Length > 0)
                .Select(word => char.ToUpper(word[0]))
                .ToArray());
        }

        private static string GetInitials(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "";

            return new string(name
                .Split(' ')
                .Where(word => word.Length > 0)
                .Select(word => char.ToUpper(word[0]))
                .ToArray());
        }

        private static string GetFinancialYear(DateTime date)
        {
            int year = date.Year;
            // Financial year starts from April 1st
            // If date is on or after April 1st, use current year + next year
            // Otherwise, use previous year + current year
            if (date.Month >= 4)
            {
                // Date is on or after April 1st
                return year.ToString().Substring(2) + (year + 1).ToString().Substring(2);
            }
            else
            {
                // Date is before April 1st
                return (year - 1).ToString().Substring(2) + year.ToString().Substring(2);
            }
        }

        public static async Task<List<Department>> GetOrganizationAccordingToDepartmentAsync(
            ApplicationDbContext context,
            int departmentId)
        {
            try
            {
                return await context.Department
                    .Where(d => d.Id == departmentId && d.Deleted == false)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<Role>> CheckNameInOrganizationAsync(
            ApplicationDbContext context,
            string name,
            int organizationId)
        {
            try
            {
                return await context.Roles
                    .Where(r => r.Name == name && r.Deleted == false && r.OrganizationId == organizationId)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task InsertActivityLogAsync(
            ApplicationDbContext context,
            int createdBy,
            string status,
            string module,
            object id)
        {
            try
            {
                status = status.ToLower();
                string message = "";
                return;
                switch (status)
                {
                    case "update":
                        message = $"{module} updated successfully with id {id}";
                        break;
                    case "create":
                        message = $"New {module} created successfully with id {id}";
                        break;
                    case "delete":
                        message = $"{module} deleted successfully with id {id}";
                        break;
                    case "approved":
                        message = $"{module} approved successfully with id {id}";
                        break;
                    case "reject":
                        message = $"{module} reject successfully with id {id}";
                        break;
                    default:
                        message = $"{module} {status} successfully with id {id}";
                        break;
                }

                var activityLog = new ActivityLog
                {
                    CreatedBy = createdBy,
                    Status = status,
                    Module = module,
                    Message = message,
                    Deleted = false,
                    CreatedAt = DateTime.Now
                };

                context.ActivityLogs.Add(activityLog);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<string?> GetFieldValueByIdAsync(
            ApplicationDbContext context,
            string tableName,
            string fieldName,
            int id)
        {
            try
            {
                switch (tableName.ToLower())
                {
                    case "roles":
                        var role = await context.Roles.FindAsync(id);
                        if (role == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "organization" => role.OrganizationId?.ToString(),
                            "organizationid" => role.OrganizationId?.ToString(),
                            _ => null
                        };

                    case "skills":
                        var skill = await context.Skills.FindAsync(id);
                        if (skill == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "organization" => skill.Organization,
                            _ => null
                        };

                    case "licence":
                    case "licenses":
                        var license = await context.Licences.FindAsync(id);
                        if (license == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "organization" => license.Organization,
                            _ => null
                        };

                    case "department":
                    case "departments":
                        var department = await context.Department.FindAsync(id);
                        if (department == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "organization" => department.OrganizationId?.ToString(),
                            "organizationid" => department.OrganizationId?.ToString(),
                            _ => null
                        };

                    case "highestqualification":
                    case "highest_qualification":
                    case "highestqualifications":
                        var qualification = await context.HighestQualifications.FindAsync(id);
                        if (qualification == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "organization" => qualification.Organization,
                            _ => null
                        };

                    case "rolehierarchy":
                    case "role_hierarchy":
                    case "rolehierarchies":
                        var roleHierarchy = await context.RoleHierarchies.FindAsync(id);
                        if (roleHierarchy == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "organization" => roleHierarchy.Organization,
                            _ => null
                        };

                    case "organization":
                    case "organizations":
                        var organization = await context.Organizations.FindAsync(id);
                        if (organization == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "organization" => organization.Id.ToString(),
                            "id" => organization.Id.ToString(),
                            _ => null
                        };

                    case "users":
                    case "user":
                        var user = await context.Users.FindAsync(id);
                        if (user == null) return null;
                        return fieldName.ToLower() switch
                        {
                            "my_organization" => user.MyOrganization?.ToString(),
                            "myorganization" => user.MyOrganization?.ToString(),
                            "organization" => user.MyOrganization?.ToString(),
                            _ => null
                        };

                    default:
                        // For unknown tables, return null (should be handled by caller)
                        return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private class IdResult
        {
            public string Value { get; set; } = "";
        }
    }

}
