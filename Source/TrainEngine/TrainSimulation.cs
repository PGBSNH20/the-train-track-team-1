using System;
using System.Collections.Generic;
using System.Threading;

namespace TrainEngine
{
    public class TrainSimulation
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

        public TrainSimulation AddTrain(Train train)
        {
            if (this.train != null)
            {
                throw new Exception("There can only be one train");
            }

            this.train = train;
            return this;
        }
        public TrainSimulation AddDestinations(List<Location> locations)
        {
            if (this.locations != null)
            {
                throw new Exception("There can only be on locations");
            }

            this.locations = locations;
            return this;
        }

        public TrainSimulation StartSimulation()
        {
            // Checks to see if everything is in order for the simulation i.e a train & locations exists
            ValidateSimulation();

            currentTime = locations[0].departureTime;
            Console.WriteLine($"Train {train.name} (max speed {train.maxSpeedKmh}km/h) starting its route from " +
                $"{locations[0].destinationName} - {locations[locations.Count-1].destinationName} at {locations[0].departureTime}");

            // Run stopwatch on a seperate thread
            Thread thread = new Thread(new ThreadStart(StartStopwatch));
            thread.IsBackground = true;
            thread.Start();

            List<Location> passedDestinations = new List<Location>();
            int trainPositionIndex = 0;
            foreach (Location dest in locations)
            {
                Console.WriteLine($"Departuring from {dest.destinationName} at {dest.departureTime}");

                int passedDestinationsLength = passedDestinations.Count;
                while (passedDestinations.Count == passedDestinationsLength)
                {
                    Console.WriteLine("..---.....---..");

                    Thread.Sleep(1000);
                    trainPositionIndex++;

                    if(IsAtCrossing(trainPositionIndex))
                    {
                        Console.WriteLine("Arrived at level-crossing, waiting...");
                        Thread.Sleep(1000);
                    }

                    foreach (Station s in trackIO.Track.IntermediateStationsID)
                    {
                        if (s.Distance == trainPositionIndex)
                        {
                            passedDestinations.Add(dest);
                        }
                    }
                }

                Console.WriteLine($"Arrived at {dest.destinationName} at {currentTime}");
                Thread.Sleep(1000);
                Console.WriteLine($"Train departuring in {dest.departureTime.Subtract(currentTime)}");

                while (currentTime < dest.departureTime)
                {
                    Thread.Sleep(500);
                }
            }

            Console.WriteLine($"\nFinal destination {locations[locations.Count-1].destinationName} has been reached. @{currentTime.TimeOfDay}");
            return this;
        }

        private void ValidateSimulation()
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
            while(true)
            {
                Thread.Sleep((int)(60000 / realtimeMultiplier));
                currentTime = currentTime.AddMinutes(1);
            }
        }
    }
}
