using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public sealed class DisabilitySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disability>().HasData(
                // Parent category
                new Disability
                {
                    Id = 1,
                    Name = "Physical Disabilities",
                    Description = null,
                    Parent = null,
                    Deleted = false,
                    IsStatic = 1
                },

                // Children of Physical Disabilities
                new Disability
                {
                    Id = 2,
                    Name = "Mobility Impairments",
                    Description = null,
                    Parent = 1,
                    Deleted = false,
                    IsStatic = 1
                },

                new Disability
                {
                    Id = 3,
                    Name = "Amputation of limbs",
                    Description = null,
                    Parent = 2,
                    Deleted = false,
                    IsStatic = 1
                },

                new Disability
                {
                    Id = 4,
                    Name = "Paraplegia or Quadriplegia (paralysis)",
                    Description = null,
                    Parent = 2,
                    Deleted = false,
                    IsStatic = 1
                },

                new Disability
                {
                    Id = 5,
                    Name = "Muscular Dystrophy",
                    Description = null,
                    Parent = 2,
                    Deleted = false,
                    IsStatic = 1
                }
            );
        }


    }
}
