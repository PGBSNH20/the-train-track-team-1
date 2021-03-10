using System;
using System.Collections.Generic;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            Track track = new Track();
            TrackIO trackIO = new TrackIO();
            track = trackIO.ParseTrack();
            Console.WriteLine("StartLocation: " + track.StartLocation);
            Console.WriteLine("EndLocation: " + track.EndLocation);
            Console.WriteLine("Total Distance: " + track.TotalDistance + "KM");

            /*
            TrainSchedule schedule = new TrainSchedule("Göteborg", "Stockholm", 
                new DateTime(2021, 03, 08, 15, 30, 00), new DateTime(2021, 03, 08, 18, 30, 00), new List<Destination>()
                {
                    new Destination(new DateTime(2021, 03, 08, 15, 31, 00), new DateTime(2021, 03, 08, 15, 32, 00), "Alingsås"),
                    new Destination(new DateTime(2021, 03, 08, 15, 33, 00), new DateTime(2021, 03, 08, 15, 34, 00), "Vårgårda"),
                    new Destination(new DateTime(2021, 03, 08, 15, 35, 00), new DateTime(2021, 03, 08, 15, 36, 00), "Herrljunga"),
                    new Destination(new DateTime(2021, 03, 08, 15, 37, 00), new DateTime(2021, 03, 08, 15, 38, 00), "Falköping"),
                });;
    
            TrainPlanner planner = new TrainPlanner();
            planner.FollowSchedule(schedule);
            */
        }
    }
}
