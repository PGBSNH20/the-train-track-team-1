using System;
using System.Collections.Generic;
using System.Threading;

namespace TrainEngine
{
    public class TrainSimulation
    {
        private double realtimeMultiplier; // Realtime multiplied by times value (ex 0.1 is 10x faster)
        public TrainSimulation(double realtimeMultiplier)
        {
            this.realtimeMultiplier = realtimeMultiplier;
        }

        public void StartSimulation(TrainSchedule schedule, Train train)
        {
            DateTime currentTime = schedule.startTime;
            Console.WriteLine($"Train {train.name} starting its route from {schedule.StartLocation} - {schedule.EndLocation} at {schedule.startTime}");

            List<Destination> passedDestinations = new List<Destination>();
            foreach (Destination dest in schedule.destinations)
            {
                Console.WriteLine($"Departuring from {schedule.StartLocation} at {currentTime}");

                int passedDestinationsLength = passedDestinations.Count;
                while (passedDestinations.Count == passedDestinationsLength)
                {
                    Console.WriteLine("..---.....---..");

                    Thread.Sleep((int)(60000 / realtimeMultiplier));
                    currentTime = currentTime.AddMinutes(1);

                    if (currentTime >= dest.arrivalTime)
                    {
                        passedDestinations.Add(dest);
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
        }
    }
}
