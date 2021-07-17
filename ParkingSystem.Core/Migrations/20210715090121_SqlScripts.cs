using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingSystem.Core.Migrations
{
    public partial class SqlScripts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE GetSlotsByParkArea
                       (@parkAreaId int)
                       AS
                       BEGIN
                       SELECT * FROM ParkingAreas WHERE ParkingAreaId = @parkAreaId
                       END
                       GO

                        CREATE PROCEDURE GetVehicleDetails
                        (@registrationNumber nvarchar(450))
                        AS
                        BEGIN
                        SELECT * FROM Vehicles WHERE RegistrationNumber = @registrationNumber
                        END
                        GO
                        CREATE PROCEDURE GetParkedVehicleDetails
                        (@registrationNumber nvarchar(450))
                        AS
                        BEGIN
                        SELECT * FROM ParkedVehicles WHERE VehicleRegistrationNumber = @registrationNumber
                        END
                        Go";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
