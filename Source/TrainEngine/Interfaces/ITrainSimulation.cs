using System.Collections.Generic;
using TrainEngine.Models;

namespace TrainEngine.Interfaces
{
    public interface ITrainSimulation
    {
         ITrainSimulation AddTrain(Train train);
         ITrainSimulation AddDestinations(List<Location> locations);
         void Start();
    }
}