using System;
using System.Collections.Generic;
using TrainEngine;

namespace TrainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainSchedule schedule = new TrainSchedule("Göteborg", "Stockholm", 
                new DateTime(2021, 03, 08, 15, 30, 00), new DateTime(2021, 03, 08, 18, 30, 00), new List<Destination>()
                {
                    new Destination(new DateTime(2021, 03, 08, 15, 35, 00), new DateTime(2021, 03, 08, 15, 36, 00), "Alingsås"),
                    new Destination(new DateTime(2021, 03, 08, 15, 42, 00), new DateTime(2021, 03, 08, 15, 44, 00), "Vårgårda"),
                    new Destination(new DateTime(2021, 03, 08, 15, 50, 00), new DateTime(2021, 03, 08, 15, 59, 00), "Herrljunga"),
                    new Destination(new DateTime(2021, 03, 08, 16, 04, 00), new DateTime(2021, 03, 08, 16, 05, 00), "Falköping"),
                });;

            Train train = new Train(0, "X-2000", 250, true);

            TrainSimulation simulation = new TrainSimulation(100).AddSchedule(schedule).AddTrain(train).StartSimulation();
        }
    }
}
