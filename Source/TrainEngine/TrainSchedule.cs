using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

    public class TrainSchedule
    {
        public static List<Location> ParseRoute(string safeFileName)
        {
            List<Location> locations = new List<Location>();
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName + "/route.txt");
            string input;
            while ((input = reader.ReadLine()) != null && (!String.IsNullOrWhiteSpace(input)))
            {
                string[] data = input.Split('|');
                locations.Add(new Location(data[0], data[1]));
            }

            if (locations.Count > 0)
            {
                return locations;
            }
            else
            {
                throw new Exception("Parsing failed; Locations count is 0. Are route.txt empty?");
            }
        }
    }
}
