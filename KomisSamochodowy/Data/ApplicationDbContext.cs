using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KomisSamochodowy.Models;

namespace KomisSamochodowy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KomisSamochodowy.Models.Marka>? Marka { get; set; }
        public DbSet<KomisSamochodowy.Models.Model>? Model { get; set; }
        public DbSet<KomisSamochodowy.Models.Nadwozie>? Nadwozie { get; set; }
        public DbSet<KomisSamochodowy.Models.Paliwo>? Paliwo { get; set; }
        public DbSet<KomisSamochodowy.Models.Samochod>? Samochod { get; set; }
    }
}