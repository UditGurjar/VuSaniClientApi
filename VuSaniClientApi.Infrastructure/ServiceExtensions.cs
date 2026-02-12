using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.GenericRepository;
using VuSaniClientApi.Infrastructure.Repositories.CommonPermissionRepository;
using VuSaniClientApi.Infrastructure.Repositories.DepartmentRepository;
using VuSaniClientApi.Infrastructure.Repositories.EmployeeRepository;
using VuSaniClientApi.Infrastructure.Repositories.HighestQualificationRepository;
using VuSaniClientApi.Infrastructure.Repositories.LicenseRepository;
using VuSaniClientApi.Infrastructure.Repositories.LoginRepository;
using VuSaniClientApi.Infrastructure.Repositories.MasterDataRepository;
using VuSaniClientApi.Infrastructure.Repositories.OrganizationRepository;
using VuSaniClientApi.Infrastructure.Repositories.PermissionsRepository;
using VuSaniClientApi.Infrastructure.Repositories.RoleHierarchyRepository;
using VuSaniClientApi.Infrastructure.Repositories.RoleRepository;
using VuSaniClientApi.Infrastructure.Repositories.SkillRepository;
using VuSaniClientApi.Infrastructure.Repositories.SoftwareAccessRequestRepository;
using VuSaniClientApi.Infrastructure.Repositories.ActivityLogRepository;
using VuSaniClientApi.Infrastructure.Repositories.AppointmentTypeRepository;
using VuSaniClientApi.Infrastructure.Repositories.HseAppointmentRepository;
using VuSaniClientApi.Infrastructure.Repositories.LocationRepository;

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
            services.AddScoped<ICommonPermissionRepository, CommonPermissionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMasterDataRepository, MasterDataRepository>();
            services.AddScoped<ISoftwareAccessRequestRepository, SoftwareAccessRequestRepository>();
            services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
            services.AddScoped<IHseAppointmentRepository, HseAppointmentRepository>();
            services.AddScoped<IAppointmentTypeRepository, AppointmentTypeRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            return services;
        }
    }
}
