
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
        new Species { Id = 3, Name = "Swordfish", Habitat = "Deep Sea", Length = 400, Population = 30000, Lifespan = 9 }
      );
    }
  }
}