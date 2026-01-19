using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Application.Services.LoginService;
using VuSaniClientApi.Application.Services.PermissionService;

namespace VuSaniClientApi.Application
{
    public static  class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISidebarService, SidebarService>();
            return services;
        }
    }
}
