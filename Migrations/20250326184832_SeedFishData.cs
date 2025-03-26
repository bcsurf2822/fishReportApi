using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myWebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedFishData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Lifespan = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Habitat", "Length", "Lifespan", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "Open Ocean", 300, 15, "Bluefin Tuna", 25000 },
                    { 2, "Tropical Waters", 180, 5, "Mahi Mahi", 75000 },
                    { 3, "Deep Sea", 400, 9, "Swordfish", 30000 },
                    { 4, "Rivers and Oceans", 150, 8, "Atlantic Salmon", 40000 },
                    { 5, "Tropical Oceans", 250, 7, "Yellowfin Tuna", 60000 },
                    { 6, "Coral Reefs", 230, 30, "Humphead Wrasse", 12000 },
                    { 7, "Coastal Waters", 15, 4, "Anchovy", 1000000 },
                    { 8, "Open Ocean", 420, 12, "Marlin", 20000 },
                    { 9, "Northern Pacific", 240, 25, "Pacific Halibut", 35000 },
                    { 10, "Coral and Rocky Reefs", 170, 10, "Giant Trevally", 18000 },
                    { 11, "Warm Coastal Waters", 180, 7, "King Mackerel", 50000 },
                    { 12, "Coastal and Estuarine Waters", 200, 50, "Tarpon", 22000 },
                    { 13, "Tropical Oceans", 330, 4, "Sailfish", 27000 },
                    { 14, "Reefs", 80, 15, "Snapper", 62000 },
                    { 15, "Reefs and Rocky Areas", 250, 20, "Groupers", 40000 },
                    { 16, "Warm Oceans", 30, 5, "Flying Fish", 85000 },
                    { 17, "Shallow Coastal Waters", 60, 7, "Pompano", 30000 },
                    { 18, "Rivers and Coastal Waters", 350, 60, "Sturgeon", 15000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
