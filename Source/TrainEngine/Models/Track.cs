using System.Collections.Generic;

namespace TrainEngine.Models
{
    public class Track : LevelCrossing
    {
        public LevelCrossing LevelCrossing { get; }
        public List<Station> StationsID { get; set; }
        public long TotalDistance { get; set; }

        public Track()
        {
            this.LevelCrossing = new LevelCrossing();
        }
    }
}