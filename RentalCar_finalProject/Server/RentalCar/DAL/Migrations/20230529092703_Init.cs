using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarNameId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    TransmissionAndDrive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelAndAC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CarNameId", "FuelAndAC", "Name", "NumberOfDoors", "TransmissionAndDrive" },
                values: new object[,]
                {
                    { 1, 1, null, "i4 M50", 0, null },
                    { 2, 1, null, "5 Series", 0, null },
                    { 3, 1, null, "4 Series Coupé", 0, null },
                    { 4, 2, null, "A3", 0, null },
                    { 5, 2, null, "A6 Avant", 0, null },
                    { 6, 2, null, "Q3 Sportback", 0, null },
                    { 7, 3, null, "CX-5", 0, null },
                    { 8, 3, null, "CX-30", 0, null },
                    { 9, 3, null, "MX-5", 0, null },
                    { 10, 4, null, "Prius", 0, null },
                    { 11, 4, null, "Yaris", 0, null },
                    { 12, 4, null, "C-HR", 0, null },
                    { 13, 5, null, "3", 0, null },
                    { 14, 5, null, "X", 0, null },
                    { 15, 5, null, "Y", 0, null },
                    { 16, 6, null, "GLC", 0, null },
                    { 17, 6, null, "GLE", 0, null },
                    { 18, 6, null, "GLS", 0, null }
                });

            migrationBuilder.InsertData(
                table: "CarNames",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Audi" },
                    { 3, "Mazda" },
                    { 4, "Toyota" },
                    { 5, "Tesla" },
                    { 6, "Mercedes" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Photo", "RefreshToken", "RefreshTokenExpires", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, "email1@gmail.com", "AQAAAAIAAYagAAAAEGV6wtoibm4SJXyZig0pvhaa0on5aBCJ1Ey1vyS34u19+jYrseBDiUB4zGrOZXE3Pg==", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Gavriel" },
                    { 2, "email12@gmail1.com", "AQAAAAIAAYagAAAAEB0g3p1HiSu1OMAZ0rlo3w4r/S8UDqvtThAbkmlY4gMltK9PR9vAuGl2pdW7YwCLPw==", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Israel" },
                    { 3, "email13@gmail.com", "AQAAAAIAAYagAAAAEFhCnh70n4QxFHUQTcj4hMGro8CC7kNMI6wJt59omqCBYeOylxEL3INd3iE7IZThYg==", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Iris" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarNames");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
