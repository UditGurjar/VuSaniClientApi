using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Application.Services.LoginService;
using VuSaniClientApi.Application.Services.OrganizationService;
using VuSaniClientApi.Application.Services.PermissionService;
using VuSaniClientApi.Application.Services.RoleHierarchyService;
using VuSaniClientApi.Application.Services.RoleService;

namespace VuSaniClientApi.Application
{
    public static  class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISidebarService, SidebarService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IRoleHierarchyService, RoleHierarchyService>();
            return services;
        }
    }
}
