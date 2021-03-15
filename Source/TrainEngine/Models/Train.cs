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
    }
}