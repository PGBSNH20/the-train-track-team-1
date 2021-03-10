using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrainEngine
{
    public class TrackIO
    {
        public Track ParseTrack()
        {
            var track = new Track();
            var parser = new StreamReader(Environment.CurrentDirectory + @"/track.txt");
            string input;
            var intermediateStations = new List<string>();
            while ((input = parser.ReadLine()) != null)
            {
                var formattedStations = Regex.Replace(input, "[^A-Z]", string.Empty);
                foreach (var c in formattedStations)
                {
                    if (c != 'A' && c != formattedStations.Last())
                    {
                        intermediateStations.Add(c.ToString());
                    }
                    else if (c == 'A')
                    {
                        track.StartLocation = c.ToString();
                    }
                    else
                    {
                        track.EndLocation = c.ToString();
                    }
                }
                track.TotalDistance = ReturnDistance(input);
            }
            parser.Close();
            track.intermediateStations = intermediateStations;
            return track;
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
    }
}