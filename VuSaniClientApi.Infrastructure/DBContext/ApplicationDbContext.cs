using Microsoft.EntityFrameworkCore;
using System;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.Helpers;

namespace VuSaniClientApi.Infrastructure.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<RoleHierarchy> RoleHierarchies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<HighestQualification> HighestQualifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasOne(o => o.Parent)
                .WithMany(o => o.Children)
                .HasForeignKey(o => o.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ✅ -------- DUMMY DATA SEEDING --------
            modelBuilder.Entity<Organization>().HasData(

                new Organization
                {
                    Id = 1,
                    ParentId = 0,
                    Name = "Harmony and Motors",
                    Description = "<p>Corporate Office</p>",
                    Level = 1,
                    Deleted = 0,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:30"),
                    CreatedBy = 1,
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:30"),
                    UpdatedBy = 1,
                    BusinessLogo = "https://saapi.vusani360.africa/main_logo.png",
                    BackgroundImage = "https://saapi.vusani360.africa/main_logo.png",
                    HeaderImage = "https://saapi.vusani360.africa/main_logo.png",
                    FooterImage = "https://saapi.vusani360.africa/main_logo.png",
                    FontSize = "16",
                    PickColor = "#45c421",
                    UniqueId = "H&HG/2425/001",
                    BusinessAddress = "65 Garden Road"
                },

                new Organization
                {
                    Id = 2,
                    ParentId = 1,
                    Name = "Harmony and Properties",
                    Description = "<p>Property Division</p>",
                    Level = 2,
                    Deleted = 0,
                    CreatedAt = DateTime.Parse("2025-08-13 20:41:07"),
                    CreatedBy = 1,
                    UpdatedAt = DateTime.Parse("2025-08-13 20:41:07"),
                    UpdatedBy = 1,
                    BusinessLogo = "https://harmonyandmotors-api.vusani360.africa/org1.png",
                    BackgroundImage = "https://harmonyandmotors-api.vusani360.africa/org1.png",
                    HeaderImage = "https://harmonyandmotors-api.vusani360.africa/org1.png",
                    FooterImage = "https://harmonyandmotors-api.vusani360.africa/org1.png",
                    FontSize = "16",
                    PickColor = "#6c1d45",
                    UniqueId = "HAP/ORG/2526/002",
                    BusinessAddress = "65 Garden Road"
                },

                new Organization
                {
                    Id = 3,
                    ParentId = 1,
                    Name = "Harmony and Academy",
                    Description = "<p>Academy division</p>",
                    Level = 1,
                    Deleted = 0,
                    CreatedAt = DateTime.Parse("2025-08-18 17:17:01"),
                    CreatedBy = 1,
                    UpdatedAt = DateTime.Parse("2025-08-18 17:17:01"),
                    UpdatedBy = 1,
                    BusinessLogo = "https://harmonyandmotors-api.vusani360.africa/org2.png",
                    BackgroundImage = "https://harmonyandmotors-api.vusani360.africa/org2.png",
                    HeaderImage = "https://harmonyandmotors-api.vusani360.africa/org2.png",
                    FooterImage = "https://harmonyandmotors-api.vusani360.africa/org2.png",
                    FontSize = "16",
                    PickColor = null,
                    UniqueId = "HAA/ORG/2526/003",
                    BusinessAddress = "65 Garden Road"
                }
            );
            var hashedPassword = PasswordHelper.ComputeHash("Super@123", "SHA1", null);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,

                UniqueId = "SR0001",
                UniqueIdStatus = "automatic",

                Name = "Mirriam",
                Surname = "Tenyane",
                Email = "learn@hhacademy.africa",
                Password = hashedPassword,

                Profile = "profile/1717141951646_download.jfif",
                IdNumber = "95021228928288",

                JoiningDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,

                Race = "White",
                EmployeeType = "Permanent Employment",
                NameOfQualification = "Graduation",

                Role = 131059,
                Department = 939,
                MyOrganization = 204,

                Accountability = "[{\"accountability\":\"Accountability asdkfjhaklsdfas...\"}]",
                OrganizationAccess = "[205]",
                Skills = "[498]",

                Permission = "[{\"sidebarId\":1,\"permissions\":{\"1\":{\"view\":true}}}]",

                ViewType = "all",
                IsSuperAdmin = 1,
                Deleted = "0",

                CreatedAt = DateTime.UtcNow,
                CreatedBy = 1,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = 1,

                ClientInternalId = "H&H-CL-1015",
                UnifiedUserUiqueId = "UIH-1052"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
