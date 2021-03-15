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

        public static void SaveRoute(List<Location> destinations, string safeFileName)
        {
            if (File.Exists(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName + "/route.txt"))
            {
                Console.WriteLine("File already exists try Loading it insead");
            }
            else
            {
                List<string> lines = new List<string>();

                foreach (Location destination in destinations)
                {
                    lines.Add($"{destination.departureTime.ToString("g").Replace("-", "/")}|{destination.destinationName}");
                }

                try
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName);

                }
                catch (Exception)
                {
                    throw;
                }

                using (StreamWriter outputFile = new StreamWriter(Environment.CurrentDirectory+ "/TrainRoutes/" + safeFileName + "/route.txt"))
                {
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }
            }

        }
    }
}
