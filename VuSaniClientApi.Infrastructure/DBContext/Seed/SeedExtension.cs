using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class SeedExtension
    {
        public static void ApplySeeds(this ModelBuilder modelBuilder)
        {
            LanguageSeed.Seed(modelBuilder);
            RaceSeed.Seed(modelBuilder);
            HighestQualificationSeed.Seed(modelBuilder);
            OrganizationSeed.Seed(modelBuilder);
            DepartmentSeed.Seed(modelBuilder);
            RoleHierarchySeed.Seed(modelBuilder);
            EmployeeTypeSeed.Seed(modelBuilder);
            LicenceSeed.Seed(modelBuilder);
            SkillSeed.Seed(modelBuilder);
            RoleSeed.Seed(modelBuilder);
            RelationShipSeed.Seed(modelBuilder);
            UserSeed.Seed(modelBuilder);
            NextOfKinSeed.Seed(modelBuilder);
        }
    }
}
