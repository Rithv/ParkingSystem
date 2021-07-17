using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkSystem.DbEntities
{
    public class ParkingArea
    {
        [Key]
        public int ParkingAreaId { get; set;}

        public int NumberOfSpaces { get; set; }
    }
}
