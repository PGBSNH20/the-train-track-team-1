using System;

namespace TrainEngine
{
    public class TrainPlanner
    {
        public void FollowSchedule(TrainSchedule schedule)
        {
            if (schedule == null)
            {
                throw new Exception("Schedule is null");
            }
            else if (String.IsNullOrEmpty(schedule.StartLocation) || String.IsNullOrWhiteSpace(schedule.StartLocation))
            {
                throw new Exception("Start location is null/empty");
            }
            else if (String.IsNullOrEmpty(schedule.EndLocation) || String.IsNullOrWhiteSpace(schedule.EndLocation))
            {
                throw new Exception("End location is null/empty");
            }


        }
    }
}
