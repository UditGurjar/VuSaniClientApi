using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using VuSaniClientApi.Application.Filters;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Filters
{
    public class SidebarPermissionFilter : IAsyncActionFilter
    {
        private readonly ISidebarPermissionService _permissionService;
        private readonly string _accessType;
        private readonly int _moduleId;

        public SidebarPermissionFilter(
            ISidebarPermissionService permissionService,
            string accessType,
            int moduleId)
        {
            _permissionService = permissionService;
            _accessType = accessType;
            _moduleId = moduleId;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                var userIdClaim = context.HttpContext.User.FindFirst("sessionid")?.Value;

                if (string.IsNullOrEmpty(userIdClaim))
                {
                    context.Result = new UnauthorizedObjectResult(new { status = false, message = "Unauthorized" });
                    return;
                }

                int userId = int.Parse(userIdClaim);

                var result = await _permissionService.CheckPermissionAsync(
                    userId, _accessType, _moduleId);

                if (!result.IsAllowed)
                {
                    context.Result = new UnauthorizedObjectResult(new
                    {
                        status = false,
                        message = result.Message
                    });
                    return;
                }

                context.HttpContext.Items["additionalData"] = result.AllowedOrganizations;

                await next();
            }
            catch (Exception ex)
            {
                context.Result = new ObjectResult(new
                {
                    status = false,
                    message = ex.Message
                })
                { StatusCode = 500 };
            }
        }
    }

}
