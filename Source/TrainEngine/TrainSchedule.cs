using System;
using System.Collections.Generic;

namespace TrainEngine
{
    public class Destination
    {
        public DateTime arrivalTime, departureTime;
        public String destinationName;

        public Destination(DateTime arrivalTime, DateTime departureTime, String destinationName)
        {
            this.arrivalTime = arrivalTime;
            this.departureTime = departureTime;
            this.destinationName = destinationName;
        }
    }

    public class TrainSchedule
    {
        public String StartLocation { get; set; }
        public String EndLocation { get; set; }
        public readonly DateTime startTime, stopTime;
        public readonly List<Destination> destinations;

        public TrainSchedule(String startLocation, String endLocation, DateTime startTime, DateTime stopTime, List<Destination> destinations)
        {
            this.StartLocation = startLocation;
            this.EndLocation = endLocation;
            this.startTime = startTime;
            this.stopTime = stopTime;
            this.destinations = destinations;
        }

        public void Validate()
        {
	    if (this == null)
            {
                throw new Exception("Schedule is null");
            }
	    
            if (String.IsNullOrEmpty(this.StartLocation) || String.IsNullOrWhiteSpace(this.StartLocation))
            {
                throw new Exception("Start location is null/empty");
            }

            if (String.IsNullOrEmpty(this.EndLocation) || String.IsNullOrWhiteSpace(this.EndLocation))
            {
                throw new Exception("End location is null/empty");
            }
        }
    }
}
