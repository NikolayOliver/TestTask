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
    /// Traveller service
    /// </summary>
    public class TravellerService : BaseService
    {
        /// <summary>
        /// Request to create traveller
        /// </summary>
        /// <param name="traveller">Traveller model</param>
        public IRestResponse CreateTraveller(Traveller traveller)
        {
            Request.Method = Method.POST;
            Request.Resource = "/api/v1/Traveller";

            Request.AddHeader("ContentType", "application/json");
            Request.AddHeader("ContentType", "text/plain");
            Request.AddJsonBody(traveller);

            return Client.Execute(Request);
        }

        /// <summary>
        /// Request to get all travellers
        /// </summary>
        /// <returns></returns>
        public IRestResponse GetTravellers()
        {
            Request.Method = Method.GET;
            Request.Resource = "/api/v1/Traveller";

            Request.AddHeader("ContentType", "application/json");
            Request.AddHeader("ContentType", "text/plain");

            return Client.Execute(Request);
        }

        /// <summary>
        /// Request to delete traveller by personalNumber
        /// </summary>
        public IRestResponse DeleteTraveller(string personalNumber)
        {
            Request.Method = Method.DELETE;
            Request.Resource = $"/api/v1/Traveller/{personalNumber}";

            Request.AddHeader("ContentType", "application/json");

            return Client.Execute(Request);
        }

        /// <summary>
        /// Request to get traveller by personalNumber
        /// </summary>
        public IRestResponse GetTravellerByPersonalNumber(string personalNumber)
        {
            Request.Method = Method.GET;
            Request.Resource = $"/api/v1/Traveller/{personalNumber}";

            Request.AddHeader("ContentType", "application/json");
            Request.AddHeader("ContentType", "text/plain");

            return Client.Execute(Request);
        }
    }
}
