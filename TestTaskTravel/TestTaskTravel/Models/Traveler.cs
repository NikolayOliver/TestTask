using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTravel.Models
{
    public class Traveler : MainModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalNumber { get; set; }
        public string Email { get; set; }

       
        public override string GetFileName()  => "OneTravelerInforamation.json";
    }
}
