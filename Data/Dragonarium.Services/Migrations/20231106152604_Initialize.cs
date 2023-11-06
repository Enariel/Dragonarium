using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dragonarium.Services.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Jet:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "Dragons",
                columns: table => new
                {
                    DragonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DragonName = table.Column<string>(type: "longchar", nullable: true),
                    Description = table.Column<string>(type: "longchar", nullable: true),
                    GoldRate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dragon", x => x.DragonID);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    LkElementID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Jet:Identity", "1, 1"),
                    ElementName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "longchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.LkElementID);
                });

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    HabitatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HabitatName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitat", x => x.HabitatID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "DragonEggs",
                columns: table => new
                {
                    LkDragonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HatchExp = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DragonEggs", x => x.LkDragonID);
                    table.ForeignKey(
                        name: "FK_DragonEgg_Dragon",
                        column: x => x.LkDragonID,
                        principalTable: "Dragons",
                        principalColumn: "DragonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DragonElements",
                columns: table => new
                {
                    DragonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElementID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DragonElement", x => new { x.DragonID, x.ElementID });
                    table.ForeignKey(
                        name: "FK_DragonElement_Dragon",
                        column: x => x.DragonID,
                        principalTable: "Dragons",
                        principalColumn: "DragonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DragonElement_Element",
                        column: x => x.ElementID,
                        principalTable: "Elements",
                        principalColumn: "LkElementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitatElements",
                columns: table => new
                {
                    LkHabitatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkElementID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitatElements", x => new { x.LkHabitatID, x.LkElementID });
                    table.ForeignKey(
                        name: "FK_HabitatElement_Element",
                        column: x => x.LkElementID,
                        principalTable: "Elements",
                        principalColumn: "LkElementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitatElement_Habitat",
                        column: x => x.LkHabitatID,
                        principalTable: "Habitats",
                        principalColumn: "HabitatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCurrencies",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkCurrencyID = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCurrencies", x => new { x.ItemID, x.LkCurrencyID });
                    table.ForeignKey(
                        name: "FK_ItemCurrencies_Currencies_LkCurrencyID",
                        column: x => x.LkCurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCurrency_Item",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyID", "CurrencyName", "Description" },
                values: new object[,]
                {
                    { 1, "Gold", "Gold" },
                    { 2, "Silver", "Silver" }
                });

            migrationBuilder.InsertData(
                table: "Dragons",
                columns: new[] { "DragonID", "Description", "DragonName", "GoldRate" },
                values: new object[,]
                {
                    { new Guid("a315d35d-fc3c-4c62-9b4b-7cbb56e83976"), "Dragon Desc II", "Dragon II", 0 },
                    { new Guid("ba1adc28-8998-43cb-8dee-481e32f9df90"), "Dragon Desc", "Dragon", 0 }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "LkElementID", "Description", "ElementName" },
                values: new object[,]
                {
                    { 1, "Water", "Water" },
                    { 2, "Earth", "Earth" },
                    { 3, "Fire", "Fire" },
                    { 4, "Air", "Air" }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "HabitatID", "Description", "HabitatName" },
                values: new object[] { new Guid("a9e33e0d-1671-4589-a8f6-084eb6a1cca3"), "Habitat Desc", "Habitat" });

            migrationBuilder.CreateIndex(
                name: "IX_DragonElements_ElementID",
                table: "DragonElements",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_HabitatElements_LkElementID",
                table: "HabitatElements",
                column: "LkElementID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCurrencies_LkCurrencyID",
                table: "ItemCurrencies",
                column: "LkCurrencyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DragonEggs");

            migrationBuilder.DropTable(
                name: "DragonElements");

            migrationBuilder.DropTable(
                name: "HabitatElements");

            migrationBuilder.DropTable(
                name: "ItemCurrencies");

            migrationBuilder.DropTable(
                name: "Dragons");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
