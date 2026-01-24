using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.GenericRepository;
using VuSaniClientApi.Infrastructure.Repositories.LoginRepository;
using VuSaniClientApi.Infrastructure.Repositories.OrganizationRepository;
using VuSaniClientApi.Infrastructure.Repositories.PermissionsRepository;
using VuSaniClientApi.Infrastructure.Repositories.RoleHierarchyRepository;
using VuSaniClientApi.Infrastructure.Repositories.RoleRepository;
using VuSaniClientApi.Infrastructure.Repositories.SkillRepository;
using VuSaniClientApi.Infrastructure.Repositories.LicenseRepository;
using VuSaniClientApi.Infrastructure.Repositories.DepartmentRepository;
using VuSaniClientApi.Infrastructure.Repositories.HighestQualificationRepository;

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
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IRoleHierarchyRepository, RoleHierarchyRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IHighestQualificationRepository, HighestQualificationRepository>();

            return services;
        }
    }
}
