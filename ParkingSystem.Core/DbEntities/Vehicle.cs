using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CarParkSystem.DbEntities
{
    public class Vehicle
    {
      
        [Key]
        public string RegistrationNumber { get; set; }
        
        public string Make { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }
        
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Date Of Purchase")]
        public DateTime DateOfPurchase { get; set; }

        public int ParkingAreaId { get; set; }

        [Display(Name = "Car Park Area")]
        public ParkingArea ParkingArea { get; set; }

    }
}
