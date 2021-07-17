using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkSystem.DbEntities
{
    public class ParkedVehicle
    {
        [Key]
        public int Id { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public Vehicle Vehicle { get; set; }

        
        public int ParkingAreaId { get; set; }
        public ParkingArea ParkingArea { get; set; }

        public DateTime  TimeArrived { get; set; }

    }
}
