using System;
using System.Collections.Generic;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string RouteName = "Route1"; //This is what we decide to call a specific route. It is a folder containing track.txt and route.txt
            var destinations = TrainSchedule.ParseRoute(RouteName); //Here we put the RouteName
            ITrackIO trackIO = new TrackIO(RouteName); //Here we put the RouteName
            
            Train[] trains = Train.ParseTrain("trains.txt");
            trackIO.Parse();

            
            //TrainSchedule.SaveRoute(destinations, "Route2"); 
            //TrackIO.ExportTrack("[A]------[B]----[C]---[D]---=--[E]---[F]", "Route2");

            TrainSimulation simulation = new TrainSimulation(100, trackIO).AddDestinations(destinations).AddTrain(trains[0]).StartSimulation(); 
            //trains[0] because we only have one train at the moment. But trains.txt can and will contain multiple ones.
        }
    }
}
