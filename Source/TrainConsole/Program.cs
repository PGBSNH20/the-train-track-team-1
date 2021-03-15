using System;
using System.Collections.Generic;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var destinations = TrainSchedule.ParseRoute("route1.txt");
            Train[] trains = Train.ParseTrain("trains.txt");
            ITrackIO trackIO = new TrackIO();
            trackIO.Parse();
            TrainSimulation simulation = new TrainSimulation(100, trackIO).AddDestinations(destinations).AddTrain(trains[0]).StartSimulation(); 
            //trains[0] because we only have one train at the moment. But trains.txt can and will contain multiple ones.
            

        }
    }
}
