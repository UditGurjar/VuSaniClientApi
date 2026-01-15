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
                     
                    CreatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    CreatedBy = 1,
                    UpdatedAt = DateTime.Parse("2025-08-11 10:23:03"),
                    UniqueId = "HAM/ROL/2526/001"
                },
                new Role
                {
                    Id = 2,
                    Name = "Technical Support and Resolution",
                    OrganizationId = 1,
                     
                    UniqueId = "HAM/ROL/2526/002"
                },
                new Role
                {
                    Id = 3,
                    Name = "Managing Director",
                    OrganizationId = 1,
                     
                    UniqueId = "HAM/ROL/2526/003"
                }
            // add others if needed
            );
        }
    }

}
