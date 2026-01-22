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
                        // For other tables, use raw SQL
                        var sql = $"SELECT TOP 1 {key} as Value FROM {tableName} WHERE {key} LIKE '{escapedId}%' ORDER BY id DESC";
                        var maxRecords = await context.Database
                            .SqlQueryRaw<IdResult>(sql)
                            .ToListAsync();

                        if (maxRecords.Any() && !string.IsNullOrEmpty(maxRecords[0].Value))
                        {
                            var lastValue = maxRecords[0].Value;
                            var parts = lastValue.Split(new[] { id + "/" }, StringSplitOptions.None);
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

                await context.Database.ExecuteSqlRawAsync(
                    $"INSERT INTO activity_log(created_by, status, module, message) VALUES ({createdBy}, '{status}', '{module}', '{message}')");
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
