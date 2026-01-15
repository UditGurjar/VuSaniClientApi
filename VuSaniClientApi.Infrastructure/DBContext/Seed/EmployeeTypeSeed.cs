using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class EmployeeTypeSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeType>().HasData(

                new EmployeeType
                {
                    Id = 1,
                    Name = "Apprenticeship",
                    Description = "<p>Work and training combined, typically...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 2,
                    Name = "Casual Employment",
                    Description = "<p>Irregular work with no guaranteed hours...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 3,
                    Name = "Consultant",
                    Description = "<p>External expert hired for advice or services...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 4,
                    Name = "Fixed-Term Contract",
                    Description = "<p>Employment for a set period or project...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 5,
                    Name = "Freelancer / Independent Contractor",
                    Description = "<p>Self-employed individual contracted for services...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 6,
                    Name = "Full-Time Employment",
                    Description = "<p>Standard employment with full weekly hours...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 7,
                    Name = "In-sourced Employment",
                    Description = "<p>Role previously outsourced but now internal...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 8,
                    Name = "Internship",
                    Description = "Time-limited training for students or graduates...",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 9,
                    Name = "Learnership (SA-specific)",
                    Description = "Work-based learning program leading to a qualification...",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 10,
                    Name = "Part-Time Employment",
                    Description = "<p>Regular employment with fewer hours...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 11,
                    Name = "Permanent Employment",
                    Description = "<p>Long-term employment with full benefits...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 12,
                    Name = "Seasonal Employment",
                    Description = "<p>Work tied to specific seasons or events...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 13,
                    Name = "Secondment",
                    Description = "<p>Temporary transfer of an employee to another role...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 14,
                    Name = "Subcontractor",
                    Description = "<p>Provides services to a contractor rather than employer...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 15,
                    Name = "Temporary Employment",
                    Description = "<p>Short-term work, often seasonal...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 16,
                    Name = "Trainee/Graduate Program",
                    Description = "<p>Entry-level structured program to develop skills...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                },

                new EmployeeType
                {
                    Id = 17,
                    Name = "Volunteer",
                    Description = "<p>Individual works without pay, usually for experience...</p>",
                    Deleted = false,
                    CreatedAt = DateTime.Parse("2025-08-11 10:03:26"),
                    UpdatedAt = DateTime.Parse("2025-08-11 10:03:26")
                }
            );
        }
    }
}
