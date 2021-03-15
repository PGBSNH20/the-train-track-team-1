﻿using System;
using System.Collections.Generic;
using System.IO;
using TrainEngine;
using TrainEngine.Models;
using TrainEngine.Interfaces;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate new route with each run if route doesn't exist so debugging is consistent between users
            string RouteName = "Route1"; //This is what we decide to call a specific route. It is a folder containing track.txt and route.txt
            List<Location> destinationsToGenerateRoute = new List<Location>(){
                new Location("2021/03/08 15:30", "Göteborg"),
                new Location("2021/03/08 15:52", "Alingsås"),
                new Location("2021/03/08 16:23", "Vårgårda"),
                new Location("2021/03/08 17:42", "Herrljunga"),
                new Location("2021/03/08 18:50", "Falköping"),
                new Location("2021/03/08 19:30", "Stockholm")
            };

            if (!Directory.Exists(Environment.CurrentDirectory + "/" + RouteName))
            {
             TrainSchedule.GenerateRoute(RouteName, destinationsToGenerateRoute);
            }
            
            var destinations = TrainSchedule.ParseRoute(RouteName); //Here we put the RouteName
            ITrackIO trackIO = new TrackIO(RouteName); //Here we put the RouteName
            
            Train[] trains = new TrainSomethingYouCanChooseABetterName().Parse("trains.txt");
            trackIO.Parse();

            ITrainSimulation simulation = new TrainSimulation(100, trackIO).AddDestinations(destinations).AddTrain(trains[0]);
            simulation.Start();

            //trains[0] because we only have one train at the moment. But trains.txt can and will contain multiple ones.
        }

    }
}
