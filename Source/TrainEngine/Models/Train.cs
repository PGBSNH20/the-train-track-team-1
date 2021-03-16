using System.IO;
using System;
using System.Collections.Generic;
namespace TrainEngine.Models
{
    public class Train
    {
        public int id;
        public string name;
        public double maxSpeedKmh;
        public bool inUse;

        public Train(int id, string name, double maxSpeedKmh, bool inUse)
        {
            this.id = id;
            this.name = name;
            this.maxSpeedKmh = maxSpeedKmh;
            this.inUse = inUse;
        }
        public static Train[] Parse(string safeFileName)
        {
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + "/" + safeFileName);
            List<Train> trains = new List<Train>();
            string input;
            while ((input = reader.ReadLine()) != null && (!String.IsNullOrWhiteSpace(input)))
            {
                string[] temp = input.Split('|');
                Train train = new Train(int.Parse(temp[0]), temp[1], double.Parse(temp[2]), bool.Parse(temp[3]));
                trains.Add(train);
            }

            if (trains.Count <= 0)
            {
                throw new Exception("The amount of trains is parsed to 0. Is trains.txt empty?");
            }

            return trains.ToArray();
        }
    }
}