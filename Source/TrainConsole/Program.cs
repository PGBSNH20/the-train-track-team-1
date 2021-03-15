using System.Collections.Generic;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var destinations = new List<Location>()
            {
        new Location("2021/03/08 15:30", "Göteborg"),
        new Location("2021/03/08 15:52", "Alingsås"),
		new Location("2021/03/08 16:23", "Vårgårda"),
		new Location("2021/03/08 17:42", "Herrljunga"),
		new Location("2021/03/08 18:50", "Falköping"),
        new Location("2021/03/08 19:30", "Stockholm")
            };

            Train train = new Train(0, "X-2000", 250, true);
            ITrackIO trackIO = new TrackIO();
            trackIO.Parse();

            TrainSimulation simulation = new TrainSimulation(100, trackIO).AddDestinations(destinations).AddTrain(train).StartSimulation();
        }
    }
}
