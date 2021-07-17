using CarParkSystem.DbEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.ViewModels
{
    public class VehicleRegisterViewModel
    {
        [Required(ErrorMessage = "Please enter the Registration Number...")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }


        [Required(ErrorMessage = "Please enter the car Make...")]
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Please enter the car Model...")]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "Please enter the Colour...")]
        [Display(Name = "Colour")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Please enter the Date of purchase...")]
        [Display(Name = "Date of Purchase")]
        public DateTime DateOfPurchase { get; set; }

        [Required(ErrorMessage = "Please enter the car park area...")]
        [Display(Name = "Parking Area")]
        public int ParkingAreaId { get; set; }

        public IEnumerable<SelectListItem> ParkingAreaList
        {
            get
            {
                yield return new SelectListItem { Text = "Car Park A", Value = "1" };
                yield return new SelectListItem { Text = "Car Park B", Value = "2" };
                yield return new SelectListItem { Text = "Car Park C", Value = "3" };
            }
        }


    }
}
