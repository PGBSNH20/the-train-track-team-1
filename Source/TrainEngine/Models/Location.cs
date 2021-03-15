using System;
using System.Globalization;

namespace TrainEngine.Models
{
    public class Location
    {
        public DateTime departureTime;
        public String destinationName;

        public Location(String departureTime, String destinationName)
        {
            Console.WriteLine(departureTime);
            this.departureTime = DateTime.Parse(departureTime);
            this.destinationName = destinationName;
        }

        
    }
}