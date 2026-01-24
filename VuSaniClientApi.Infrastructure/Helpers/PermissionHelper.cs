using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Filters;

namespace VuSaniClientApi.Infrastructure.Helpers
{
    public static class PermissionHelper
    {
        public static async Task<(bool HasPermission, string? ErrorMessage)> CheckPermissionAsync(
            ApplicationDbContext context,
            int userId,
            string accessType,
            int moduleId,
            string tableName,
            string field = "organization",
            int? recordId = null)
        {
            try
            {
                // Fetch user permissions
                var userData = await context.Users
                    .Where(x => x.Id == userId)
                    .Select(x => new { x.Permission, x.Organization })
                    .FirstOrDefaultAsync();

                if (userData == null || string.IsNullOrEmpty(userData.Permission))
                {
                    return (false, "You don't have permission");
                }

                var permissions = JsonSerializer.Deserialize<List<UserPermission>>(userData.Permission,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<UserPermission>();

                if (!permissions.Any())
                {
                    return (false, "You don't have permission");
                }

                var modulePermission = permissions.FirstOrDefault(p => p.SidebarId == moduleId);
                if (modulePermission == null)
                {
                    return (false, $"No access to module {moduleId}");
                }

                // Handle permissions based on access type
                switch (accessType.ToLower())
                {
                    case "view":
                        var viewOrgs = modulePermission.Permissions
                            .Where(x => x.Value.View)
                            .Select(x => int.Parse(x.Key))
                            .ToList();
                        if (!viewOrgs.Any())
                        {
                            return (false, "No view permission");
                        }
                        return (true, null);

                    case "create":
                        var createOrgs = modulePermission.Permissions
                            .Where(x => x.Value.Create)
                            .Select(x => int.Parse(x.Key))
                            .ToList();
                        if (!createOrgs.Any())
                        {
                            return (false, "No create permission");
                        }
                        return (true, null);

                    case "edit":
                    case "update":
                        if (!recordId.HasValue)
                        {
                            return (false, "Id is required for edit permission");
                        }

                        // Fetch organization(s) of record using EF Core
                        var orgResult = await GeneralHelper.GetFieldValueByIdAsync(context, tableName, field, recordId.Value);
                        if (string.IsNullOrEmpty(orgResult))
                        {
                            return (false, "Record not found");
                        }

                        // Parse organization - could be a single ID or JSON array
                        List<int> orgIds = new List<int>();
                        if (orgResult.StartsWith("["))
                        {
                            // JSON array
                            orgIds = JsonSerializer.Deserialize<List<int>>(orgResult) ?? new List<int>();
                        }
                        else if (int.TryParse(orgResult, out int singleOrgId))
                        {
                            // Single organization ID
                            orgIds = new List<int> { singleOrgId };
                        }

                        bool hasPermission = orgIds.Any(orgId =>
                            modulePermission.Permissions.ContainsKey(orgId.ToString()) &&
                            modulePermission.Permissions[orgId.ToString()].Edit);

                        if (!hasPermission)
                        {
                            return (false, "No edit permission for this record");
                        }
                        return (true, null);

                    case "delete":
                        if (!recordId.HasValue)
                        {
                            return (false, "Id is required for delete permission");
                        }

                        // Fetch organization(s) of record using EF Core
                        var deleteOrgResult = await GeneralHelper.GetFieldValueByIdAsync(context, tableName, field, recordId.Value);
                        if (string.IsNullOrEmpty(deleteOrgResult))
                        {
                            return (false, "Record not found");
                        }

                        // Parse organization - could be a single ID or JSON array
                        List<int> deleteOrgIds = new List<int>();
                        if (deleteOrgResult.StartsWith("["))
                        {
                            // JSON array
                            deleteOrgIds = JsonSerializer.Deserialize<List<int>>(deleteOrgResult) ?? new List<int>();
                        }
                        else if (int.TryParse(deleteOrgResult, out int singleDeleteOrgId))
                        {
                            // Single organization ID
                            deleteOrgIds = new List<int> { singleDeleteOrgId };
                        }

                        bool hasDeletePermission = deleteOrgIds.Any(orgId =>
                            modulePermission.Permissions.ContainsKey(orgId.ToString()) &&
                            modulePermission.Permissions[orgId.ToString()].Delete);

                        if (!hasDeletePermission)
                        {
                            return (false, "No delete permission for this record");
                        }
                        return (true, null);

                    default:
                        return (false, "Invalid access type");
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}

