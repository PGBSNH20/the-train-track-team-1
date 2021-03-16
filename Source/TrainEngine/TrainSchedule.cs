using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TrainEngine.Models;
namespace TrainEngine
{

    public class TrainSchedule
    {
        public static List<Location> ParseRoute(string safeFileName, bool testing = false)
        {
            List<Location> locations = new List<Location>();
            StreamReader reader;
            if (testing)
            {
                var a = Directory.GetParent(Environment.CurrentDirectory);
                var b = Directory.GetParent(a.ToString());
                var c = Directory.GetParent(b.ToString());
                var d = Directory.GetParent(c.ToString());
                reader = new StreamReader(d + "/TrainConsole/bin/Debug/net5.0/TrainRoutes/" + safeFileName + "/route.txt");
            }
            else
            {
                reader = new StreamReader(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName + "/route.txt");
            }

            string input;
            try
            {
                while ((input = reader.ReadLine()) != null && (!String.IsNullOrWhiteSpace(input)))
                {
                    string[] data = input.Split('|');
                    
                    locations.Add(new Location(data[0], data[1]));
                }
            }
            catch (Exception)
            {

                throw new Exception("Something was wrong with the devider charecter");
            }
            

            if (locations.Count <= 0)
            {
                throw new Exception("Parsing failed; Locations count is 0. Are route.txt empty?");
            }

            return locations;
        }

        public static void SaveRoute(List<Location> destinations, string safeFileName)
        {
            if (File.Exists(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName + "/route.txt"))
            {
                return;
            }
            List<string> lines = new List<string>();

            foreach (Location destination in destinations)
            {
                lines.Add($"{destination.departureTime.ToString("g").Replace("-", "/")}|{destination.destinationName}");
            }

            if (!Directory.Exists(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName);
            }
            else
            {
                throw new Exception("Could not save route. Route name already exists in root directory.");
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
