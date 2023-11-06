// Dragonarium
// DragonariumDbContext.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using Dragonarium.Models;
using Microsoft.EntityFrameworkCore;

namespace Dragonarium.Services.Contexts
{
    public class DragonariumDbContext : DbContext
    {
        // Db Context

        public DragonariumDbContext(DbContextOptions<DragonariumDbContext> options) : base(options)
        {
        }

        public string DbPath { get; set; }
        // Db Sets

        public DbSet<LkDragon> Dragons { get; set; }
        public DbSet<LkElement> Elements { get; set; }
        public DbSet<LkDragonElement> DragonElements { get; set; }
        public DbSet<LkDragonEgg> DragonEggs { get; set; }
        public DbSet<LkHabitat> Habitats { get; set; }
        public DbSet<LkHabitatElement> HabitatElements { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseJet($"Data Source={DbPath}")
                          .EnableSensitiveDataLogging()
                          .EnableDetailedErrors();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}