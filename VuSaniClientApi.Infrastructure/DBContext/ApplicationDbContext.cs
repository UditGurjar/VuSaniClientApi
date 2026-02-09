using Microsoft.EntityFrameworkCore;
using System;
using VuSaniClientApi.Infrastructure.DBContext.Seed;
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
        public DbSet<Sidebar> Sidebars { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<TerminationNotificationLog> TerminationNotificationLogs { get; set; }
        public DbSet<SoftwareAccessRequest> SoftwareAccessRequests { get; set; }

        // HSE Appointment related tables (structuralrole schema)
        public DbSet<HseAppointment> HseAppointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
        new Gender { Id = 1, Name = "Male" },
        new Gender { Id = 2, Name = "Female" },
        new Gender { Id = 3, Name = "Other" },
        new Gender { Id = 4, Name = "Prefer not to say" }
    );
            modelBuilder.Entity<Sidebar>(e =>
            {
                e.Property(x => x.Type)
                 .HasConversion<string>()        // enum <-> string
                 .HasMaxLength(20);              // stored as nvarchar(20)

                e.Property(x => x.Dependency)
                 .HasColumnType("nvarchar(max)"); // JSON stored as text

                e.Property(x => x.Deleted)
                 .HasDefaultValue(false);
            });


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

            modelBuilder.Entity<TerminationNotificationLog>()
                .HasIndex(t => new { t.UserId, t.IntervalDays })
                .IsUnique();

            // Table name = class name (EF convention); schema = module name
            modelBuilder.Entity<SoftwareAccessRequest>(e =>
            {
                e.ToTable(nameof(SoftwareAccessRequest), "Software");
                e.Property(x => x.Status).HasMaxLength(50);
            });

            // HSE Appointment entities (structuralrole schema)
            modelBuilder.Entity<HseAppointment>(e =>
            {
                e.ToTable(nameof(HseAppointment), "Structuralrole");
                e.Property(x => x.Deleted).HasDefaultValue(false);
                e.Property(x => x.Status).HasMaxLength(50).HasDefaultValue("PendingAcceptance");
                
                // Configure multiple FK to User table
                e.HasOne(x => x.AppointerUser)
                    .WithMany()
                    .HasForeignKey(x => x.AppointsUserId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                e.HasOne(x => x.AppointedUser)
                    .WithMany()
                    .HasForeignKey(x => x.AppointedUserId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                e.HasOne(x => x.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                e.HasOne(x => x.UpdatedByUser)
                    .WithMany()
                    .HasForeignKey(x => x.UpdatedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AppointmentType>(e =>
            {
                e.ToTable(nameof(AppointmentType), "Structuralrole");
                e.Property(x => x.Deleted).HasDefaultValue(false);
            });

            modelBuilder.Entity<Location>(e =>
            {
                e.ToTable(nameof(Location), "Structuralrole");
                e.Property(x => x.Deleted).HasDefaultValue(false);
            });

            //// ✅ -------- DUMMY DATA SEEDING --------




            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplySeeds();

        }
    }
}