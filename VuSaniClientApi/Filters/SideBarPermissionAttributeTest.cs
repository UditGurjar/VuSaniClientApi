using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Infrastructure.Repositories.CommonPermissionRepository;
using static VuSaniClientApi.Models.Helpers.Permissions;

namespace VuSaniClientApi.Filters
{
    public class SideBarPermissionAttributeTest : Attribute, IAsyncActionFilter
    {
        private readonly string _accessType;    
        private readonly int _moduleId;
        private readonly string _tableName;
        private readonly string _field;

        public SideBarPermissionAttributeTest(string accessType, int moduleId, string tableName, string field = "organization")
        {
            _accessType = accessType.ToLower(); // normalize
            _moduleId = moduleId;
            _tableName = tableName;
            _field = field;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                var db = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
                var user = context.HttpContext.User;

                // Get userId from JWT claims
                var sessionIdClaim = user.Claims.FirstOrDefault(x => x.Type == "sessionid")?.Value;
                if (!int.TryParse(sessionIdClaim, out int userId))
                {
                    context.Result = new JsonResult(new { status = false, message = "Unauthorized: Invalid session" }) { StatusCode = 401 };
                    return;
                }

                // Auto-update tableName for "view"
                if (_accessType == "view" && !string.IsNullOrEmpty(_tableName))
                {
                    var sidebar = await db.Sidebars.FirstOrDefaultAsync(x => x.Id == _moduleId);
                    if (sidebar != null && string.IsNullOrEmpty(sidebar.TableName))
                    {
                        sidebar.TableName = _tableName;
                        await db.SaveChangesAsync();
                    }
                }

                // Fetch user permissions
                var userData = await db.Users
                    .Where(x => x.Id == userId)
                    .Select(x => new { x.Permission, x.Organization })
                    .FirstOrDefaultAsync();

                if (userData == null || string.IsNullOrEmpty(userData.Permission))
                {
                    context.Result = new JsonResult(new { status = false, message = "You don't have permission" }) { StatusCode = 401 };
                    return;
                }

                var permissions = JsonSerializer.Deserialize<List<UserPermission>>(userData.Permission,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<UserPermission>();

                if (!permissions.Any())
                {
                    context.Result = new JsonResult(new { status = false, message = "You don't have permission" }) { StatusCode = 401 };
                    return;
                }

                var modulePermission = permissions.FirstOrDefault(p => p.SidebarId == _moduleId);
                if (modulePermission == null)
                {
                    context.Result = new JsonResult(new { status = false, message = $"No access to module {_moduleId}" }) { StatusCode = 401 };
                    return;
                }

                // ✅ Resolve dynamic access type for common API
                string resolvedAccessType = _accessType;

                if (_accessType == "create-update")
                {
                    var bodyObj = context.ActionArguments.Values.FirstOrDefault();

                    if (bodyObj != null)
                    {
                        var idProp = bodyObj.GetType().GetProperty("Id");

                        if (idProp != null)
                        {
                            var idValue = idProp.GetValue(bodyObj);

                            resolvedAccessType = (idValue == null || Convert.ToInt32(idValue) == 0)
                                ? "create"
                                : "edit";
                        }
                    }
                }

                // Handle permissions based on access type
                switch (resolvedAccessType)
                {
                    case "view":
                        var viewOrgs = modulePermission.Permissions
                            .Where(x => x.Value.View)
                            .Select(x => int.Parse(x.Key))
                            .ToList();
                        if (!viewOrgs.Any())
                        {
                            context.Result = new JsonResult(new { status = false, message = "No view permission" }) { StatusCode = 401 };
                            return;
                        }
                        context.HttpContext.Items["allowedOrganizations"] = viewOrgs;
                        break;

                    case "create":
                        var createOrgs = modulePermission.Permissions
                            .Where(x => x.Value.Create)
                            .Select(x => int.Parse(x.Key))
                            .ToList();
                        if (!createOrgs.Any())
                        {
                            context.Result = new JsonResult(new { status = false, message = "No create permission" }) { StatusCode = 401 };
                            return;
                        }
                        context.HttpContext.Items["allowedOrganizations"] = createOrgs;
                        break;

                    case "edit":
                    case "delete":

                        string recordId = null;

                        // 1️⃣ Try get id from route
                        if (context.RouteData.Values.ContainsKey("id"))
                        {
                            recordId = context.RouteData.Values["id"]?.ToString();
                        }

                        // 2️⃣ If not in route, try get id from body (for create-update APIs)
                        if (string.IsNullOrEmpty(recordId))
                        {
                            var bodyObj = context.ActionArguments.Values.FirstOrDefault();
                            if (bodyObj != null)
                            {
                                var idProp = bodyObj.GetType().GetProperty("Id");
                                if (idProp != null)
                                {
                                    recordId = idProp.GetValue(bodyObj)?.ToString();
                                }
                            }
                        }

                        if (string.IsNullOrEmpty(recordId) || recordId == "0")
                        {
                            context.Result = new JsonResult(new { status = false, message = "Valid Id is required" }) { StatusCode = 400 };
                            return;
                        }
                       
                        var permissionRepo = context.HttpContext.RequestServices
    .GetRequiredService<ICommonPermissionRepository>();

                        var orgIds = await permissionRepo.GetOrganizationsAsync(_tableName, int.Parse(recordId));

                        if (!orgIds.Any())
                        {
                            context.Result = new JsonResult(new { status = false, message = "Record not found" })
                            { StatusCode = 404 };
                            return;
                        }

                        bool hasPermission = orgIds.Any(orgId =>
                            modulePermission.Permissions.ContainsKey(orgId.ToString()) &&
                            (resolvedAccessType == "edit"
                                ? modulePermission.Permissions[orgId.ToString()].Edit
                                : modulePermission.Permissions[orgId.ToString()].Delete)
                        );

                        if (!hasPermission)
                        {
                            context.Result = new JsonResult(new
                            {
                                status = false,
                                message = $"No {resolvedAccessType} permission for this record"
                            })
                            { StatusCode = 401 };
                            return;
                        }

                        break;


                    default:
                        context.Result = new JsonResult(new { status = false, message = "Invalid access type" }) { StatusCode = 400 };
                        break;
                }

                await next();

            }
            catch (Exception ex)
            {
                context.Result = new JsonResult(new { status = false, message = ex.Message }) { StatusCode = 500 };
            }
        }
    }

}

