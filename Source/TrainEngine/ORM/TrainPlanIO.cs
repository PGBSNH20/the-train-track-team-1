﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TrainEngine
{
    public class TrainPlanIO
    {
        public static void Save(Location Destinations, string NameOfFile)
        {
            string DocPath = Environment.CurrentDirectory;
            if (File.Exists($"{DocPath}\\{NameOfFile}.txt"))
            {
                Console.WriteLine("File already exists try Loading it insead");
            }
            else
            {
                string[] lines =
                {
                   $"{Destinations.departureTime}, {Destinations.destinationName}",
                };

                foreach (Location Destination in Destinations)
                {

                }

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(DocPath, $"{NameOfFile}.txt"))) 
                {
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }
            }
        }

        public static void Load(string NameOfFile)
        {
            string DocPath = Environment.CurrentDirectory;
            if (File.Exists($"{DocPath}\\{NameOfFile}.txt"))
            {
                Console.WriteLine("ja hej hej");
            }
            else
            {
                Console.WriteLine("File dosn't exists");
            }
        }
    }
}
