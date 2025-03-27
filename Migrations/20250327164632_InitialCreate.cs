using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myWebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Habitat = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    Population = table.Column<int>(type: "INTEGER", nullable: true),
                    Lifespan = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    FishMarketId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_FishMarkets_FishMarketId",
                        column: x => x.FishMarketId,
                        principalTable: "FishMarkets",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "FishMarketId", "Habitat", "Length", "Lifespan", "Name", "Population", "Price" },
                values: new object[,]
                {
                    { 1, null, "Open Ocean", 300, 15, "Bluefin Tuna", 25000, 12.99m },
                    { 2, null, "Tropical Waters", 180, 5, "Mahi Mahi", 75000, 8.50m },
                    { 3, null, "Deep Sea", 400, 9, "Swordfish", 30000, 14.25m },
                    { 4, null, "Rivers and Oceans", 150, 8, "Atlantic Salmon", 40000, 9.75m },
                    { 5, null, "Tropical Oceans", 250, 7, "Yellowfin Tuna", 60000, 11.20m },
                    { 6, null, "Coral Reefs", 230, 30, "Humphead Wrasse", 12000, 18.00m },
                    { 7, null, "Coastal Waters", 15, 4, "Anchovy", 1000000, 2.00m },
                    { 8, null, "Open Ocean", 420, 12, "Marlin", 20000, 13.80m },
                    { 9, null, "Northern Pacific", 240, 25, "Pacific Halibut", 35000, 10.50m },
                    { 10, null, "Coral and Rocky Reefs", 170, 10, "Giant Trevally", 18000, 9.90m },
                    { 11, null, "Warm Coastal Waters", 180, 7, "King Mackerel", 50000, 7.99m },
                    { 12, null, "Coastal and Estuarine Waters", 200, 50, "Tarpon", 22000, 6.49m },
                    { 13, null, "Tropical Oceans", 330, 4, "Sailfish", 27000, 15.25m },
                    { 14, null, "Reefs", 80, 15, "Snapper", 62000, 6.99m },
                    { 15, null, "Reefs and Rocky Areas", 250, 20, "Groupers", 40000, 10.25m },
                    { 16, null, "Warm Oceans", 30, 5, "Flying Fish", 85000, 5.50m },
                    { 17, null, "Shallow Coastal Waters", 60, 7, "Pompano", 30000, 8.25m },
                    { 18, null, "Rivers and Coastal Waters", 350, 60, "Sturgeon", 15000, 16.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Species_FishMarketId",
                table: "Species",
                column: "FishMarketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "FishMarkets");
        }
    }
}
