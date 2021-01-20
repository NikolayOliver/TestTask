using Core.Models;
using Core.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.ServiceHelpers
{
    /// <summary>
    /// Service helper trip
    /// </summary>
    public class TripServiceHelper : BaseServiceHelper<TripService>
    {
        public TripServiceHelper()
        {
            Service = new TripService();
        }

        /// <summary>
        /// Create trip
        /// </summary>
        /// <param name="trip">Model of trip</param>
        public Trip CreateTrip(Trip trip)
        {
            var response = Service.CreateTrip(trip);

            var createdTrip = JsonConvert.DeserializeObject<Trip>(response.Content);

            return createdTrip;
        }

        /// <summary>
        /// Get all trips
        /// </summary>
        public List<Trip> GetTrips()
        {
            var response = Service.GetTrips();

            var listTrips = JsonConvert.DeserializeObject<List<Trip>>(response.Content);

            return listTrips;
        }

        /// <summary>
        /// Get trip by id
        /// </summary>
        public Trip GetTripById(string id)
        {
            var response = Service.GetTripById(id);

            var trip = JsonConvert.DeserializeObject<Trip>(response.Content);

            return trip;
        }

        /// <summary>
        /// Delete trip by id
        /// </summary>
        public void DeleteTripById(string id) => Service.DeleteTrip(id);
    }
}
