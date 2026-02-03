using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Application.Services.DepartmentService;
using VuSaniClientApi.Application.Services.EmployeeService;
using VuSaniClientApi.Application.Services.HighestQualificationService;
using VuSaniClientApi.Application.Services.LicenseService;
using VuSaniClientApi.Application.Services.LoginService;
using VuSaniClientApi.Application.Services.MasterDataService;
using VuSaniClientApi.Application.Services.OrganizationService;
using VuSaniClientApi.Application.Services.PermissionService;
using VuSaniClientApi.Application.Services.RoleHierarchyService;
using VuSaniClientApi.Application.Services.RoleService;
using VuSaniClientApi.Application.Services.SkillService;
using VuSaniClientApi.Application.Services.SoftwareAccessService;
using VuSaniClientApi.Application.Services.SoftwareAccessRequestService;

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
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ILicenseService, LicenseService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IHighestQualificationService, HighestQualificationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IMasterDataService, MasterDataService>();
            services.AddScoped<ISoftwareAccessService, SoftwareAccessService>();
            services.AddScoped<ISoftwareAccessRequestService, SoftwareAccessRequestService>();
            return services;
        }
    }
}
