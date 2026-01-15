using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class NextOfKinSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NextOfKin>().HasData(
    new NextOfKin
    {
        NextOfKinId = 1,
        UserId = 1,
        Name = "Paulina Tenyane",
        RelationshipId = 6,   // Sister 
        ContactNumber = "27712654987"
    }
);

        }
    }
}
