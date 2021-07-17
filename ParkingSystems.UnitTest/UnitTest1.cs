using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarParkSystem.Core;
using CarParkSystem.DbEntities;
using Microsoft.EntityFrameworkCore;
using Moq;
using ParkingSystem.Core.Services;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace ParkingSystem.UnitTests
{
    [TestClass]
    public class VehicleRegistationTest
    {
        private readonly Mock<IParkingSystemRepository> _parkingRepositoryMock;

        public VehicleRegistationTest()
        {
            _parkingRepositoryMock = new Mock<IParkingSystemRepository>();
        }

        [TestMethod]
        [Fact(DisplayName = "Vehicle registration successfull")]
        public void CreateVehicleRegistrationSuccessfull()
        {
            var mockVehicleSet = new Mock<DbSet<Vehicle>>();

            var mockContext = new Mock<MainDbContext>();
            mockContext.Setup(m => m.Vehicles).Returns(mockVehicleSet.Object);
            
            var service = new ParkingSystemRepository(mockContext.Object);
            var vehicle = GetVehicle();
            service.CarRegistration(vehicle);

            mockVehicleSet.Verify(m => m.Add(It.IsAny<Vehicle>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact(DisplayName = "Vehicle registration check in successful")]
        public void CheckInSuccessfull()
        {
            var mockVehicleSet = new Mock<DbSet<Vehicle>>();

            var mockContext = new Mock<MainDbContext>();
            mockContext.Setup(m => m.Vehicles).Returns(mockVehicleSet.Object);

            var service = new ParkingSystemRepository(mockContext.Object);
            var vehicle = GetVehicle();
            service.CarRegistration(vehicle);

            var parkedVehicle = ParkedVehicle(10);
            var result = service.CheckInCar(parkedVehicle);

            Assert.IsTrue(result.IsSuccess);
        }

        [Fact(DisplayName = "Check in unsuccessful. Car parks full.")]
        public void CheckInUnSuccessfull()
        {
            var mockVehicleSet = new Mock<DbSet<Vehicle>>();
            var mockParkingAreaSet = new Mock<DbSet<ParkingArea>>();
            

            var mockContext = new Mock<MainDbContext>();
            mockContext.Setup(m => m.Vehicles).Returns(mockVehicleSet.Object);
            mockContext.Setup(m => m.ParkingAreas).Returns(mockParkingAreaSet.Object);

            var service = new ParkingSystemRepository(mockContext.Object);
            var vehicle = GetVehicle();
            service.CarRegistration(vehicle);

            var parkedVehicle = ParkedVehicle(0);
            var result = service.CheckInCar(parkedVehicle);

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.Message, "All parking spaces are full. please try again later.");
        }



        [Fact(DisplayName = "Vehicle registration check in successful")]
        public void CheckOutSuccessfull()
        {
            var mockVehicleSet = new Mock<DbSet<ParkedVehicle>>();

            var mockContext = new Mock<MainDbContext>();
            mockContext.Setup(m => m.ParkedVehicles).Returns(mockVehicleSet.Object);

            var service = new ParkingSystemRepository(mockContext.Object);
            var vehicle = GetVehicle();
            service.CarRegistration(vehicle);

            var parkedVehicle = ParkedVehicle(10);
            service.CheckOutCar(parkedVehicle);

            mockVehicleSet.Verify(m => m.Remove(It.IsAny<ParkedVehicle>()), Times.Once());
        }

        private ParkedVehicle ParkedVehicle(int numberOfSpaces)
        {
            return new ParkedVehicle
            {
                ParkingAreaId = 1,
                ParkingArea = new ParkingArea
                {
                    ParkingAreaId = 1,
                    NumberOfSpaces = numberOfSpaces
                },
                Vehicle = GetVehicle(),
                VehicleRegistrationNumber = "Bn12 sdf",
                TimeArrived = DateTime.Now
            };
        }

        private Vehicle GetVehicle()
        {
            return new Vehicle
            {
                RegistrationNumber = "Bn12 sdf",
                Color = "blue",
                Make = "toyota",
                Model = "yaris",
                ParkingAreaId = 1,
                ParkingArea = new ParkingArea
                {
                    ParkingAreaId = 1,
                    NumberOfSpaces = 10
                },
                DateOfPurchase = DateTime.Now
            };
        }
    }
}
