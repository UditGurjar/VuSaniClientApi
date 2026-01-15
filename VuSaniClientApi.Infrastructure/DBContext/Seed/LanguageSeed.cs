using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuSaniClientApi.Models.DBModels;

namespace VuSaniClientApi.Infrastructure.DBContext.Seed
{
    public static class LanguageSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(

    new Language { Id = 1, Name = "English" },
    new Language { Id = 2, Name = "Spanish" },
    new Language { Id = 3, Name = "isiZulu" },
    new Language { Id = 4, Name = "isiXhosa" },
    new Language { Id = 5, Name = "Afrikaans" },
    new Language { Id = 6, Name = "Sepedi (Northern Sotho)" },
    new Language { Id = 7, Name = "Setswana" },
    new Language { Id = 8, Name = "Sesotho (Southern Sotho)" },
    new Language { Id = 9, Name = "Xitsonga" },
    new Language { Id = 10, Name = "siSwati" },
    new Language { Id = 11, Name = "Tshivenda" },
    new Language { Id = 12, Name = "isiNdebele" },
    new Language { Id = 13, Name = "South African Sign Language (SASL)" }

);

        }
    }
}
