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
        public void ParseTrain()
        {
            Train[] trains = Train.Parse("trains.txt");

            Assert.Equal(0, trains[0].id);
            Assert.False(trains[0].inUse);
            Assert.Equal(250, trains[0].maxSpeedKmh);
            Assert.Equal("X-2000", trains[0].name);
        }

        [Fact]
        //First you need to create a route that have a parse error in the route.txt file
        public void ParseDestinationsWithError()
        {
            Action actionResult = () => TrainSchedule.ParseRoute("TestRoute1", true);
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

            Assert.Equal(6, result);
        }
    }
}
