using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dragonarium.Services.Migrations
{
    /// <inheritdoc />
    public partial class HabitatElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitatElement_Element",
                table: "HabitatElements");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitatElement_Habitat",
                table: "HabitatElements");

            migrationBuilder.DeleteData(
                table: "Dragons",
                keyColumn: "DragonID",
                keyValue: new Guid("a315d35d-fc3c-4c62-9b4b-7cbb56e83976"));

            migrationBuilder.DeleteData(
                table: "Dragons",
                keyColumn: "DragonID",
                keyValue: new Guid("ba1adc28-8998-43cb-8dee-481e32f9df90"));

            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "HabitatID",
                keyValue: new Guid("a9e33e0d-1671-4589-a8f6-084eb6a1cca3"));

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Items",
                type: "longchar",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Elements",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longchar",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DragonEggItems",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkDragonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DragonEggItems", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_DragonEggItems_Dragons_LkDragonID",
                        column: x => x.LkDragonID,
                        principalTable: "Dragons",
                        principalColumn: "DragonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DragonEggItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitatItems",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LkHabitatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitatItems", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_HabitatItems_Habitats_LkHabitatID",
                        column: x => x.LkHabitatID,
                        principalTable: "Habitats",
                        principalColumn: "HabitatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitatItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dragons",
                columns: new[] { "DragonID", "Description", "DragonName", "GoldRate" },
                values: new object[,]
                {
                    { new Guid("48456299-e118-473e-8a19-b31e8bcb0ccb"), "Dragon Desc", "Dragon", 0 },
                    { new Guid("84dc6fdc-c555-428b-b284-3c3f5df43b38"), "Dragon Desc II", "Dragon II", 0 }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "HabitatID", "Description", "HabitatName" },
                values: new object[] { new Guid("ab7725ec-678d-4dea-8764-7666c78eca58"), "Habitat Desc", "Habitat" });

            migrationBuilder.CreateIndex(
                name: "IX_DragonEggItems_LkDragonID",
                table: "DragonEggItems",
                column: "LkDragonID");

            migrationBuilder.CreateIndex(
                name: "IX_HabitatItems_LkHabitatID",
                table: "HabitatItems",
                column: "LkHabitatID");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitatElements_Elements_LkElementID",
                table: "HabitatElements",
                column: "LkElementID",
                principalTable: "Elements",
                principalColumn: "LkElementID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitatElements_Habitats_LkHabitatID",
                table: "HabitatElements",
                column: "LkHabitatID",
                principalTable: "Habitats",
                principalColumn: "HabitatID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitatElements_Elements_LkElementID",
                table: "HabitatElements");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitatElements_Habitats_LkHabitatID",
                table: "HabitatElements");

            migrationBuilder.DropTable(
                name: "DragonEggItems");

            migrationBuilder.DropTable(
                name: "HabitatItems");

            migrationBuilder.DeleteData(
                table: "Dragons",
                keyColumn: "DragonID",
                keyValue: new Guid("48456299-e118-473e-8a19-b31e8bcb0ccb"));

            migrationBuilder.DeleteData(
                table: "Dragons",
                keyColumn: "DragonID",
                keyValue: new Guid("84dc6fdc-c555-428b-b284-3c3f5df43b38"));

            migrationBuilder.DeleteData(
                table: "Habitats",
                keyColumn: "HabitatID",
                keyValue: new Guid("ab7725ec-678d-4dea-8764-7666c78eca58"));

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Elements",
                type: "longchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Dragons",
                columns: new[] { "DragonID", "Description", "DragonName", "GoldRate" },
                values: new object[,]
                {
                    { new Guid("a315d35d-fc3c-4c62-9b4b-7cbb56e83976"), "Dragon Desc II", "Dragon II", 0 },
                    { new Guid("ba1adc28-8998-43cb-8dee-481e32f9df90"), "Dragon Desc", "Dragon", 0 }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "HabitatID", "Description", "HabitatName" },
                values: new object[] { new Guid("a9e33e0d-1671-4589-a8f6-084eb6a1cca3"), "Habitat Desc", "Habitat" });

            migrationBuilder.AddForeignKey(
                name: "FK_HabitatElement_Element",
                table: "HabitatElements",
                column: "LkElementID",
                principalTable: "Elements",
                principalColumn: "LkElementID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitatElement_Habitat",
                table: "HabitatElements",
                column: "LkHabitatID",
                principalTable: "Habitats",
                principalColumn: "HabitatID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
