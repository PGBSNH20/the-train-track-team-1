namespace TrainEngine
{
    public class TrainPlanner
    {
        public void FollowSchedule(TrainSchedule schedule)
        {
            schedule.Validate();
        }
    }
}
