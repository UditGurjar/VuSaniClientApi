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
      
        public DbSet<HighestQualification> HighestQualifications { get; set; }

        // New join table DbSets
     
        public DbSet<OrganizationLicence> OrganizationLicences { get; set; }
        public DbSet<OrganizationRoleHierarchy> OrganizationRoleHierarchies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<RelationShip> RelationShips { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<ReasonForInactive> ReasonForInactives { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Disability> Disabilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
        new Gender { Id = 1, Name = "Male" },
        new Gender { Id = 2, Name = "Female" },
        new Gender { Id = 3, Name = "Other" },
        new Gender { Id = 4, Name = "Prefer not to say" }
    );

            modelBuilder.Entity<Organization>()
                .HasOne(o => o.Parent)
                .WithMany(o => o.Children)
                .HasForeignKey(o => o.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Organization <-> Licence
            modelBuilder.Entity<OrganizationLicence>()
                .HasKey(ol => new { ol.OrganizationId, ol.LicenceId });
            modelBuilder.Entity<OrganizationLicence>()
                .HasOne(ol => ol.Organization)
                .WithMany(o => o.OrganizationLicences)
                .HasForeignKey(ol => ol.OrganizationId);
            modelBuilder.Entity<OrganizationLicence>()
                .HasOne(ol => ol.Licence)
                .WithMany(l => l.OrganizationLicences)
                .HasForeignKey(ol => ol.LicenceId);

            // Organization <-> RoleHierarchy
            modelBuilder.Entity<OrganizationRoleHierarchy>()
                .HasKey(orh => new { orh.OrganizationId, orh.RoleHierarchyId });
            modelBuilder.Entity<OrganizationRoleHierarchy>()
                .HasOne(orh => orh.Organization)
                .WithMany(o => o.OrganizationRoleHierarchies)
                .HasForeignKey(orh => orh.OrganizationId);
            modelBuilder.Entity<OrganizationRoleHierarchy>()
                .HasOne(orh => orh.RoleHierarchy)
                .WithMany(rh => rh.OrganizationRoleHierarchies)
                .HasForeignKey(orh => orh.RoleHierarchyId);


            //// ✅ -------- DUMMY DATA SEEDING --------
            //modelBuilder.Entity<Organization>().HasData(

            //    new Organization
            //    {
            //        Id = 1,
            //        ParentId = 0,
            //        Name = "Harmony and Motors",
            //        Description = "<p>Corporate Office</p>",
            //        Level = 1,
            //        Deleted = 0,
            //        CreatedAt = DateTime.Parse("2025-08-11 10:03:30"),
            //        CreatedBy = 1,
            //        UpdatedAt = DateTime.Parse("2025-08-11 10:03:30"),
            //        UpdatedBy = 1,
            //        BusinessLogo = "https://saapi.vusani360.africa/main_logo.png",
            //        BackgroundImage = "https://saapi.vusani360.africa/main_logo.png",
            //        HeaderImage = "https://saapi.vusani360.africa/main_logo.png",
            //        FooterImage = "https://saapi.vusani360.africa/main_logo.png",
            //        FontSize = "16",
            //        PickColor = "#45c421",
            //        UniqueId = "H&HG/2425/001",
            //        BusinessAddress = "65 Garden Road"
            //    },

            //    new Organization
            //    {
            //        Id = 2,
            //        ParentId = 1,
            //        Name = "Harmony and Properties",
            //        Description = "<p>Property Division</p>",
            //        Level = 2,
            //        Deleted = 0,
            //        CreatedAt = DateTime.Parse("2025-08-13 20:41:07"),
            //        CreatedBy = 1,
            //        UpdatedAt = DateTime.Parse("2025-08-13 20:41:07"),
            //        UpdatedBy = 1,
            //        BusinessLogo = "https://harmonyandmotors-api.vusani360.africa/org1.png",
            //        BackgroundImage = "https://harmonyandmotors-api.vusani360.africa/org1.png",
            //        HeaderImage = "https://harmonyandmotors-api.vusani360.africa/org1.png",
            //        FooterImage = "https://harmonyandmotors-api.vusani360.africa/org1.png",
            //        FontSize = "16",
            //        PickColor = "#6c1d45",
            //        UniqueId = "HAP/ORG/2526/002",
            //        BusinessAddress = "65 Garden Road"
            //    },

            //    new Organization
            //    {
            //        Id = 3,
            //        ParentId = 1,
            //        Name = "Harmony and Academy",
            //        Description = "<p>Academy division</p>",
            //        Level = 1,
            //        Deleted = 0,
            //        CreatedAt = DateTime.Parse("2025-08-18 17:17:01"),
            //        CreatedBy = 1,
            //        UpdatedAt = DateTime.Parse("2025-08-18 17:17:01"),
            //        UpdatedBy = 1,
            //        BusinessLogo = "https://harmonyandmotors-api.vusani360.africa/org2.png",
            //        BackgroundImage = "https://harmonyandmotors-api.vusani360.africa/org2.png",
            //        HeaderImage = "https://harmonyandmotors-api.vusani360.africa/org2.png",
            //        FooterImage = "https://harmonyandmotors-api.vusani360.africa/org2.png",
            //        FontSize = "16",
            //        PickColor = null,
            //        UniqueId = "HAA/ORG/2526/003",
            //        BusinessAddress = "65 Garden Road"
            //    }
            //);

            //modelBuilder.Entity<HighestQualification>().HasData(
            //    new HighestQualification
            //    {
            //        Id = 1,
            //        Name = "General Education and Training Certificate (GETC)",
            //        Description = "<p>NQF Level 1: Typically awarded after ...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0001"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 2,
            //        Name = "National Senior Certificate (NSC)",
            //        Description = "<p>NQF Level 4: Also known as the matric...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0002"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 3,
            //        Name = "Higher Certificate",
            //        Description = "NQF Level 5: A one-year vocational or occupational...",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = null,
            //        UniqueId = "H&HG/SKI/2425/0003"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 4,
            //        Name = "Advanced Certificate",
            //        Description = "NQF Level 6: Builds on a Higher Certificate or Dip...",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = null,
            //        UniqueId = "H&HG/SKI/2425/0004"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 5,
            //        Name = "National Certificate (Vocational) – NC(V)",
            //        Description = "<p>NQF Levels 2–4: Technical and ...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0005"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 6,
            //        Name = "Diploma",
            //        Description = "<p>NQF Level 6: Typically a 2–3 y...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0006"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 7,
            //        Name = "Advanced Diploma",
            //        Description = "<p>NQF Level 7: Post-diploma qualificati...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0007"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 8,
            //        Name = "Bachelor’s Degree",
            //        Description = "<p>NQF Level 7: A 3–4 year underg...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0008"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 9,
            //        Name = "Bachelor Honours Degree",
            //        Description = "<p>NQF Level 8: A postgraduate year of s...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0009"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 10,
            //        Name = "Postgraduate Diploma",
            //        Description = "<p>NQF Level 8: A vocational or professi...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0010"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 11,
            //        Name = "Master’s Degree",
            //        Description = "<p>NQF Level 9: A postgraduate academic ...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0011"
            //    },

            //    new HighestQualification
            //    {
            //        Id = 12,
            //        Name = "Doctoral Degree (PhD or DTech)",
            //        Description = "<p>NQF Level 10: The highest academic qu...</p>",
            //        Deleted = 0,
            //        CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        CreatedBy = 1,
            //        UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
            //        UpdatedBy = 1,
            //        UniqueId = "H&HG/SKI/2425/0012"
            //    }
            //);
            //// Seed OrganizationHighestQualification join rows (converted from JSON arrays)

            //// Seed Skills (principal)
            //modelBuilder.Entity<Skill>().HasData(
            //    new Skill
            //    {
            //        Id = 1,
            //        Name = "C# Programming",
            //        Description = "Core C# skill",
            //        SkillsType = "technical",
            //        IsStatic = 1,
            //        Deleted = 0,
            //        CreatedAt = DateTime.Parse("2025-08-11 10:00:00"),
            //        CreatedBy = 1,
            //        UniqueId = "SKILL/0100"
            //    },
            //    new Skill
            //    {
            //        Id = 2,
            //        Name = "Project Management",
            //        Description = "PM skill",
            //        SkillsType = "soft",
            //        IsStatic = 0,
            //        Deleted = 0,
            //        CreatedAt = DateTime.Parse("2025-08-11 10:05:00"),
            //        CreatedBy = 1,
            //        UniqueId = "SKILL/0101"
            //    }
            //);

            //// Seed Licences (principal)
            //modelBuilder.Entity<Licence>().HasData(
            //    new Licence
            //    {
            //        Id = 1,
            //        Name = "Driving Licence",
            //        Description = "Vehicle driving license",
            //        IsStatic = 1,
            //        Deleted = 0,
            //        CreatedAt = DateTime.Parse("2025-08-11 10:10:00"),
            //        CreatedBy = 1,
            //        UniqueId = "LIC/0200"
            //    }
            //);

            //// Map Licences -> Organizations
            //modelBuilder.Entity<OrganizationLicence>().HasData(
            //    new { OrganizationId = 1, LicenceId = 1 },
            //    new { OrganizationId = 3, LicenceId = 1 }
            //);

            //// Seed RoleHierarchy (principal)
            //modelBuilder.Entity<RoleHierarchy>().HasData(
            //    new RoleHierarchy { Id = 300, Name = "Junior", Level = "1", Deleted = 0, UniqueId = "RH/0300" },
            //    new RoleHierarchy { Id = 301, Name = "Senior", Level = "2", Deleted = 0, UniqueId = "RH/0301" }
            //);

            //// Map RoleHierarchy -> Organizations
            //modelBuilder.Entity<OrganizationRoleHierarchy>().HasData(
            //    new { OrganizationId = 1, RoleHierarchyId = 300 },
            //    new { OrganizationId = 2, RoleHierarchyId = 301 }
            //);


            //var hashedPassword = PasswordHelper.ComputeHash("Super@123", "SHA1", null);

            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = 1,

            //    UniqueId = "SR0001",
            //    UniqueIdStatus = "automatic",

            //    Name = "Mirriam",
            //    Surname = "Tenyane",
            //    Email = "learn@hhacademy.africa",
            //    Password = hashedPassword,

            //    Profile = "profile/1717141951646_download.jfif",
            //    IdNumber = "95021228928288",

            //    JoiningDate = DateTime.UtcNow,
            //    EndDate = DateTime.UtcNow,

            //    RaceId = 1,
            //    EmployeeType = "Permanent Employment",
            //    NameOfQualification = "Graduation",

            //    RoleId = 1,
            //    Department = 939,
            //    MyOrganization = 204,

            //    Accountability = "[{\"accountability\":\"Accountability asdkfjhaklsdfas...\"}]",
            //    OrganizationAccess = "[205]",
            //    Skills = "[498]",

            //    Permission = "[{\"sidebarId\":1,\"permissions\":{\"1\":{\"view\":true}}}]",

            //    ViewType = "all",
            //    IsSuperAdmin = 1,
            //    Deleted = "0",

            //    CreatedAt = DateTime.UtcNow,
            //    CreatedBy = 1,
            //    UpdatedAt = DateTime.UtcNow,
            //    UpdatedBy = 1,

            //    UnifiedUserUiqueId = "UIH-1052"
            //});

            base.OnModelCreating(modelBuilder);
            MasterSeed.Seed(modelBuilder);

        }
    }
}