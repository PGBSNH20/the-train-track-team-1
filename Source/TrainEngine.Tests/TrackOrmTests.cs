using System;
using System.Collections.Generic;
using Xunit;
using TrainEngine;
using TrainEngine.Models;
using TrainEngine.Interfaces;
using System.IO;

namespace TrainEngine.Tests
{
    public class TrackOrmTests
    {
        [Fact]
        public void test()
        {
            string RouteName = "RouteTest"; //This is what we decide to call a specific route. It is a folder containing track.txt and route.txt
            List<Location> destinationsToGenerateRoute = new List<Location>(){
                new Location("2021/03/08 15:30", "Göteborg"),
                new Location("2021/03/08 15:52", "Alingsås"),
                new Location("2021/03/08 16:23", "Vårgårda"),
                new Location("2021/03/08 17:42", "Herrljunga"),
                new Location("2021/03/08 18:50", "Falköping"),
                new Location("2021/03/08 19:30", "Stockholm")
            };

            if (!Directory.Exists(Environment.CurrentDirectory + "/TrainRoutes/" + RouteName))
            {
                TrainSchedule.GenerateRoute(RouteName, destinationsToGenerateRoute);
            }

            var destinations = TrainSchedule.ParseRoute(RouteName); //Here we put the RouteName
            ITrackIO trackIO = new TrackIO(RouteName); //Here we put the RouteName

            Train[] trains = new TrainSomethingYouCanChooseABetterName().Parse("trains.txt");
            trackIO.Parse();

            ITrainSimulation simulation = new TrainSimulation(100, trackIO).AddDestinations(destinations).AddTrain(trains[0]);


        }

        [Fact]
        public void ParseDestinationsWithError()
        {
            Action actionResult = () => TrainSchedule.ParseRoute("Route2", true);
            Exception exeptionResult = Assert.Throws<Exception>(actionResult);
            
            Assert.Equal("Something was wrong with the devider charecter", exeptionResult.Message);
        }

        [Fact]
        public void OneTrackWithOnlyEndAndStartStations()
        {
            ITrackIO trackOrm = new TrackIO("Route1");
            trackOrm.Parse(true);

            var First = trackOrm.Track.StationsID[1];
            var Last = trackOrm.Track.StationsID[trackOrm.Track.StationsID.Count - 1];
            Station[] result = { First, Last };

            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void OneTrackWithIntermediateStations()
        {
            ITrackIO trackOrm = new TrackIO("Route1");
            trackOrm.Parse(true);

            var result = trackOrm.Track.StationsID.Count;

            Assert.Equal(5, result);
        }
    }
}
