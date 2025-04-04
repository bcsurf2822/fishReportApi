﻿// <auto-generated />
using FishReportApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace myWebAppApi.Migrations
{
    [DbContext(typeof(FishDBContext))]
    partial class FishDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("FishReportApi.Models.FishMarket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("MarketName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FishMarkets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "New York, NY",
                            MarketName = "NY Fish Co."
                        },
                        new
                        {
                            Id = 2,
                            Location = "New Bedford, MA",
                            MarketName = "Tempest"
                        },
                        new
                        {
                            Id = 3,
                            Location = "Cape May, NJ",
                            MarketName = "Lobster House"
                        });
                });

            modelBuilder.Entity("FishReportApi.Models.FishMarketInventory", b =>
                {
                    b.Property<int>("FishMarketId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FishMarketId", "SpeciesId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("FishMarketInventory");

                    b.HasData(
                        new
                        {
                            FishMarketId = 1,
                            SpeciesId = 1
                        },
                        new
                        {
                            FishMarketId = 1,
                            SpeciesId = 2
                        },
                        new
                        {
                            FishMarketId = 1,
                            SpeciesId = 4
                        },
                        new
                        {
                            FishMarketId = 1,
                            SpeciesId = 6
                        },
                        new
                        {
                            FishMarketId = 1,
                            SpeciesId = 7
                        },
                        new
                        {
                            FishMarketId = 1,
                            SpeciesId = 9
                        },
                        new
                        {
                            FishMarketId = 1,
                            SpeciesId = 10
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 3
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 5
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 8
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 11
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 12
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 14
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 16
                        },
                        new
                        {
                            FishMarketId = 2,
                            SpeciesId = 18
                        },
                        new
                        {
                            FishMarketId = 3,
                            SpeciesId = 4
                        },
                        new
                        {
                            FishMarketId = 3,
                            SpeciesId = 7
                        },
                        new
                        {
                            FishMarketId = 3,
                            SpeciesId = 9
                        },
                        new
                        {
                            FishMarketId = 3,
                            SpeciesId = 13
                        },
                        new
                        {
                            FishMarketId = 3,
                            SpeciesId = 15
                        },
                        new
                        {
                            FishMarketId = 3,
                            SpeciesId = 17
                        });
                });

            modelBuilder.Entity("FishReportApi.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Habitat")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lifespan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Population")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Species");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Habitat = "Open Ocean",
                            Length = 300,
                            Lifespan = 15,
                            Name = "Bluefin Tuna",
                            Population = 25000,
                            Price = 12.99m
                        },
                        new
                        {
                            Id = 2,
                            Habitat = "Tropical Waters",
                            Length = 180,
                            Lifespan = 5,
                            Name = "Mahi Mahi",
                            Population = 75000,
                            Price = 8.50m
                        },
                        new
                        {
                            Id = 3,
                            Habitat = "Deep Sea",
                            Length = 400,
                            Lifespan = 9,
                            Name = "Swordfish",
                            Population = 30000,
                            Price = 14.25m
                        },
                        new
                        {
                            Id = 4,
                            Habitat = "Rivers and Oceans",
                            Length = 150,
                            Lifespan = 8,
                            Name = "Atlantic Salmon",
                            Population = 40000,
                            Price = 9.75m
                        },
                        new
                        {
                            Id = 5,
                            Habitat = "Tropical Oceans",
                            Length = 250,
                            Lifespan = 7,
                            Name = "Yellowfin Tuna",
                            Population = 60000,
                            Price = 11.20m
                        },
                        new
                        {
                            Id = 6,
                            Habitat = "Coral Reefs",
                            Length = 230,
                            Lifespan = 30,
                            Name = "Humphead Wrasse",
                            Population = 12000,
                            Price = 18.00m
                        },
                        new
                        {
                            Id = 7,
                            Habitat = "Coastal Waters",
                            Length = 15,
                            Lifespan = 4,
                            Name = "Anchovy",
                            Population = 1000000,
                            Price = 2.00m
                        },
                        new
                        {
                            Id = 8,
                            Habitat = "Open Ocean",
                            Length = 420,
                            Lifespan = 12,
                            Name = "Marlin",
                            Population = 20000,
                            Price = 13.80m
                        },
                        new
                        {
                            Id = 9,
                            Habitat = "Northern Pacific",
                            Length = 240,
                            Lifespan = 25,
                            Name = "Pacific Halibut",
                            Population = 35000,
                            Price = 10.50m
                        },
                        new
                        {
                            Id = 10,
                            Habitat = "Coral and Rocky Reefs",
                            Length = 170,
                            Lifespan = 10,
                            Name = "Giant Trevally",
                            Population = 18000,
                            Price = 9.90m
                        },
                        new
                        {
                            Id = 11,
                            Habitat = "Warm Coastal Waters",
                            Length = 180,
                            Lifespan = 7,
                            Name = "King Mackerel",
                            Population = 50000,
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 12,
                            Habitat = "Coastal and Estuarine Waters",
                            Length = 200,
                            Lifespan = 50,
                            Name = "Tarpon",
                            Population = 22000,
                            Price = 6.49m
                        },
                        new
                        {
                            Id = 13,
                            Habitat = "Tropical Oceans",
                            Length = 330,
                            Lifespan = 4,
                            Name = "Sailfish",
                            Population = 27000,
                            Price = 15.25m
                        },
                        new
                        {
                            Id = 14,
                            Habitat = "Reefs",
                            Length = 80,
                            Lifespan = 15,
                            Name = "Snapper",
                            Population = 62000,
                            Price = 6.99m
                        },
                        new
                        {
                            Id = 15,
                            Habitat = "Reefs and Rocky Areas",
                            Length = 250,
                            Lifespan = 20,
                            Name = "Groupers",
                            Population = 40000,
                            Price = 10.25m
                        },
                        new
                        {
                            Id = 16,
                            Habitat = "Warm Oceans",
                            Length = 30,
                            Lifespan = 5,
                            Name = "Flying Fish",
                            Population = 85000,
                            Price = 5.50m
                        },
                        new
                        {
                            Id = 17,
                            Habitat = "Shallow Coastal Waters",
                            Length = 60,
                            Lifespan = 7,
                            Name = "Pompano",
                            Population = 30000,
                            Price = 8.25m
                        },
                        new
                        {
                            Id = 18,
                            Habitat = "Rivers and Coastal Waters",
                            Length = 350,
                            Lifespan = 60,
                            Name = "Sturgeon",
                            Population = 15000,
                            Price = 16.50m
                        });
                });

            modelBuilder.Entity("FishReportApi.Models.FishMarketInventory", b =>
                {
                    b.HasOne("FishReportApi.Models.FishMarket", "FishMarket")
                        .WithMany("FishMarketInventory")
                        .HasForeignKey("FishMarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FishReportApi.Models.Species", "Species")
                        .WithMany("FishMarketInventory")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FishMarket");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("FishReportApi.Models.FishMarket", b =>
                {
                    b.Navigation("FishMarketInventory");
                });

            modelBuilder.Entity("FishReportApi.Models.Species", b =>
                {
                    b.Navigation("FishMarketInventory");
                });
#pragma warning restore 612, 618
        }
    }
}
