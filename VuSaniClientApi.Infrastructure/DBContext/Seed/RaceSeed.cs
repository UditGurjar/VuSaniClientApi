using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class RaceSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Race>().HasData(
        new Race { Id = 1, Name = "White" },
        new Race { Id = 2, Name = "Black" },
        new Race { Id = 3, Name = "Coloured" },
        new Race { Id = 4, Name = "Indian" },
        new Race { Id = 5, Name = "Other" }
    );

        }
    }
}
