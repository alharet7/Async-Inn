﻿// <auto-generated />
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Async_Inn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Async_Inn.Models.Amenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Coffee Maker"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AC"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sea View"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Amman",
                            Country = "Jordan",
                            Name = "Capital Hotel",
                            Phone = "00962786031935",
                            State = "Amman",
                            StreetAddress = "King Abdullah St"
                        },
                        new
                        {
                            Id = 2,
                            City = "AlSalt",
                            Country = "Jordan",
                            Name = "Mountain Hotel",
                            Phone = "00962786031935",
                            State = "AlSalt",
                            StreetAddress = "60th St"
                        },
                        new
                        {
                            Id = 3,
                            City = "Aqaba",
                            Country = "Jordan",
                            Name = "City Hotel",
                            Phone = "00962786031935",
                            State = "Aqaba",
                            StreetAddress = "City Centre St"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Async_Inn.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = 0,
                            Name = "Studio"
                        },
                        new
                        {
                            Id = 2,
                            Layout = 1,
                            Name = "Single Room"
                        },
                        new
                        {
                            Id = 3,
                            Layout = 2,
                            Name = "Double Room"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
