using System;

namespace TrainEngine
{
    interface ITrainPlanner
    {
        void SetStartTime(DateTime time); // Decides at what time the train leaves
        void SetStopTime(DateTime time); // Decides at what time the train arrives at the final destination
        void FollowSchedule(TrainSchedule schedule); // Follows the time schedule/path
    }
}
