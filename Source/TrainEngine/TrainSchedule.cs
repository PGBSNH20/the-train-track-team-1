using System;
using System.Collections.Generic;
using System.Globalization;

namespace TrainEngine
{
    public class Location
    {
        public DateTime arrivalTime, departureTime;
        public String destinationName;

        public Location(String arrivalTime, String departureTime, String destinationName)
        {
            this.arrivalTime = DateTime.ParseExact(arrivalTime, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
            this.departureTime = DateTime.ParseExact(departureTime, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
            this.destinationName = destinationName;
        }
    }

    public class TrainSchedule
    {
        public Location startLocation { get; set; }
        public Location endLocation { get; set; }
        public readonly List<Location> destinations;

        public TrainSchedule(Location startLocation, Location endLocation, List<Location> destinations)
        {
            this.startLocation = startLocation;
            this.endLocation = endLocation;
            this.destinations = destinations;
        }
    }
}
