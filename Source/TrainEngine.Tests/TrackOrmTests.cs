using System;
using Xunit;

namespace TrainEngine.Tests
{
    public class TrackOrmTests
    {
        [Fact]
        public void OneTrackWithOnlyEndAndStartStations()
        {
            // Arrange
            ITrackIO trackOrm = new TrackIO();
            trackOrm.Parse();

            // Act
            var First = trackOrm.Track.StationsID[1];
            var Last = trackOrm.Track.StationsID[trackOrm.Track.StationsID.Count - 1];
            Station[] result = {First, Last};

            // Assert
            Assert.Equal(2, result.Length);
        }

        [Fact]
        public void OneTrackWithIntermediateStations()
        {
            // Arrange
            ITrackIO trackOrm = new TrackIO();
            trackOrm.Parse();

            // Act
            var result = trackOrm.Track.StationsID.Count;

            // Assert
            Assert.Equal(3, result);
        }
    }
}
