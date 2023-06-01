﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(RentalCarDbContext))]
    partial class RentalCarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarNameId")
                        .HasColumnType("int");

                    b.Property<string>("FuelAndAC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.Property<string>("TransmissionAndDrive")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarNameId = 1,
                            Name = "i4 M50",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 2,
                            CarNameId = 1,
                            Name = "5 Series",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 3,
                            CarNameId = 1,
                            Name = "4 Series Coupé",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 4,
                            CarNameId = 2,
                            Name = "A3",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 5,
                            CarNameId = 2,
                            Name = "A6 Avant",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 6,
                            CarNameId = 2,
                            Name = "Q3 Sportback",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 7,
                            CarNameId = 3,
                            Name = "CX-5",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 8,
                            CarNameId = 3,
                            Name = "CX-30",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 9,
                            CarNameId = 3,
                            Name = "MX-5",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 10,
                            CarNameId = 4,
                            Name = "Prius",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 11,
                            CarNameId = 4,
                            Name = "Yaris",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 12,
                            CarNameId = 4,
                            Name = "C-HR",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 13,
                            CarNameId = 5,
                            Name = "3",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 14,
                            CarNameId = 5,
                            Name = "X",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 15,
                            CarNameId = 5,
                            Name = "Y",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 16,
                            CarNameId = 6,
                            Name = "GLC",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 17,
                            CarNameId = 6,
                            Name = "GLE",
                            NumberOfDoors = 0
                        },
                        new
                        {
                            Id = 18,
                            CarNameId = 6,
                            Name = "GLS",
                            NumberOfDoors = 0
                        });
                });

            modelBuilder.Entity("Models.CarName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mazda"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tesla"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mercedes"
                        });
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "email1@gmail.com",
                            Password = "AQAAAAIAAYagAAAAEGV6wtoibm4SJXyZig0pvhaa0on5aBCJ1Ey1vyS34u19+jYrseBDiUB4zGrOZXE3Pg==",
                            RefreshTokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 0,
                            UserName = "Gavriel"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "email12@gmail1.com",
                            Password = "AQAAAAIAAYagAAAAEB0g3p1HiSu1OMAZ0rlo3w4r/S8UDqvtThAbkmlY4gMltK9PR9vAuGl2pdW7YwCLPw==",
                            RefreshTokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 0,
                            UserName = "Israel"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "email13@gmail.com",
                            Password = "AQAAAAIAAYagAAAAEFhCnh70n4QxFHUQTcj4hMGro8CC7kNMI6wJt59omqCBYeOylxEL3INd3iE7IZThYg==",
                            RefreshTokenExpires = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 1,
                            UserName = "Iris"
                        });
                });

            modelBuilder.Entity("Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
