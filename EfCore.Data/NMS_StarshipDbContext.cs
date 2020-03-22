using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfCore.Data
{
    public partial class NMS_StarshipDbContext : DbContext
    {
        public NMS_StarshipDbContext()
        {
        }

        public NMS_StarshipDbContext(DbContextOptions<NMS_StarshipDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Constants> Constants { get; set; }
        public virtual DbSet<StarShips> StarShips { get; set; }
        public virtual DbSet<UpgradeBonuses> UpgradeBonuses { get; set; }
        public virtual DbSet<Upgrades> Upgrades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StarShips>(entity =>
            {
                entity.HasIndex(e => e.ClassId);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StarShips)
                    .HasForeignKey(d => d.ClassId);
            });

            modelBuilder.Entity<UpgradeBonuses>(entity =>
            {
                entity.HasIndex(e => e.TargetParameterId);

                entity.HasIndex(e => e.UpgradeId);

                entity.HasOne(d => d.TargetParameter)
                    .WithMany(p => p.UpgradeBonuses)
                    .HasForeignKey(d => d.TargetParameterId);

                entity.HasOne(d => d.Upgrade)
                    .WithMany(p => p.UpgradeBonuses)
                    .HasForeignKey(d => d.UpgradeId);
            });

            modelBuilder.Entity<Upgrades>(entity =>
            {
                entity.HasIndex(e => e.QualityId);

                entity.HasIndex(e => e.StarShipId);

                entity.HasOne(d => d.Quality)
                    .WithMany(p => p.Upgrades)
                    .HasForeignKey(d => d.QualityId);

                entity.HasOne(d => d.StarShip)
                    .WithMany(p => p.Upgrades)
                    .HasForeignKey(d => d.StarShipId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
