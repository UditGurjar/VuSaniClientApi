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
        public DbSet<RoleResponsibility> RoleResponsibilities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasOne(o => o.Parent)
                .WithMany(o => o.Children)
                .HasForeignKey(o => o.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RoleResponsibility>()
      .HasKey(rr => new { rr.RoleId, rr.ResponsibilityId });

            modelBuilder.Entity<RoleResponsibility>()
                .HasOne(rr => rr.Role)
                .WithMany(r => r.RoleResponsibilities)
                .HasForeignKey(rr => rr.RoleId);

            modelBuilder.Entity<RoleResponsibility>()
                .HasOne(rr => rr.Responsibility)
                .WithMany(r => r.RoleResponsibilities)
                .HasForeignKey(rr => rr.ResponsibilityId);
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

            modelBuilder.Entity<HighestQualification>().HasData(

        new HighestQualification
        {
            Id = 1,
            Name = "General Education and Training Certificate (GETC)",
            Description = "<p>NQF Level 1: Typically awarded after ...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0001"
        },

        new HighestQualification
        {
            Id = 2,
            Name = "National Senior Certificate (NSC)",
            Description = "<p>NQF Level 4: Also known as the matric...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0002"
        },

        new HighestQualification
        {
            Id = 3,
            Name = "Higher Certificate",
            Description = "NQF Level 5: A one-year vocational or occupational...",
            Organization = "[1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = null,
            UniqueId = "H&HG/SKI/2425/0003"
        },

        new HighestQualification
        {
            Id = 4,
            Name = "Advanced Certificate",
            Description = "NQF Level 6: Builds on a Higher Certificate or Dip...",
            Organization = "[1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = null,
            UniqueId = "H&HG/SKI/2425/0004"
        },

        new HighestQualification
        {
            Id = 5,
            Name = "National Certificate (Vocational) – NC(V)",
            Description = "<p>NQF Levels 2–4: Technical and ...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0005"
        },

        new HighestQualification
        {
            Id = 6,
            Name = "Diploma",
            Description = "<p>NQF Level 6: Typically a 2–3 y...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0006"
        },

        new HighestQualification
        {
            Id = 7,
            Name = "Advanced Diploma",
            Description = "<p>NQF Level 7: Post-diploma qualificati...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0007"
        },

        new HighestQualification
        {
            Id = 8,
            Name = "Bachelor’s Degree",
            Description = "<p>NQF Level 7: A 3–4 year underg...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0008"
        },

        new HighestQualification
        {
            Id = 9,
            Name = "Bachelor Honours Degree",
            Description = "<p>NQF Level 8: A postgraduate year of s...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0009"
        },

        new HighestQualification
        {
            Id = 10,
            Name = "Postgraduate Diploma",
            Description = "<p>NQF Level 8: A vocational or professi...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0010"
        },

        new HighestQualification
        {
            Id = 11,
            Name = "Master’s Degree",
            Description = "<p>NQF Level 9: A postgraduate academic ...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0011"
        },

        new HighestQualification
        {
            Id = 12,
            Name = "Doctoral Degree (PhD or DTech)",
            Description = "<p>NQF Level 10: The highest academic qu...</p>",
            Organization = "[3,2,1]",
            Deleted = 0,
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            UpdatedBy = 1,
            UniqueId = "H&HG/SKI/2425/0012"
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

                RoleId = 1,
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


            //add responsibility
             modelBuilder.Entity<Responsibility>().HasData(
        new Responsibility
        {
            Id = 1,
            Name = "Technical Issues",
            Description = "<p>Technical Issues</p>",
            Organization = "[1]",
            CreatedAt = new DateTime(2025, 8, 11, 10, 22, 20),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 22, 20),
            UpdatedBy = 1,
            Deleted = 0,
            UniqueId = "HAM/R/2526/001"
        },
        new Responsibility
        {
            Id = 2,
            Name = "Technical Issue Management",
            Description = "<p>Taking care of technical matters of t...</p>",
            Organization = "[1]",
            CreatedAt = new DateTime(2025, 8, 11, 10, 43, 28),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 43, 28),
            UpdatedBy = 1,
            Deleted = 0,
            UniqueId = "HAM/R/2526/002"
        },
        new Responsibility
        {
            Id = 3,
            Name = "Strategic HR Leadership",
            Description = "<p>Develops and implements HR strategies...</p>",
            Organization = "[1]",
            CreatedAt = new DateTime(2025, 8, 13, 20, 02, 55),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 13, 20, 02, 55),
            UpdatedBy = null,
            Deleted = 0,
            UniqueId = "HAM/R/2526/003"
        }
    );
            base.OnModelCreating(modelBuilder);
        }
    }
}
