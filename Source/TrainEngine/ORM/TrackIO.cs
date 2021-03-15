using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrainEngine
{
    public class TrackIO : ITrackIO
    {
        public _Track Track { get; set; }
        private string Input = Environment.CurrentDirectory + @"/track.txt";
        public TrackIO()
        {
            Track = new _Track();
            Track.IntermediateStations = new List<Station>();
        }
        public void Parse()
        {
            var parser = new StreamReader(Input);
            string input;
            while ((input = parser.ReadLine()) != null && (!String.IsNullOrWhiteSpace(input)))
            {
                var formattedStations = Regex.Replace(input, "[^A-Z]", string.Empty);
                foreach (var c in formattedStations)
                {
                    if (c != 'A' && c != formattedStations.Last())
                    {
                        Track.IntermediateStations.Add(new Station() {Name = c.ToString(), Distance = 5});
                    }
                    else if (c == 'A')
                    {
                        Track.StartLocation = c.ToString();
                    }
                    else
                    {
                        Track.EndLocation = c.ToString();
                    }
                }
                Track.TotalDistance = ReturnDistance(input);
            }
            parser.Close();
        }
        private static long ReturnDistance(string input)
        {
            long x = 0;
            try
            {
                foreach (var c in input)
                {
                    if (c == '-')
                    {
                        x++;
                    }
                    else if (c == '=')
                    {
                        //Do stuff!
                    }
                }

                return x;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public class _Track
        {
            public string StartLocation { get; set; }
            public string EndLocation { get; set; }
            public List<Station> IntermediateStations { get; set; }
            public long TotalDistance { get; set; }
        }
    }
}