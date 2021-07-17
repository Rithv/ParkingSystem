using CarParkSystem.Core;
using CarParkSystem.DbEntities;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Core.Response;
using System;
using System.Data;
using System.Linq;

namespace ParkingSystem.Core.Services
{
    public class ParkingSystemRepository : IParkingSystemRepository
    {
        private readonly MainDbContext _context;
        public ParkingSystemRepository(MainDbContext context)
        {
            _context = context;
        }


        public void CarRegistration(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            var carDetails = GetVehicleDetails(vehicle.RegistrationNumber);
            if (carDetails != null)
            {
                throw new InvalidOperationException(nameof(vehicle.RegistrationNumber) + " is already registered. Please CheckIn");
            }

            _context.Vehicles.Add(vehicle);

            _context.SaveChanges();
        }

        public CheckInRepsonse CheckInCar(ParkedVehicle parkedVehicle)
        {
            var response = new CheckInRepsonse();

            if (parkedVehicle == null)
            {
                response.IsSuccess = false;
                response.Message = "Invalid details";
                return response;
            }

            var carDetails = GetVehicleDetails(parkedVehicle.VehicleRegistrationNumber);

            if (carDetails == null)
            {
                response.IsSuccess = false;
                response.Message = parkedVehicle.VehicleRegistrationNumber + " registration details not found. Please register your car.";
                return response;
            }

            var availableSlots = GetNumberOfSpaces(carDetails.ParkingAreaId);
            if (availableSlots > 0)
            {
                var detail = new ParkedVehicle
                {
                    VehicleRegistrationNumber = parkedVehicle.VehicleRegistrationNumber,
                    ParkingAreaId = carDetails.ParkingAreaId,
                    TimeArrived = DateTime.UtcNow

                };
                SaveParkedVehicleDetails(detail);
                response.IsSuccess = true;
                response.Message = "Check in successfull";
                return response;
            }
            else
            {
                var availableSlot = GetAvailablePakingArea();
                if (availableSlot != null)
                {
                    var detail = new ParkedVehicle
                    {
                        VehicleRegistrationNumber = parkedVehicle.VehicleRegistrationNumber,
                        ParkingAreaId = availableSlot.Value,
                        TimeArrived = DateTime.UtcNow
                    };
                    SaveParkedVehicleDetails(detail);
                    response.IsSuccess = true;
                    response.Message = "Your preferred area " + GetPakingArea(carDetails.ParkingAreaId) + " is Full.You have been checked into  " + GetPakingArea(availableSlot);
                    response.AlternativeParkingId = availableSlot.Value;
                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "All parking spaces are full. please try again later.";
                    return response;
                }
            }
        }

        private void SaveParkedVehicleDetails(ParkedVehicle parkedVehicle)
        {
            _context.ParkedVehicles.Add(parkedVehicle);
            var parkingArea = _context.ParkingAreas.Where(x => x.ParkingAreaId == parkedVehicle.ParkingAreaId).Single();
            parkingArea.NumberOfSpaces--;
            _context.SaveChanges();
        }

        public ParkedVehicle? GetParkedVehicleDetails(string regNumber)
        {
            return _context.ParkedVehicles.Where(x => x.VehicleRegistrationNumber == regNumber).SingleOrDefault();
        }

        public void CheckOutCar(ParkedVehicle parkedVehicle)
        {
            var carDetails = GetVehicleDetails(parkedVehicle.VehicleRegistrationNumber);
            var parkedVehicleDetails = GetParkedVehicleDetails(parkedVehicle.VehicleRegistrationNumber);

            if (carDetails == null)
            {
                throw new InvalidOperationException("Registration details not found.Please register your car.");
            }

            if (parkedVehicleDetails != null)
            {
                _context.ParkedVehicles.Remove(parkedVehicleDetails);
                var parkingArea = _context.ParkingAreas.Where(x => x.ParkingAreaId == parkedVehicleDetails.ParkingAreaId).Single();
                parkingArea.NumberOfSpaces++;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Car is not parked yet");
            }
        }

        public int GetNumberOfSpaces(int parkingAreaId)
        {
            var parkingArea = _context.Set<ParkingArea>().FromSqlRaw("Exec GetSlotsByParkArea {0}", parkingAreaId).AsEnumerable().Single();
            return parkingArea.NumberOfSpaces;
        }

        public int? GetAvailablePakingArea()
        {
            return _context.ParkingAreas.Where(x => x.NumberOfSpaces > 0)
                .Select(x => x.ParkingAreaId)
                .FirstOrDefault();
        }
        public Vehicle? GetVehicleDetails(string vehicleRegistrationNumber)
        {
            return _context.Set<Vehicle>().FromSqlRaw("Exec GetVehicleDetails {0}", vehicleRegistrationNumber).AsEnumerable().SingleOrDefault();
        }

        private string GetPakingArea(int? id)
        {
            return id switch
            {
                1 => "Car Park A",
                2 => "Car Park B",
                3 => "Car Park C",
                _ => "No spaces available to check in",
            };
        }
    }
}
