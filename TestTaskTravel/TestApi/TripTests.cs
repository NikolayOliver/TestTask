using Core.Models;
using Core.ServiceHelpers;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TestApi.Utilities;

namespace TestApi
{
    [TestClass]
    public class TripTests : BaseTest
    {
        TripServiceHelper TripServiceHelper;
        TripService TripService;

        [TestInitialize]
        public void Initialize()
        {
            TripServiceHelper = new TripServiceHelper();
            TripService = new TripService();
            FilePath = FileHelper.tripsJson;
            JsonHelper = new JsonHelper(FilePath);
        }

        [TestMethod]
        public void CreateTrip_POST()
        {
            var airSegment = new AirSegment()
            {
                ArrivalAirportCode = RandomHelper.GetRandomGuid(),
                ArrivalDate = "Jan 20, 2020, 12:30:00",
                DepartureAirportCode = RandomHelper.GetRandomGuid(),
                DepartureDate = "Jan 20, 2020, 12:30:00"
            };

            var traveller = new Traveller()
            {
                FirstName = "JOE",
                LastName = "Soda",
                PersonalNumber = 5,
                Email = "JackMikelson1999@gmail.com"
            };

            Trip trip = new Trip()
            {
                Id = RandomHelper.GetRandomGuid(),
                BookingDate = "Jan 20, 2020, 12:30:00",
                AirSegments = new List<AirSegment>() { airSegment },
                Travellers = new List<Traveller>() { traveller }
            };

            var response = TripService.CreateTrip(trip);

            DataCollectionClass<Trip> dataCollection = JsonHelper.Deserialize<Trip>();

            dataCollection.DataCollection.Add(trip);
            JsonHelper.Serialize<Trip>(dataCollection);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Incorrect creating of trip");
        }

        [TestMethod]
        public void GetAllTrips_GET()
        {
            var trips = TripServiceHelper.GetTrips();

            var tripsFromJson = JsonHelper.Deserialize<Trip>();
            var trips2020Year = tripsFromJson.DataCollection.Where(t => t.BookingDate.Contains("2020")).ToList();

            Assert.AreEqual(10, trips.Count, "Incorrect count of trips");
        }

        [TestMethod]
        public void GetTripById_GET()
        {
            var trips = TripServiceHelper.GetTrips();
            var firstTrip = trips.FirstOrDefault();
            var firstTripId = firstTrip.Id;

            var tripById = TripServiceHelper.GetTripById(firstTripId);

            var tripsFromJson = JsonHelper.Deserialize<Trip>();

            Assert.AreEqual(firstTripId, tripById, "GetById request returned incorrect responce");
        }

        [TestMethod]
        public void DeleteTripById_DELETE()
        {
            var trips = TripServiceHelper.GetTrips();
            var firstTrip = trips.FirstOrDefault();
            var firstTripId = firstTrip.Id;

            TripServiceHelper.DeleteTripById(firstTripId);
            var tripsAfterDeleting = TripServiceHelper.GetTrips();
            var tripsIdsAfterDeleting = tripsAfterDeleting.Select(x => x.Id).ToList();

            var tripsFromJson = JsonHelper.Deserialize<Trip>();
            var tripId = tripsFromJson.DataCollection.Find(x => x.Id.Equals(firstTripId));
            tripsFromJson.DataCollection.Remove(tripId);

            Assert.IsFalse(tripsIdsAfterDeleting.Contains(firstTripId), "Trip didn't delete");
        }
    }
}
