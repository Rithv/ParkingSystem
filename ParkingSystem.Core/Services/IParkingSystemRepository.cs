using CarParkSystem.DbEntities;
using ParkingSystem.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Core.Services
{
    public interface IParkingSystemRepository
    {
        void CarRegistration(Vehicle vehicle);

        CheckInRepsonse CheckInCar(ParkedVehicle parkedVehicle);

        void CheckOutCar(ParkedVehicle parkedVehicle);

        int GetNumberOfSpaces(int parkingAreaId);

        Vehicle GetVehicleDetails(string vehicleRegistrationNumber);

        ParkedVehicle? GetParkedVehicleDetails(string regNumber);

        int? GetAvailablePakingArea();

    }
}
