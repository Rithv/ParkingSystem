using CarParkSystem.DbEntities;
using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Core.Services;
using ParkingSystem.ViewModels;
using System;


namespace ParkingSystem.Controllers
{
    public class VehicleRegisterController : Controller
    {
        private readonly IParkingSystemRepository _repo;
        public VehicleRegisterController(IParkingSystemRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(VehicleRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = new Vehicle
                    {
                        RegistrationNumber = model.RegistrationNumber,
                        Make = model.Make,
                        Model = model.CarModel,
                        Color = model.Color,
                        DateOfPurchase = model.DateOfPurchase,
                        ParkingAreaId = model.ParkingAreaId
                    };
                    _repo.CarRegistration(vehicle);
                    var checkInModel = new CheckInViewModel
                    {
                        RegistrationNumber = model.RegistrationNumber,
                        Message = "Your Registration is successfull. Please CheckIn"
                    };
                    return RedirectToAction("CheckIn", "VehicleRegister", checkInModel);
                }
                catch (Exception ex)
                {
                    var checkInModel = new CheckInViewModel
                    {
                        RegistrationNumber = model.RegistrationNumber,
                        Message = ex.Message
                    };
                    return RedirectToAction("CheckIn", "VehicleRegister", checkInModel);
                }
            }
            return View(model);
        }

        public IActionResult CheckIn()
        {
            var model = new CheckInViewModel
            {
                Message = string.Empty
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckIn(CheckInViewModel model)
        {
            var parkedVehicledetails = new ParkedVehicle
            {
                VehicleRegistrationNumber = model.RegistrationNumber,
            };

            var result = _repo.CheckInCar(parkedVehicledetails);
            model.Message = result.Message;
           
            return View(model);
        }

        public IActionResult CheckOut()
        {
            var model = new CheckOutViewModel
            {
                Message = string.Empty
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOut(CheckOutViewModel model)
        {
            var parkedVehicleDetials = new ParkedVehicle
            {
                VehicleRegistrationNumber = model.RegistrationNumber
            };

            try
            {
                _repo.CheckOutCar(parkedVehicleDetials);
                model.Message = "Checkout successfull.";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }

            return View(model);
        }
    }
}
