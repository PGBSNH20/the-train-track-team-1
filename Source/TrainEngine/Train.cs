using System.IO;
using System;
using System.Collections.Generic;
using TrainEngine.Models;
namespace TrainEngine
{
    public class TrainSomethingYouCanChooseABetterName
    {

        public Train[] Parse(string safeFileName)
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
