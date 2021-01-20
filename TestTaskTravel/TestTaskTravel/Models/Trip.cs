using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTravel.Models
{
    public class Trip : MainModel
    {
        public string Id { get; set; }
        public string BookingDate { get; set; }
        public List<Traveler> Travelers { get; set; }
        public List<AirSegment> AirSegments { get; set; }

        public override string GetFileName() => "Trips.json";
    }
}
