using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class RoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Administrator",
                    Description = "<p>Administrator</p>",
                    OrganizationId = 1,
                    YearOfExperience = "1-2",
                    QualificationId = 8,
                    ReportToRole = "3",
                    CreatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    CreatedBy = 1,
                    UpdatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    UniqueId = "HAM/ROL/2526/001",
                    Skills = "1,2,3",
                    License = "1",
                    Hierarchy = 1,
                },
                new Role
                {
                    Id = 2,
                    Name = "Technical Support and Resolution",
                    OrganizationId = 1,
                    YearOfExperience = "5-6",
                    QualificationId = 5,
                    ReportToRole = "3",
                    CreatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    CreatedBy = 1,
                    UpdatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    UniqueId = "HAM/ROL/2526/002",
                    Skills = "1,2,3",
                    License = "2,3",
                    Hierarchy = 3,

                },
                new Role
                {
                    Id = 3,
                    Name = "Managing Director",
                    OrganizationId = 1,
                    YearOfExperience = "5-6",
                    QualificationId = 3,
                    CreatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    CreatedBy = 1,
                    UpdatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    UniqueId = "HAM/ROL/2526/003",
                    Skills = "4,5,6",
                    License = "1,2,3",
                    Hierarchy = 5,


                }
            // add others if needed
            );
        }
    }

}
