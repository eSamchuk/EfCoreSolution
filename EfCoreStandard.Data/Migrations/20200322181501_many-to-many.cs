using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreStandard.Data.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hangar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarShips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    ObtainedDate = table.Column<DateTime>(nullable: false),
                    StorageCapacity = table.Column<int>(nullable: false),
                    TechCapacity = table.Column<int>(nullable: false),
                    DamagePotential = table.Column<double>(nullable: false),
                    ShieldStrength = table.Column<double>(nullable: false),
                    HyperDriveDistance = table.Column<double>(nullable: false),
                    Maneuverability = table.Column<double>(nullable: false),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarShips_Constants_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Constants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HangarStarship",
                columns: table => new
                {
                    HangarId = table.Column<int>(nullable: false),
                    StarshipId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangarStarship", x => new { x.HangarId, x.StarshipId });
                    table.ForeignKey(
                        name: "FK_HangarStarship_Hangar_HangarId",
                        column: x => x.HangarId,
                        principalTable: "Hangar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HangarStarship_StarShips_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "StarShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upgrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    QualityId = table.Column<int>(nullable: false),
                    StarShipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upgrades_Constants_QualityId",
                        column: x => x.QualityId,
                        principalTable: "Constants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Upgrades_StarShips_StarShipId",
                        column: x => x.StarShipId,
                        principalTable: "StarShips",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UpgradeBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpgradeId = table.Column<int>(nullable: false),
                    TargetParameterId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpgradeBonuses_Constants_TargetParameterId",
                        column: x => x.TargetParameterId,
                        principalTable: "Constants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpgradeBonuses_Upgrades_UpgradeId",
                        column: x => x.UpgradeId,
                        principalTable: "Upgrades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangarStarship_StarshipId",
                table: "HangarStarship",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_StarShips_ClassId",
                table: "StarShips",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeBonuses_TargetParameterId",
                table: "UpgradeBonuses",
                column: "TargetParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_UpgradeBonuses_UpgradeId",
                table: "UpgradeBonuses",
                column: "UpgradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrades_QualityId",
                table: "Upgrades",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrades_StarShipId",
                table: "Upgrades",
                column: "StarShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangarStarship");

            migrationBuilder.DropTable(
                name: "UpgradeBonuses");

            migrationBuilder.DropTable(
                name: "Hangar");

            migrationBuilder.DropTable(
                name: "Upgrades");

            migrationBuilder.DropTable(
                name: "StarShips");

            migrationBuilder.DropTable(
                name: "Constants");
        }
    }
}
