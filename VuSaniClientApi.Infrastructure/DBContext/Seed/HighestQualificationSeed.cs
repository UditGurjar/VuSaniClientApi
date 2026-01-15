using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class HighestQualificationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HighestQualification>().HasData(
                new HighestQualification
                {
                    Id = 1,
                    Name = "General Education and Training Certificate (GETC)",
                    Description = "<p>NQF Level 1: Typically awarded after ...</p>",

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

                    CreatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
                    CreatedBy = 1,
                    UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 27),
                    UpdatedBy = 1,
                    UniqueId = "H&HG/SKI/2425/0012"
                }
            );
        }
    }
}
