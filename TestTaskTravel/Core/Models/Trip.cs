using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    /// <summary>
    /// Model of trip
    /// </summary>
    public class Trip
    {
        public string Id { get; set; }
        public string BookingDate { get; set; }
        public List<Traveller> Travellers { get; set; }
        public List<AirSegment> AirSegments { get; set; }
    }
}
