using EfCoreStandard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreStandard.Data
{
    public class StarShipDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-BUA088C\SQLEXPRESS;database=NMS_StarshipDb;User ID=sa;Password=ua64ua;trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ////for many-to-many relationship
            modelBuilder.Entity<HangarStarship>().HasKey(s => new { s.HangarId, s.StarshipId });
            modelBuilder.Entity<StarShip>().HasMany(x => x.Upgrades).WithOne(x => x.StarShip).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Upgrade>().HasMany(x => x.Bonuses).WithOne(x => x.Upgrade).OnDelete(DeleteBehavior.NoAction);
        }


        public DbSet<StarShip> StarShips { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<Constant> Constants { get; set; }
        public DbSet<UpgradeBonus> UpgradeBonuses { get; set; }
    }
}
