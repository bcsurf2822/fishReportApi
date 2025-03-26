using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myWebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceAndFishMarketIdToSpecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FishMarketId",
                table: "Species",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Species",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "FishMarkets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarketName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishMarkets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FishMarkets",
                columns: new[] { "Id", "Location", "MarketName" },
                values: new object[,]
                {
                    { 1, "New York, NY", "NY Fish Co." },
                    { 2, "New Bedford, MA", "Tempest" },
                    { 3, "Cape May, NJ", "Lobster House" }
                });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 12.99m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 8.50m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 14.25m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 9.75m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 11.20m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 18.00m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 2.00m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 13.80m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 10.50m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 9.90m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 7.99m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 6.49m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 15.25m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 6.99m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 10.25m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 5.50m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 8.25m });

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "FishMarketId", "Price" },
                values: new object[] { null, 16.50m });

            migrationBuilder.CreateIndex(
                name: "IX_Species_FishMarketId",
                table: "Species",
                column: "FishMarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_FishMarkets_FishMarketId",
                table: "Species",
                column: "FishMarketId",
                principalTable: "FishMarkets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Species_FishMarkets_FishMarketId",
                table: "Species");

            migrationBuilder.DropTable(
                name: "FishMarkets");

            migrationBuilder.DropIndex(
                name: "IX_Species_FishMarketId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "FishMarketId",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Species");
        }
    }
}
