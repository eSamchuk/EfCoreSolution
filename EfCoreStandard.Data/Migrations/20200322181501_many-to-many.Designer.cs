﻿// <auto-generated />
using System;
using EfCoreStandard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreStandard.Data.Migrations
{
    [DbContext(typeof(StarShipDbContext))]
    [Migration("20200322181501_many-to-many")]
    partial class manytomany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCoreStandard.Domain.Constant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Constants");
                });

            modelBuilder.Entity("EfCoreStandard.Domain.Hangar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Hangar");
                });

            modelBuilder.Entity("EfCoreStandard.Domain.HangarStarship", b =>
                {
                    b.Property<int>("HangarId")
                        .HasColumnType("int");

                    b.Property<int>("StarshipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("HangarId", "StarshipId");

                    b.HasIndex("StarshipId");

                    b.ToTable("HangarStarship");
                });

            modelBuilder.Entity("EfCoreStandard.Domain.StarShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<double>("DamagePotential")
                        .HasColumnType("float");

                    b.Property<double>("HyperDriveDistance")
                        .HasColumnType("float");

                    b.Property<double>("Maneuverability")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ObtainedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("ShieldStrength")
                        .HasColumnType("float");

                    b.Property<int>("StorageCapacity")
                        .HasColumnType("int");

                    b.Property<int>("TechCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("StarShips");
                });

            modelBuilder.Entity("EfCoreStandard.Domain.Upgrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QualityId")
                        .HasColumnType("int");

                    b.Property<int>("StarShipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QualityId");

                    b.HasIndex("StarShipId");

                    b.ToTable("Upgrades");
                });

            modelBuilder.Entity("EfCoreStandard.Domain.UpgradeBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TargetParameterId")
                        .HasColumnType("int");

                    b.Property<int>("UpgradeId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TargetParameterId");

                    b.HasIndex("UpgradeId");

                    b.ToTable("UpgradeBonuses");
                });

            modelBuilder.Entity("EfCoreStandard.Domain.HangarStarship", b =>
                {
                    b.HasOne("EfCoreStandard.Domain.Hangar", "Hangar")
                        .WithMany("ShipsParkingHistory")
                        .HasForeignKey("HangarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreStandard.Domain.StarShip", "Starship")
                        .WithMany("ParkingHistory")
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreStandard.Domain.StarShip", b =>
                {
                    b.HasOne("EfCoreStandard.Domain.Constant", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreStandard.Domain.Upgrade", b =>
                {
                    b.HasOne("EfCoreStandard.Domain.Constant", "Quality")
                        .WithMany()
                        .HasForeignKey("QualityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreStandard.Domain.StarShip", "StarShip")
                        .WithMany("Upgrades")
                        .HasForeignKey("StarShipId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreStandard.Domain.UpgradeBonus", b =>
                {
                    b.HasOne("EfCoreStandard.Domain.Constant", "TargetParameter")
                        .WithMany()
                        .HasForeignKey("TargetParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreStandard.Domain.Upgrade", "Upgrade")
                        .WithMany("Bonuses")
                        .HasForeignKey("UpgradeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
