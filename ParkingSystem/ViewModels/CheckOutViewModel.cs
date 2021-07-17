using CarParkSystem.DbEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSystem.ViewModels
{
    public class CheckOutViewModel
    {
        [Required(ErrorMessage = "Please enter your vehicle registration Number...")]
        [Display(Name = "Registration Number")]

        public string RegistrationNumber { get; set; }

        public string Message { get; set; } = "";
    }
}
