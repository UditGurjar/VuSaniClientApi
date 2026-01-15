using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class DepartmentSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Devs",
                    DepartmentHead = 1,
                    ParentDepartment=null,
                    Description = null,
                    OrganizationId = 1,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = 1,
                    UniqueId = "HAM/D/2526/001",
                   
                },
                new Department
                {
                    Id = 2,
                    Name = "ICT Department",
                    ParentDepartment = 1,
                    DepartmentHead = 1,
                    Description = "<h2><strong>1. Strategic Technology</strong></h2>",
                    OrganizationId = 1,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = 1,
                    UniqueId = "HAM/AT/2526/001",
                },
                new Department
                {
                    Id = 3,
                    Name = "Human Resource Department",
                    DepartmentHead = 1,
                    ParentDepartment = 2,
                    Description = "<h2><strong>1. Strategic Workforce Planning</strong></h2>",
                    OrganizationId = 1,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = 1,
                    UniqueId = "HAM/AT/2526/001",
                },
                new Department
                {
                    Id = 4,
                    Name = "SHEQ Department",
                    DepartmentHead = 1,
                    ParentDepartment = 1,

                    Description = "<p>The <strong>SHEQ Department ensures...</strong></p>",
                    OrganizationId = 1,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = 1,
                    UniqueId = "HAM/AT/2526/001",
                },
                new Department
                {
                    Id = 5,
                    Name = "Training and Development Department",
                    DepartmentHead = 1,
                    ParentDepartment = 1,
                    Description = "<p>The <strong>Training and Development Department...</strong></p>",
                    OrganizationId = 1,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = 1,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = 1,
                    UniqueId = "HAM/AT/2526/001",
                }
            );
        }
    }
}
