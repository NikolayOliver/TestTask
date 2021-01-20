using Core.Models;
using Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceHelpers
{
    /// <summary>
    /// Traveller service helper
    /// </summary>
    public class TravellerServiceHelper : BaseServiceHelper<TravellerService>
    {
        public TravellerServiceHelper()
        {
            Service = new TravellerService();
        }

        /// <summary>
        /// Create traveller
        /// </summary>
        /// <param name="traveller">Model of traveller</param>
        public Traveller CreateTraveller(Traveller traveller)
        {
            var response = Service.CreateTraveller(traveller);

            var cratedTraveller = JsonConvert.DeserializeObject<Traveller>(response.Content);

            return cratedTraveller;
        }

        /// <summary>
        /// Get all travellers
        /// </summary>
        public List<Traveller> GetTravellers()
        {
            var response = Service.GetTravellers();

            var listTraveller = JsonConvert.DeserializeObject<List<Traveller>>(response.Content);

            return listTraveller;
        }

        /// <summary>
        /// Get traveller by personal number
        /// </summary>
        public Traveller GetTravelllerByPersonalNumber(string personalNumber)
        {
            var response = Service.GetTravellerByPersonalNumber(personalNumber);

            var traveller = JsonConvert.DeserializeObject<Traveller>(response.Content);

            return traveller;
        }

        /// <summary>
        /// Delete traveller by his personal number
        /// </summary>
        public void DeleteTravellerByPersonalNumber(string personalNumber) => Service.DeleteTraveller(personalNumber);
    }
}
