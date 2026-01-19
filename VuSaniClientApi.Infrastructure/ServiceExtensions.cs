using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.GenericRepository;
using VuSaniClientApi.Infrastructure.Repositories.LoginRepository;
using VuSaniClientApi.Infrastructure.Repositories.PermissionsRepository;
using VuSaniClientApi.Infrastructure.Repositories.RoleRepository;

namespace VuSaniClientApi.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ISidebarRepository, SidebarRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
