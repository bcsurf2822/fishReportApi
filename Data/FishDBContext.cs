
using FishReportApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FishReportApi.Data
{
  public class FishDBContext : DbContext
  {
    public FishDBContext(DbContextOptions<FishDBContext> options) : base(options)
    {
    }

    public DbSet<Species> Species { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Species>().HasData(
         new Species { Id = 1, Name = "Bluefin Tuna", Habitat = "Open Ocean", Length = 300, Population = 25000, Lifespan = 15 },
         new Species { Id = 2, Name = "Mahi Mahi", Habitat = "Tropical Waters", Length = 180, Population = 75000, Lifespan = 5 },
         new Species { Id = 3, Name = "Swordfish", Habitat = "Deep Sea", Length = 400, Population = 30000, Lifespan = 9 },
         new Species { Id = 4, Name = "Atlantic Salmon", Habitat = "Rivers and Oceans", Length = 150, Population = 40000, Lifespan = 8 },
         new Species { Id = 5, Name = "Yellowfin Tuna", Habitat = "Tropical Oceans", Length = 250, Population = 60000, Lifespan = 7 },
         new Species { Id = 6, Name = "Humphead Wrasse", Habitat = "Coral Reefs", Length = 230, Population = 12000, Lifespan = 30 },
         new Species { Id = 7, Name = "Anchovy", Habitat = "Coastal Waters", Length = 15, Population = 1000000, Lifespan = 4 },
         new Species { Id = 8, Name = "Marlin", Habitat = "Open Ocean", Length = 420, Population = 20000, Lifespan = 12 },
         new Species { Id = 9, Name = "Pacific Halibut", Habitat = "Northern Pacific", Length = 240, Population = 35000, Lifespan = 25 },
         new Species { Id = 10, Name = "Giant Trevally", Habitat = "Coral and Rocky Reefs", Length = 170, Population = 18000, Lifespan = 10 },
         new Species { Id = 11, Name = "King Mackerel", Habitat = "Warm Coastal Waters", Length = 180, Population = 50000, Lifespan = 7 },
         new Species { Id = 12, Name = "Tarpon", Habitat = "Coastal and Estuarine Waters", Length = 200, Population = 22000, Lifespan = 50 },
         new Species { Id = 13, Name = "Sailfish", Habitat = "Tropical Oceans", Length = 330, Population = 27000, Lifespan = 4 },
         new Species { Id = 14, Name = "Snapper", Habitat = "Reefs", Length = 80, Population = 62000, Lifespan = 15 },
         new Species { Id = 15, Name = "Groupers", Habitat = "Reefs and Rocky Areas", Length = 250, Population = 40000, Lifespan = 20 },
         new Species { Id = 16, Name = "Flying Fish", Habitat = "Warm Oceans", Length = 30, Population = 85000, Lifespan = 5 },
         new Species { Id = 17, Name = "Pompano", Habitat = "Shallow Coastal Waters", Length = 60, Population = 30000, Lifespan = 7 },
         new Species { Id = 18, Name = "Sturgeon", Habitat = "Rivers and Coastal Waters", Length = 350, Population = 15000, Lifespan = 60 }
       );
    }
  }
}