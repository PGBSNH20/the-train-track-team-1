using System;
using System.Collections.Generic;
using System.Globalization;

namespace TrainEngine
{
    public class Location
    {
        public DateTime departureTime;
        public String destinationName;

        public Location(String departureTime, String destinationName)
        {
            this.departureTime = DateTime.ParseExact(departureTime, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture);
            this.destinationName = destinationName;
        }
    }
}
