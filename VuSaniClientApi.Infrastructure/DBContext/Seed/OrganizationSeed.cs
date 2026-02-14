using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class OrganizationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(

    new Organization
    {
        Id = 1,
        ParentId = null,   // ✅ ROOT MUST BE NULL
        Name = "Harmony and Help Group",
        Description = "<p>Corporate Office</p>",
        Level = 1,
         
        CreatedAt = DateTime.Parse("2025-08-11 10:03:30"),
        CreatedBy = 1,
        UpdatedAt = DateTime.Parse("2025-08-11 10:03:30"),
        UpdatedBy = 1,
        BusinessLogo = "/Logo/Org1HeaderLogo.jpg",
        BackgroundImage = "/Logo/Org1HeaderLogo.jpg",
        HeaderImage = "/Logo/Org1HeaderLogo.jpg",
        FooterImage = "/Logo/Org1HeaderLogo.jpg",
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
         
        CreatedAt = DateTime.Parse("2025-08-13 20:41:07"),
        CreatedBy = 1,
        UpdatedAt = DateTime.Parse("2025-08-13 20:41:07"),
        UpdatedBy = 1,
        BusinessLogo = "https://harmonyandmotors-api.vusani360.africa/org1.png",
        BackgroundImage = "https://harmonyandmotors-api.vusani360.africa/org1.png",
        HeaderImage = "/Logo/Org2HeaderLogo.jpg",
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
        Name = "Harmony and Help Academy",
        Description = "<p>Academy division</p>",
        Level = 1,
         
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
        }
    }
}
