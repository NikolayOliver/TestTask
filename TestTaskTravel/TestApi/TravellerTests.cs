using Core.Models;
using Core.ServiceHelpers;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestApi.Utilities;

namespace TestApi
{
    [TestClass]
    public class TravellerTests : BaseTest
    {
        TravellerService TravellerService;
        TravellerServiceHelper TravellerServiceHelper;

        [TestInitialize]
        public void Initialize()
        {
            TravellerServiceHelper = new TravellerServiceHelper();
            TravellerService = new TravellerService();
            FilePath = FileHelper.travellersJson;
            JsonHelper = new JsonHelper(FilePath);
        }

        [TestMethod]
        public void CreateTraveller_POST()
        {
            #region PreCondition

            var traveller = new Traveller()
            {
                FirstName = "Robert",
                LastName = "Pattison",
                PersonalNumber = RandomHelper.GetRandomInt(),
                Email = "JackMikelson1999@gmail.com"
            };
            #endregion PreCondition

            var response = TravellerService.CreateTraveller(traveller);

            DataCollectionClass<Traveller> dataCollection = JsonHelper.Deserialize<Traveller>();

            dataCollection.DataCollection.Add(traveller);
            JsonHelper.Serialize<Traveller>(dataCollection);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Incorrect creating of trip");
        }

        [TestMethod]
        public void GetAllTravellers_GET()
        {
            var trips = TravellerServiceHelper.GetTravellers();

            var tripsFromJson = JsonHelper.Deserialize<Trip>();
            var trips2020Year = tripsFromJson.DataCollection.Where(t => t.BookingDate.Contains("2020")).ToList();

            Assert.AreEqual(10, trips.Count, "Incorrect count of trips");
        }

        [TestMethod]
        public void GetTravellerByPersonalNumber_GET()
        {
            var trips = TravellerServiceHelper.GetTravellers();
            var firstTrip = trips.FirstOrDefault();
            var firstTripPersonalNumber = firstTrip.PersonalNumber;

            var tripById = TravellerServiceHelper.GetTravelllerByPersonalNumber(firstTripPersonalNumber.ToString());

            var tripsFromJson = JsonHelper.Deserialize<Trip>();

            Assert.AreEqual(firstTripPersonalNumber, tripById, "GetById request returned incorrect responce");
        }

        [TestMethod]
        public void DeleteTravellerById_DELETE()
        {
            var trips = TravellerServiceHelper.GetTravellers();
            var firstTrip = trips.FirstOrDefault();
            var firstTripPersonalNumber = firstTrip.PersonalNumber;

            TravellerServiceHelper.DeleteTravellerByPersonalNumber(firstTripPersonalNumber.ToString());
            var tripsAfterDeleting = TravellerServiceHelper.GetTravellers();
            var tripsIdsAfterDeleting = tripsAfterDeleting.Select(x => x.PersonalNumber).ToList();

            var tripsFromJson = JsonHelper.Deserialize<Trip>();
            var tripId = tripsFromJson.DataCollection.Find(x => x.Id.Equals(firstTripPersonalNumber));
            tripsFromJson.DataCollection.Remove(tripId);

            Assert.IsFalse(tripsIdsAfterDeleting.Contains(firstTripPersonalNumber), "Trip didn't delete");
        }
    }
}
