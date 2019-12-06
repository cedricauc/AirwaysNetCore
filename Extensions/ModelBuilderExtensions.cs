using Airways.Helper;
using Airways.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Airways.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity(typeof(City)).HasData(new City[] {
                new City{Id=1,Name="Londres"},
                new City{Id=2,Name="Paris"},
                new City{Id=3,Name="Berlin"},
                new City{Id=4,Name="Bruxelles"},
                new City{Id=5,Name="Lisbonne"},
                new City{Id=6,Name="Madrid"},
                new City{Id=7,Name="Rome"},
            });

            builder.Entity(typeof(Fly)).HasData(new Fly[] {
                new Fly{Id=1, Number=StringUtilsHelper.getNumber(), Departure=1, Arrival=2, Time=DateTime.Now, Price=280, Seat=30, Reduction=false},
            });
        }
    }
}
