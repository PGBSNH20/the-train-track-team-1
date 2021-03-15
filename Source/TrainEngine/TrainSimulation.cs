using System;
using System.Collections.Generic;
using System.Threading;
using static TrainEngine.TrackIO;

namespace TrainEngine
{
    public class TrainSimulation
    {
        private double realtimeMultiplier; // Realtime divided by times value (ex 10 is 10x faster)
        private Track track;
        private Train train = null;
        private TrainSchedule schedule = null;
        public TrainSimulation(double realtimeMultiplier, Track track)
        {
            this.realtimeMultiplier = realtimeMultiplier;
            this.TrackIO = trackIO;
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
        public TrainSimulation AddSchedule(TrainSchedule schedule)
        {
            if (this.schedule != null)
            {
                throw new Exception("There can only be on schedule");
            }

            this.schedule = schedule;
            return this;
        }

        public TrainSimulation StartSimulation()
        {
            
            // Checks to see if everything is in order for the simulation i.e a train & schedule exists
            ValidateSimulation();

            DateTime currentTime = schedule.startTime;
            Console.WriteLine($"Train {train.name} (max speed {train.maxSpeedKmh}km/h) starting its route from " +
                $"{schedule.StartLocation} - {schedule.EndLocation} at {schedule.startTime}");

            List<Location> passedDestinations = new List<Location>();
            int trainPositionIndex = 0;
            foreach (Location dest in schedule.destinations)
            {
                Console.WriteLine($"Departuring from {schedule.StartLocation} at {currentTime}");

                int passedDestinationsLength = passedDestinations.Count;
                while (passedDestinations.Count == passedDestinationsLength)
                {
                    Console.WriteLine("..---.....---..");

                    Thread.Sleep((int)(60000 / realtimeMultiplier));
                    trainPositionIndex++;

                    foreach (Station s in track.IntermediateStations)
                    {
                        Console.WriteLine($"S distance: {s.Distance}");
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
                    currentTime = currentTime.AddMilliseconds(500);
                    Thread.Sleep((int)(500 / realtimeMultiplier));
                }
            }

            Console.WriteLine($"\nFinal destination {schedule.endLocation.destinationName} has been reached. @{currentTime.TimeOfDay}");
            return this;
        }

        private void ValidateSimulation()
        {
            if (train == null)
            {
                throw new Exception("You need a train in order to start the simulation");
            }

            if (schedule == null)
            {
                throw new Exception("You need a schedule in order to start the simulation");
            }
            if (track == null)
            {
                throw new Exception("You need a track in order to start the simulation");
            }
        }
    }
}
