// Dragonarium
// DragonariumDbContext.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using Dragonarium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Dragonarium.Services.Contexts
{
    public class DragonariumDbContext : DbContext
    {
        // Db Context

        public DragonariumDbContext() : base()
        {
            var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\", "DragonariumDb.accdb"));
            DbPath = path;
        }

        public DragonariumDbContext(string path) : base()
        {
            DbPath = path;
        }

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
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCurrency> ItemCurrencies { get; set; }
        public DbSet<LkCurrency> Currencies { get; set; }
        public DbSet<HabitatItem> HabitatItems { get; set; }
        public DbSet<DragonEggItem> EggItems { get; set; }


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
            modelBuilder.Entity<LkElement>(
                entity =>
                {
                    entity.ToTable("Elements");
                    entity.HasKey(el => el.LkElementID);
                    entity.Property(el => el.LkElementID)
                          .ValueGeneratedOnAdd();
                    entity.Property(e => e.ElementName)
                          .HasMaxLength(50);
                    entity.Property(e => e.Description)
                          .HasMaxLength(255);

                    entity.HasData(new List<LkElement>()
                                   {
                                       new LkElement { LkElementID = 1, ElementName = "Water", Description = "Water" },
                                       new LkElement { LkElementID = 2, ElementName = "Earth", Description = "Earth" },
                                       new LkElement { LkElementID = 3, ElementName = "Fire", Description = "Fire" },
                                       new LkElement { LkElementID = 4, ElementName = "Air", Description = "Air" },
                                   });
                });

            modelBuilder.Entity<LkCurrency>(
                entity =>
                {
                    entity.ToTable("Currencies");
                    entity.HasKey(currency => currency.CurrencyID);
                    entity.Property(cur => cur.CurrencyID)
                          .ValueGeneratedOnAdd();
                    entity.Property(e => e.CurrencyName)
                          .HasMaxLength(25);
                    entity.Property(e => e.Description)
                          .HasMaxLength(100);
                    entity.HasData(new List<LkCurrency>()
                                   {
                                       new LkCurrency { CurrencyID = 1, CurrencyName = "Gold", Description = "Gold" },
                                       new LkCurrency { CurrencyID = 2, CurrencyName = "Silver", Description = "Silver" },
                                   });
                });

            modelBuilder.Entity<LkHabitat>(
                entity =>
                {
                    entity.ToTable("Habitats");
                    entity.HasKey(habitat => habitat.HabitatID)
                          .HasName("PK_Habitat");
                    entity.Property(hab => hab.HabitatID)
                          .ValueGeneratedOnAdd()
                          .HasValueGenerator<GuidValueGenerator>()
                          .HasColumnName("HabitatID");
                    entity.Property(e => e.HabitatName)
                          .HasMaxLength(50);
                    entity.Property(e => e.Description)
                          .HasMaxLength(255);

                    // Relationship with LkHabitatElement
                    entity.HasMany(e => e.LkHabitatElements)
                          .WithOne(e => e.LkHabitat)
                          .HasForeignKey(e => e.LkHabitatID);

                    // Generate test habitat data
                    entity.HasData(new List<LkHabitat>() { new LkHabitat { HabitatID = Guid.NewGuid(), HabitatName = "Habitat", Description = "Habitat Desc" }, });
                });

            modelBuilder.Entity<LkDragon>(
                entity =>
                {
                    entity.ToTable("Dragons");
                    entity.HasKey(dragon => dragon.LkDragonID)
                          .HasName("PK_Dragon");
                    entity.Property(x => x.LkDragonID)
                          .HasColumnName("DragonID");

                    // Test dragon data
                    entity.HasData(new List<LkDragon>()
                                   {
                                       new LkDragon { LkDragonID = Guid.NewGuid(), DragonName = "Dragon", Description = "Dragon Desc", },
                                       new LkDragon { LkDragonID = Guid.NewGuid(), DragonName = "Dragon II", Description = "Dragon Desc II", },
                                   });
                });

            modelBuilder.Entity<Item>(
                entity =>
                {
                    entity.HasKey(item => item.ItemID);
                    entity.HasMany(item => item.ItemCurrencies)
                          .WithOne(ic => ic.Item)
                          .HasForeignKey(ic => ic.ItemID)
                          .HasConstraintName("FK_ItemCurrency_Item");
                    entity.Property(e => e.ItemName)
                          .HasMaxLength(50);
                    entity.Property(e => e.Description)
                          .HasMaxLength(255);

                    entity.ToTable("Items"); // Table name for Item
                });

            modelBuilder.Entity<HabitatItem>(
                entity =>
                {
                    entity.ToTable("HabitatItems"); // Table name for HabitatItem

                    // Additional properties and relations for HabitatItem

                    // In case if LkHabitatID is a foreign key and LkHabitat is a navigation property
                    entity.HasOne(e => e.LkHabitat).WithMany().HasForeignKey(e => e.LkHabitatID);
                });

            modelBuilder.Entity<DragonEggItem>(
                entity =>
                {
                    entity.ToTable("DragonEggItems"); // Table name for DragonEggItem

                    // Additional properties and relations for DragonEggItem

                    // In case if LkDragonID is a foreign key and LkDragon is a navigation property
                    entity.HasOne(e => e.LkDragon).WithMany().HasForeignKey(e => e.LkDragonID);
                });

            modelBuilder.Entity<LkHabitatElement>(
                entity =>
                {
                    entity.ToTable("HabitatElements");
                    entity.HasKey(e => new { e.LkHabitatID, e.LkElementID }); // Composite PK
                    entity.HasOne(e => e.LkHabitat)
                          .WithMany(e => e.LkHabitatElements)
                          .HasForeignKey(e => e.LkHabitatID);
                    entity.HasOne(e => e.LkElement)
                          .WithMany() // If LkElement has a collection of LkHabitatElement add it here
                          .HasForeignKey(e => e.LkElementID);
                });


            modelBuilder.Entity<LkDragonElement>(
                entity =>
                {
                    entity.ToTable("DragonElements");
                    entity.HasKey(e => new { e.LkDragonID, e.LkElementID })
                          .HasName("PK_DragonElement");
                    entity.Property(x => x.LkDragonID)
                          .HasColumnName("DragonID");
                    entity.Property(x => x.LkElementID)
                          .HasColumnName("ElementID");
                    entity.HasOne(de => de.LkDragon)
                          .WithMany(e => e.DragonElements)
                          .HasForeignKey(de => de.LkDragonID)
                          .HasConstraintName("FK_DragonElement_Dragon");
                    entity.HasOne(de => de.LkElement)
                          .WithMany()
                          .HasForeignKey(de => de.LkElementID)
                          .HasConstraintName("FK_DragonElement_Element");
                });

            modelBuilder.Entity<LkDragonEgg>(
                entity =>
                {
                    entity.ToTable("DragonEggs");
                    entity.HasKey(dragonEgg => dragonEgg.LkDragonID);

                    entity.HasOne(dragonEgg => dragonEgg.LkDragon)
                          .WithOne()
                          .HasForeignKey<LkDragonEgg>(dragonEgg => dragonEgg.LkDragonID)
                          .HasConstraintName("FK_DragonEgg_Dragon");
                    entity.Navigation(x => x.LkDragon)
                          .AutoInclude();
                });

            modelBuilder.Entity<ItemCurrency>(
                entity =>
                {
                    entity.ToTable("ItemCurrencies");
                    entity.HasKey(itemCurrency => new { itemCurrency.ItemID, itemCurrency.LkCurrencyID });
                    entity.HasOne(itemCurrency => itemCurrency.Item)
                          .WithMany(item => item.ItemCurrencies)
                          .HasForeignKey(itemCurrency => itemCurrency.ItemID);
                    entity.HasOne(itemCurrency => itemCurrency.LkCurrency)
                          .WithMany()
                          .HasForeignKey(itemCurrency => itemCurrency.LkCurrencyID);
                });
        }
    }
}