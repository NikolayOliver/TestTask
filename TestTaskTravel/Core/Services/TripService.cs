using Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    /// <summary>
    /// Trip Service
    /// </summary>
    public class TripService : BaseService
    {
        /// <summary>
        /// Request to create trip
        /// </summary>
        /// <param name="traveller">Trip model</param>
        public IRestResponse CreateTrip(Trip trip)
        {
            Request.Method = Method.POST;
            Request.Resource = "/api/v1/Trip";

            Request.AddHeader("ContentType", "application/json");
            Request.AddHeader("ContentType", "text/plain");
            Request.AddJsonBody(trip);

            return Client.Execute(Request);
        }

        /// <summary>
        /// Request to get all trips
        /// </summary>
        public IRestResponse GetTrips()
        {
            Request.Method = Method.GET;
            Request.Resource = "/api/v1/Trip";

            Request.AddHeader("ContentType", "application/json");

            return Client.Execute(Request);
        }

        /// <summary>
        /// Request to get trip by id
        /// </summary>
        public IRestResponse GetTripById(string id)
        {
            Request.Method = Method.GET;
            Request.Resource = $"/api/v1/Trip/{id}";

            Request.AddHeader("ContentType", "application/json");

            return Client.Execute(Request);
        }

        /// <summary>
        /// Request to delete trip by id
        /// </summary>
        public IRestResponse DeleteTrip(string id)
        {
            Request.Method = Method.POST;
            Request.Resource = "/api/v1/Trip";

            Request.AddHeader("ContentType", "application/json");
            Request.AddHeader("ContentType", "text/plain");
            Request.AddJsonBody(id);

            return Client.Execute(Request);
        }
    }
}
