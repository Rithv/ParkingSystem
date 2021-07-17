using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingSystem.Core.Migrations
{
    public partial class CarParkSystemMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingAreas",
                columns: table => new
                {
                    ParkingAreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfSpaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingAreas", x => x.ParkingAreaId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParkingAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RegistrationNumber);
                    table.ForeignKey(
                        name: "FK_Vehicles_ParkingAreas_ParkingAreaId",
                        column: x => x.ParkingAreaId,
                        principalTable: "ParkingAreas",
                        principalColumn: "ParkingAreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkedVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleRegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParkingAreaId = table.Column<int>(type: "int", nullable: false),
                    TimeArrived = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkedVehicles_ParkingAreas_ParkingAreaId",
                        column: x => x.ParkingAreaId,
                        principalTable: "ParkingAreas",
                        principalColumn: "ParkingAreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkedVehicles_Vehicles_VehicleRegistrationNumber",
                        column: x => x.VehicleRegistrationNumber,
                        principalTable: "Vehicles",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ParkingAreas",
                columns: new[] { "ParkingAreaId", "NumberOfSpaces" },
                values: new object[] { 1, 10 });

            migrationBuilder.InsertData(
                table: "ParkingAreas",
                columns: new[] { "ParkingAreaId", "NumberOfSpaces" },
                values: new object[] { 2, 15 });

            migrationBuilder.InsertData(
                table: "ParkingAreas",
                columns: new[] { "ParkingAreaId", "NumberOfSpaces" },
                values: new object[] { 3, 8 });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicles_ParkingAreaId",
                table: "ParkedVehicles",
                column: "ParkingAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicles_VehicleRegistrationNumber",
                table: "ParkedVehicles",
                column: "VehicleRegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ParkingAreaId",
                table: "Vehicles",
                column: "ParkingAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ParkingAreas");
        }
    }
}
