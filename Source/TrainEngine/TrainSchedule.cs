using System;
using System.Collections.Generic;

namespace TrainEngine
{
    class Destination
    {
        DateTime arrivalTime, departureTime;
        String destinationName;
    }

    class TrainSchedule
    {
        List<Destination> schedule;
    }
}
