using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class SkillSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
        new Skill
        {
            Id = 1,
            Name = "Communication Skills",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0001"
        },
        new Skill
        {
            Id = 2,
            Name = "Problem-solving",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0002"
        },
        new Skill
        {
            Id = 3,
            Name = "Critical thinking",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0003"
        },
        new Skill
        {
            Id = 4,
            Name = "Time management",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0004"
        },
        new Skill
        {
            Id = 5,
            Name = "Adaptability",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0005"
        },
        new Skill
        {
            Id = 6,
            Name = "Collaboration",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0006"
        },
        new Skill
        {
            Id = 7,
            Name = "Emotional Intelligence",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0007"
        },
        new Skill
        {
            Id = 8,
            Name = "Leadership",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0008"
        },
        new Skill
        {
            Id = 9,
            Name = "Creativity",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0009"
        },
        new Skill
        {
            Id = 10,
            Name = "Conflict Resolution",
            SkillsType = "Soft Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0010"
        },
        new Skill
        {
            Id = 11,
            Name = "Programming (Python, Java, C++, etc.)",
            SkillsType = "Hard or Technical Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0011"
        },
        new Skill
        {
            Id = 12,
            Name = "Data Analysis",
            SkillsType = "Hard or Technical Skill",
            Organization = "[1]",
            IsStatic = 1,
             
            CreatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            CreatedBy = 1,
            UpdatedAt = new DateTime(2025, 8, 11, 10, 03, 33),
            UpdatedBy = null,
            UniqueId = "HAM/SKI/2526/0012"
        }
    );
        }
    }
}
