using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    /// <summary>
    /// Model of ticket 
    /// </summary>
    public class AirSegment
    {
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
    }
}
