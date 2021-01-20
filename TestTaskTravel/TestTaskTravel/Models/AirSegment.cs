using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTravel.Models
{
    public class AirSegment : MainModel
    {
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }

        public override string GetFileName() => "1.json";
    }
}
