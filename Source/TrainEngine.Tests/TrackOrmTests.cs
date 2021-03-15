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
            var result = 0;
            if (!String.IsNullOrWhiteSpace(trackOrm.Track.EndLocationID) && !String.IsNullOrWhiteSpace(trackOrm.Track.EndLocationID))
            {
                result = 2;
            }

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void OneTrackWithIntermediateStations()
        {
            // Arrange
            ITrackIO trackOrm = new TrackIO();
            trackOrm.Parse();

            // Act
            var result = trackOrm.Track.IntermediateStationsID.Count;

            // Assert
            Assert.Equal(1, result);
        }
    }
}
