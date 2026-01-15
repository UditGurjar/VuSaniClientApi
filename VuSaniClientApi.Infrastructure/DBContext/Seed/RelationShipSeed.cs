using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class RelationShipSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelationShip>().HasData(

    new RelationShip { Id = 1, Name = "Father" },
    new RelationShip { Id = 2, Name = "Mother" },
    new RelationShip { Id = 3, Name = "Son" },
    new RelationShip { Id = 4, Name = "Daughter" },
    new RelationShip { Id = 5, Name = "Brother" },
    new RelationShip { Id = 6, Name = "Sister" },
    new RelationShip { Id = 7, Name = "Half-Brother" },
    new RelationShip { Id = 8, Name = "Half-Sister" },
    new RelationShip { Id = 9, Name = "Stepfather" },
    new RelationShip { Id = 10, Name = "Stepmother" },
    new RelationShip { Id = 11, Name = "Stepson" },
    new RelationShip { Id = 12, Name = "Stepdaughter" },
    new RelationShip { Id = 13, Name = "Stepbrother" },
    new RelationShip { Id = 14, Name = "Stepsister" },
    new RelationShip { Id = 15, Name = "Husband" },
    new RelationShip { Id = 16, Name = "Wife" },
    new RelationShip { Id = 17, Name = "Ex-Husband" },
    new RelationShip { Id = 18, Name = "Ex-Wife" },
    new RelationShip { Id = 19, Name = "Father-in-law" },
    new RelationShip { Id = 20, Name = "Mother-in-law" },
    new RelationShip { Id = 21, Name = "Brother-in-law" },
    new RelationShip { Id = 22, Name = "Sister-in-law" },
    new RelationShip { Id = 23, Name = "Son-in-law" },
    new RelationShip { Id = 24, Name = "Daughter-in-law" },
    new RelationShip { Id = 25, Name = "Grandfather" },
    new RelationShip { Id = 26, Name = "Grandmother" },
    new RelationShip { Id = 27, Name = "Grandson" },
    new RelationShip { Id = 28, Name = "Granddaughter" },
    new RelationShip { Id = 29, Name = "Great-grandfather" },
    new RelationShip { Id = 30, Name = "Great-grandmother" },
    new RelationShip { Id = 31, Name = "Great-grandson" },
    new RelationShip { Id = 32, Name = "Great-granddaughter" },
    new RelationShip { Id = 33, Name = "Uncle" },
    new RelationShip { Id = 34, Name = "Aunt" },
    new RelationShip { Id = 35, Name = "Cousin" },
    new RelationShip { Id = 36, Name = "First Cousin" },
    new RelationShip { Id = 37, Name = "Second Cousin" },
    new RelationShip { Id = 38, Name = "Cousin-in-law" },
    new RelationShip { Id = 39, Name = "Nephew" },
    new RelationShip { Id = 40, Name = "Niece" },
    new RelationShip { Id = 41, Name = "Great-Nephew (Grandnephew)" },
    new RelationShip { Id = 42, Name = "Great-Niece (Grandniece)" },
    new RelationShip { Id = 43, Name = "Foster Father" },
    new RelationShip { Id = 44, Name = "Foster Mother" },
    new RelationShip { Id = 45, Name = "Foster Child" },
    new RelationShip { Id = 46, Name = "Adoptive Father" },
    new RelationShip { Id = 47, Name = "Adoptive Mother" },
    new RelationShip { Id = 48, Name = "Adopted Son" },
    new RelationShip { Id = 49, Name = "Adopted Daughter" },
    new RelationShip { Id = 50, Name = "Guardian" },
    new RelationShip { Id = 51, Name = "Sibling-in-law" },
    new RelationShip { Id = 52, Name = "Godfather" },
    new RelationShip { Id = 53, Name = "Godmother" },
    new RelationShip { Id = 54, Name = "Godson" },
    new RelationShip { Id = 55, Name = "Goddaughter" },
    new RelationShip { Id = 56, Name = "Co-parent" },
    new RelationShip { Id = 57, Name = "Partner" },
    new RelationShip { Id = 58, Name = "Fiancé" },
    new RelationShip { Id = 59, Name = "Fiancée" }

);

        }
    }
}
