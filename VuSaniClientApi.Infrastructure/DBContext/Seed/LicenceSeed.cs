using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class LicenceSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Licence>().HasData(

                new Licence
                {
                    Id = 1,
                    Name = "SANS Compliance Certificate",
                    Description = "<p>Proof that products or systems comply...",
                    IsStatic = 0,
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 29),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 29),
                    UpdatedBy = 1,
                    UniqueId = "HAM/LIC/2526/0243"
                },

                new Licence
                {
                    Id = 2,
                    Name = "Occupational Certificate",
                    Description = "<p>SAQA-accredited certificate for occup...",
                    IsStatic = 0,
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 29),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 29),
                    UpdatedBy = 1,
                    UniqueId = "HAM/LIC/2526/0244"
                },

                new Licence
                {
                    Id = 3,
                    Name = "GMP Certificate",
                    Description = "<p>Good Manufacturing Practice certifica...",
                    IsStatic = 0,
                     
                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 29),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 29),
                    UpdatedBy = 1,
                    UniqueId = "HAM/LIC/2526/0242"
                }
            );

            // ✅ many-to-many relationship seeding (NO duplicates)
            modelBuilder.Entity<OrganizationLicence>().HasData(

                new OrganizationLicence { LicenceId = 1, OrganizationId = 1 },
                new OrganizationLicence { LicenceId = 1, OrganizationId = 2 },
                new OrganizationLicence { LicenceId = 1, OrganizationId = 3 },

                new OrganizationLicence { LicenceId = 2, OrganizationId = 1 },
                new OrganizationLicence { LicenceId = 2, OrganizationId = 2 },

                new OrganizationLicence { LicenceId = 3, OrganizationId = 1 }
            );
        }
    }
}
