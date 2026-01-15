using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class RoleHierarchySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleHierarchy>().HasData(

                new RoleHierarchy
                {
                    Id = 1,
                    Level = "Corporate/Executive Level",
                    Name = "Board of Directors",
                    Description = "Elected group responsible for governance...",
                    Department = null,
                    Organization = "[3,2,1]",
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    UpdatedBy = 1,
                    Editable = 1,
                    UniqueId = "H&HG/RH/2425/0001"
                },

                new RoleHierarchy
                {
                    Id = 2,
                    Level = "Corporate/Executive Level",
                    Name = "Chairperson of the Board",
                    Description = "Leads the board, ensures board effectiveness...",
                    Department = null,
                    Organization = "[3,2,1]",
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    UpdatedBy = 1,
                    Editable = 1,
                    UniqueId = "H&HG/RH/2425/0002"
                },

                new RoleHierarchy
                {
                    Id = 3,
                    Level = "Corporate/Executive Level",
                    Name = "Chief Executive Officer (CEO)",
                    Description = "Highest-ranking executive managing overall operations...",
                    Department = null,
                    Organization = "[3,2,1]",
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    UpdatedBy = 1,
                    Editable = 1,
                    UniqueId = "H&HG/RH/2425/0003"
                },

                new RoleHierarchy
                {
                    Id = 4,
                    Level = "Corporate/Executive Level",
                    Name = "President",
                    Description = "Sometimes separate from CEO; handles strategic leadership...",
                    Department = null,
                    Organization = "[3,2,1]",
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    UpdatedBy = 1,
                    Editable = 1,
                    UniqueId = "H&HG/RH/2425/0004"
                },

                new RoleHierarchy
                {
                    Id = 5,
                    Level = "Corporate/Executive Level",
                    Name = "Chief Operating Officer (COO)",
                    Description = "Manages day-to-day operations and strategy execution...",
                    Department = null,
                    Organization = "[3,2,1]",
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 32),
                    UpdatedBy = 1,
                    Editable = 1,
                    UniqueId = "H&HG/RH/2425/0005"
                }
            );


            //many to many  relationship seeding

            modelBuilder.Entity<OrganizationRoleHierarchy>().HasData(
      new OrganizationRoleHierarchy { OrganizationId = 1, RoleHierarchyId = 2 },
      new OrganizationRoleHierarchy { OrganizationId = 2, RoleHierarchyId = 2 },
      new OrganizationRoleHierarchy { OrganizationId = 3, RoleHierarchyId = 2 },

      new OrganizationRoleHierarchy { OrganizationId = 1, RoleHierarchyId = 3 },
      new OrganizationRoleHierarchy { OrganizationId = 2, RoleHierarchyId = 3 },
      new OrganizationRoleHierarchy { OrganizationId = 3, RoleHierarchyId = 3 }
  );

        }
    }
}


