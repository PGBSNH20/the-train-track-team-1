using System;
using System.Collections.Generic;
using System.Threading;
using TrainEngine.Models;
using TrainEngine.Interfaces;

namespace TrainEngine
{
    public class TrainSimulation : ITrainSimulation
    {
        private double realtimeMultiplier; // Realtime divided by times value (ex 10 is 10x faster)
        private ITrackIO trackIO;
        private Train train = null;
        private List<Location> locations = null;
        private DateTime currentTime;
        public TrainSimulation(double realtimeMultiplier, ITrackIO trackIO)
        {
            this.realtimeMultiplier = realtimeMultiplier;
            this.trackIO = trackIO;
        }

        public ITrainSimulation AddTrain(Train train)
        {
            if (this.train != null)
            {
                throw new Exception("There can only be one train");
            }

            this.train = train;
            return this;
        }
        public ITrainSimulation AddDestinations(List<Location> locations)
        {
            if (this.locations != null)
            {
                throw new Exception("There can only be on locations");
            }

            this.locations = locations;
            return this;
        }

        private void StartSimulation()
        {
            // Checks to see if everything is in order for the simulation i.e a train & locations exists
            Validate();

            currentTime = locations[0].departureTime;
            Console.WriteLine($"Train {train.name} (max speed {train.maxSpeedKmh}km/h) starting its route from " +
                $"{locations[0].destinationName} - {locations[locations.Count - 1].destinationName} at {currentTime}");

            // Run stopwatch on a seperate thread
            Thread thread = new Thread(new ThreadStart(StartStopwatch));
            thread.IsBackground = false; // Run in foreground to avoid clock ticking when application has closed
            thread.Start();

            List<Location> passedDestinations = new List<Location>();
            int trainPositionIndex = 0;
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"Departuring from {locations[i].destinationName} at {currentTime}");

                int passedDestinationsLength = passedDestinations.Count;
                while (passedDestinations.Count == passedDestinationsLength)
                {
                    Console.WriteLine("..---.....---..");

                    Thread.Sleep(1000);
                    trainPositionIndex++;

                    if (IsAtCrossing(trainPositionIndex))
                    {
                        Console.WriteLine("Arrived at level-crossing, waiting...");
                        Thread.Sleep(1000);
                    }

                    foreach (Station s in trackIO.Track.StationsID)
                    {
                        if (s.Distance == trainPositionIndex)
                        {
                            passedDestinations.Add(locations[i]);
                        }
                    }
                }

                // End location reached
                if (i == locations.Count - 2)
                {
                    break;
                }

                Console.WriteLine($"Arrived at {locations[i + 1].destinationName} at {currentTime}");
                Thread.Sleep(1000);
                Console.WriteLine($"Train departuring in {locations[i + 1].departureTime.Subtract(currentTime)}");

                while (currentTime < locations[i + 1].departureTime)
                {
                    Thread.Sleep(500);
                }
            }

            Console.WriteLine($"\nFinal destination {locations[locations.Count - 1].destinationName} has been reached. @{currentTime.TimeOfDay}");
        }

        public void Start()
        {
            Thread simulationThread = new Thread(new ThreadStart(StartSimulation));
            simulationThread.IsBackground = false;
            simulationThread.Start();
        }

        private void Validate()
        {
            if (train == null)
            {
                throw new Exception("You need a train in order to start the simulation");
            }

            if (locations == null)
            {
                throw new Exception("You need a locations in order to start the simulation");
            }
            if (trackIO == null)
            {
                throw new Exception("You need a track in order to start the simulation");
            }
        }

        private bool IsAtCrossing(int index)
        {
            return trackIO.Track.LevelCrossing.Location == index ? true : false;
        }

        private void StartStopwatch()
        {
            while (true)
            {
                Thread.Sleep((int)(60000 / realtimeMultiplier));
                currentTime = currentTime.AddMinutes(1);
            }
        }
    }
}
