using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var hashedPassword = PasswordHelper.ComputeHash("Super@123", "SHA1", null);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UniqueId = "SR0001",
                UniqueIdStatus = "automatic",
                Name = "Mirriam",
                Surname = "Tenyane",
                Email = "mirriam@harmonyandmotors.com",
                Password = hashedPassword,
                Profile = "profile/1717141951646_download.jfif",
                IdNumber = "95021228928288",
                JoiningDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                RaceId = 1,
                HighestQualificationId=1,
                EmployeeTypeId = 11,
                NameOfQualification = "Graduation",
                CountryId= 205,
                StateId= 3904,
                CityId= 108956,
                RoleId = 1,
                Department = 1,
                MyOrganization = 1,
                OrganizationId=1,
                Accountability = "[{\"accountability\":\"Accountability asdkfjhaklsdfas...\"}]",
                OrganizationAccess = "[1,2,3]",
                Skills = "1",
                Permission = "[{\"sidebarId\":1,\"permissions\":{\"1\":{\"view\":true}}}]",
                ViewType = "all",
                IsSuperAdmin = 1,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = 1,
                UnifiedUserUiqueId = "UIH-1052"
            });
        }
    }
}
