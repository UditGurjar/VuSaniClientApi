//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using System.Text.Json;
//using VuSaniClientApi.Infrastructure.DBContext;

//namespace VuSaniClientApi.Filters
//{
//    public class SideBarPermissionAttributeTest : Attribute, IAsyncAuthorizationFilter
//    {
//        private readonly string _accessType;
//        private readonly int _moduleId;
//        private readonly string _tableName;
//        private readonly string _field;

//        public SideBarPermissionAttributeTest(string accessType, int moduleId, string tableName, string field = "organization")
//        {
//            _accessType = accessType;
//            _moduleId = moduleId;
//            _tableName = tableName;
//            _field = field;
//        }
//        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
//        {
//            try
//            {
//                var db = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
//                var user = context.HttpContext.User;

//                var sessionIdClaim = user.Claims.FirstOrDefault(x => x.Type == "sessionid")?.Value;
//                if (string.IsNullOrEmpty(sessionIdClaim))
//                {
//                    context.Result = new UnauthorizedResult();
//                    return;
//                }

//                int userId = Convert.ToInt32(sessionIdClaim);

//                /* ---- Update sidebar table_name on view (same as Node) ---- */
//                if (_accessType == "view" && !string.IsNullOrEmpty(_tableName))
//                {
//                    var sidebar = await db.Sidebars.FirstOrDefaultAsync(x => x.Id == _moduleId);
//                    if (sidebar != null && string.IsNullOrEmpty(sidebar.TableName))
//                    {
//                        sidebar.TableName = _tableName;
//                        await db.SaveChangesAsync();
//                    }
//                }

//                /* ---- Get user permissions ---- */
//                var userData = await db.Users
//                    .Where(x => x.Id == userId)
//                    .Select(x => new { x.Permission, x.Organization })
//                    .FirstOrDefaultAsync();

//                if (userData == null || string.IsNullOrEmpty(userData.Permission))
//                {
//                    context.Result = new JsonResult(new { status = false, message = "You don't have permission" }) { StatusCode = 401 };
//                    return;
//                }

//                // Deserialize the permission JSON into a structured list
//                var permissions = JsonSerializer.Deserialize<List<UserPermission>>(userData.Permission,
//                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<UserPermission>();
//                if (permissions == null || permissions.Count == 0)
//                {
//                    context.Result = new JsonResult(new { status = false, message = "You don't have permission" }) { StatusCode = 401 };
//                    return;
//                }

//                var sidebarData = await db.Sidebars.FirstOrDefaultAsync(x => x.Id == _moduleId);
//                if (sidebarData?.Path?.Contains("/settings") == true &&
//                    !sidebarData.Path.Contains("/settings/department") &&
//                    !sidebarData.Path.Contains("/settings/teams"))
//                {
//                    context.HttpContext.Items["settings"] = true;
//                }

//                bool sidebarExists = false;

//                foreach (var p in permissions)
//                {
//                    if (p.SidebarId == _moduleId)
//                    {
//                        sidebarExists = true;

//                        if (_accessType == "view")
//                        {
//                            var allowedOrgs = p.Permissions
//                                .Where(x => x.Value.View)
//                                .Select(x => int.Parse(x.Key))
//                                .ToList();

//                            context.HttpContext.Items["additionalData"] = allowedOrgs;
//                            return;
//                        }

//                        if (_accessType == "create")
//                        {
//                            var body = await context.HttpContext.Request.ReadFromJsonAsync<Dictionary<string, object>>();

//                            var allowedOrgs = p.Permissions
//                                .Where(x => x.Value.Create)
//                                .Select(x => int.Parse(x.Key))
//                                .ToList();

//                            if (!allowedOrgs.Any())
//                            {
//                                context.Result = new JsonResult(new { status = false, message = "You don't have permission to access this" }) { StatusCode = 401 };
//                                return;
//                            }

//                            context.HttpContext.Items["allowedOrganizations"] = allowedOrgs;
//                            return;
//                        }

//                        if (_accessType == "edit" || _accessType == "delete")
//                        {
//                            var routeId = context.RouteData.Values["id"]?.ToString();
//                            if (string.IsNullOrEmpty(routeId))
//                            {
//                                context.Result = new JsonResult(new { status = false, message = "Id is required" }) { StatusCode = 400 };
//                                return;
//                            }

//                            var sql = $"SELECT {_field} FROM {_tableName} WHERE Id = @id";
//                            var orgResult = await db.Database.SqlQueryRaw<string>(sql, new SqlParameter("@id", routeId)).FirstAsync();

//                            var orgIds = JsonSerializer.Deserialize<List<int>>(orgResult);

//                            bool hasPermission = orgIds.Any(orgId =>
//                                p.Permissions.ContainsKey(orgId.ToString()) &&
//                                (_accessType == "edit"
//                                    ? p.Permissions[orgId.ToString()].Edit
//                                    : p.Permissions[orgId.ToString()].Delete)
//                            );

//                            if (!hasPermission)
//                            {
//                                context.Result = new JsonResult(new
//                                {
//                                    status = false,
//                                    message = $"You don't have permission to {_accessType} this record"
//                                })
//                                { StatusCode = 401 };

//                                return;
//                            }

//                            return;
//                        }
//                    }
//                }

//                if (!sidebarExists)
//                {
//                    context.Result = new JsonResult(new
//                    {
//                        status = false,
//                        message = $"You don't have permission to access this module or module is deleted. ModuleId: {_moduleId}"
//                    })
//                    { StatusCode = 401 };
//                }
//            }
//            catch (Exception ex)
//            {
//                context.Result = new JsonResult(new { status = false, message = ex.Message }) { StatusCode = 500 };
//            }
//        }
//    }
//}

//public class UserPermission
//{
//    public int SidebarId { get; set; }
//    public Dictionary<string, PermissionActions> Permissions { get; set; } = new();
//}

//public class PermissionActions
//{
//    public bool View { get; set; }
//    public bool Create { get; set; }
//    public bool Edit { get; set; }
//    public bool Delete { get; set; }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;
using VuSaniClientApi.Infrastructure.DBContext;

namespace VuSaniClientApi.Filters
{
    public class SideBarPermissionAttributeTest : Attribute, IAsyncAuthorizationFilter
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

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
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

                // Handle permissions based on access type
                switch (_accessType)
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
                        var routeId = context.RouteData.Values["id"]?.ToString();
                        if (string.IsNullOrEmpty(routeId))
                        {
                            context.Result = new JsonResult(new { status = false, message = "Id is required" }) { StatusCode = 400 };
                            return;
                        }

                        // Fetch organization(s) of record
                        var sql = $"SELECT {_field} FROM {_tableName} WHERE Id = @id";
                        var orgResult = await db.Database.SqlQueryRaw<string>(sql, new SqlParameter("@id", routeId)).FirstOrDefaultAsync();
                        if (string.IsNullOrEmpty(orgResult))
                        {
                            context.Result = new JsonResult(new { status = false, message = "Record not found" }) { StatusCode = 404 };
                            return;
                        }

                        var orgIds = JsonSerializer.Deserialize<List<int>>(orgResult) ?? new List<int>();
                        bool hasPermission = orgIds.Any(orgId =>
                            modulePermission.Permissions.ContainsKey(orgId.ToString()) &&
                            (_accessType == "edit"
                                ? modulePermission.Permissions[orgId.ToString()].Edit
                                : modulePermission.Permissions[orgId.ToString()].Delete));

                        if (!hasPermission)
                        {
                            context.Result = new JsonResult(new { status = false, message = $"No {_accessType} permission for this record" }) { StatusCode = 401 };
                            return;
                        }
                        break;

                    default:
                        context.Result = new JsonResult(new { status = false, message = "Invalid access type" }) { StatusCode = 400 };
                        break;
                }
            }
            catch (Exception ex)
            {
                context.Result = new JsonResult(new { status = false, message = ex.Message }) { StatusCode = 500 };
            }
        }
    }

    public class UserPermission
    {
        public int SidebarId { get; set; }
        public Dictionary<string, PermissionActions> Permissions { get; set; } = new();
    }

    public class PermissionActions
    {
        public bool View { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }
}

