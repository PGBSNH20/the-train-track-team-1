using System;
using System.Collections.Generic;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ITrackIO trackIO = new TrackIO(Environment.CurrentDirectory + @"/track.txt");
            trackIO.Parse();
            Console.WriteLine($"Start: {trackIO.Track.StartLocation}\n");
            Console.WriteLine("Intermediate stations!");
            foreach (var station in trackIO.Track.IntermediateStations)
            {
                Console.WriteLine($"Name:{station.Name}\nDistance: {station.Distance}");
            }
            Console.WriteLine($"\nEnd: {trackIO.Track.EndLocation}");
            Console.WriteLine($"Total distance: {trackIO.Track.TotalDistance}");
        }
    }
}
