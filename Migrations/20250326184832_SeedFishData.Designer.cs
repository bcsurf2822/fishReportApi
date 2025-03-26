﻿// <auto-generated />
using FishReportApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace myWebAppApi.Migrations
{
    [DbContext(typeof(FishDBContext))]
    [Migration("20250326184832_SeedFishData")]
    partial class SeedFishData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

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
                            Population = 25000
                        },
                        new
                        {
                            Id = 2,
                            Habitat = "Tropical Waters",
                            Length = 180,
                            Lifespan = 5,
                            Name = "Mahi Mahi",
                            Population = 75000
                        },
                        new
                        {
                            Id = 3,
                            Habitat = "Deep Sea",
                            Length = 400,
                            Lifespan = 9,
                            Name = "Swordfish",
                            Population = 30000
                        },
                        new
                        {
                            Id = 4,
                            Habitat = "Rivers and Oceans",
                            Length = 150,
                            Lifespan = 8,
                            Name = "Atlantic Salmon",
                            Population = 40000
                        },
                        new
                        {
                            Id = 5,
                            Habitat = "Tropical Oceans",
                            Length = 250,
                            Lifespan = 7,
                            Name = "Yellowfin Tuna",
                            Population = 60000
                        },
                        new
                        {
                            Id = 6,
                            Habitat = "Coral Reefs",
                            Length = 230,
                            Lifespan = 30,
                            Name = "Humphead Wrasse",
                            Population = 12000
                        },
                        new
                        {
                            Id = 7,
                            Habitat = "Coastal Waters",
                            Length = 15,
                            Lifespan = 4,
                            Name = "Anchovy",
                            Population = 1000000
                        },
                        new
                        {
                            Id = 8,
                            Habitat = "Open Ocean",
                            Length = 420,
                            Lifespan = 12,
                            Name = "Marlin",
                            Population = 20000
                        },
                        new
                        {
                            Id = 9,
                            Habitat = "Northern Pacific",
                            Length = 240,
                            Lifespan = 25,
                            Name = "Pacific Halibut",
                            Population = 35000
                        },
                        new
                        {
                            Id = 10,
                            Habitat = "Coral and Rocky Reefs",
                            Length = 170,
                            Lifespan = 10,
                            Name = "Giant Trevally",
                            Population = 18000
                        },
                        new
                        {
                            Id = 11,
                            Habitat = "Warm Coastal Waters",
                            Length = 180,
                            Lifespan = 7,
                            Name = "King Mackerel",
                            Population = 50000
                        },
                        new
                        {
                            Id = 12,
                            Habitat = "Coastal and Estuarine Waters",
                            Length = 200,
                            Lifespan = 50,
                            Name = "Tarpon",
                            Population = 22000
                        },
                        new
                        {
                            Id = 13,
                            Habitat = "Tropical Oceans",
                            Length = 330,
                            Lifespan = 4,
                            Name = "Sailfish",
                            Population = 27000
                        },
                        new
                        {
                            Id = 14,
                            Habitat = "Reefs",
                            Length = 80,
                            Lifespan = 15,
                            Name = "Snapper",
                            Population = 62000
                        },
                        new
                        {
                            Id = 15,
                            Habitat = "Reefs and Rocky Areas",
                            Length = 250,
                            Lifespan = 20,
                            Name = "Groupers",
                            Population = 40000
                        },
                        new
                        {
                            Id = 16,
                            Habitat = "Warm Oceans",
                            Length = 30,
                            Lifespan = 5,
                            Name = "Flying Fish",
                            Population = 85000
                        },
                        new
                        {
                            Id = 17,
                            Habitat = "Shallow Coastal Waters",
                            Length = 60,
                            Lifespan = 7,
                            Name = "Pompano",
                            Population = 30000
                        },
                        new
                        {
                            Id = 18,
                            Habitat = "Rivers and Coastal Waters",
                            Length = 350,
                            Lifespan = 60,
                            Name = "Sturgeon",
                            Population = 15000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
