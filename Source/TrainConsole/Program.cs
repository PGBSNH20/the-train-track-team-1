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

            TrainPlanner planner = new TrainPlanner();
            planner.FollowSchedule(schedule);
        }
    }
}
