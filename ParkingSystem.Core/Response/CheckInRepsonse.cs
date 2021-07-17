using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Core.Response
{
    public class CheckInRepsonse
    {
        public bool IsSuccess { get; set; }

        public int AlternativeParkingId { get; set; }

        public string  Message { get; set; }
    }
}
