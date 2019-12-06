using Airways.Extensions;
using Airways.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Airways.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<City> CityModels { get; set; }
        public DbSet<Fly> FlyModels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity(typeof(Fly))
           .HasOne(typeof(City), "CityDeparture")
           .WithMany()
           .HasForeignKey("Departure")
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity(typeof(Fly))
            .HasOne(typeof(City), "CityArrival")
            .WithMany()
            .HasForeignKey("Arrival")
            .OnDelete(DeleteBehavior.Restrict);

            builder.Seed();
        }

    }
}
