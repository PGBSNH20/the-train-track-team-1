using System.Collections.Generic;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var startLocation = new Location("2021/03/08 15:30", "2021/03/08 15:30", "Göteborg");
            var endLocation = new Location("2021/03/08 18:30", "2021/03/08 18:30", "Stockholm");
            var destinations = new List<Location>()
            {
		new Location("2021/03/08 15:31", "2021/03/08 15:32", "Alingsås"),
		new Location("2021/03/08 15:33", "2021/03/08 15:34", "Vårgårda"),
		new Location("2021/03/08 15:35", "2021/03/08 15:36", "Herrljunga"),
		new Location("2021/03/08 15:37", "2021/03/08 15:38", "Falköping"),
            };

            TrainSchedule schedule = new TrainSchedule(startLocation, endLocation, destinations);
          
            Train train = new Train(0, "X-2000", 250, true);
            TrackIO trackIO = new TrackIO();

            TrainSimulation simulation = new TrainSimulation(100, trackIO.ParseTrack()).AddSchedule(schedule).AddTrain(train).StartSimulation();
        }
    }
}
