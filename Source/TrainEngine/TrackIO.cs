using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TrainEngine
{
    public class TrackIO
    {
        public Track ParseTrack()
        {
            Track track = new Track();
            
            StreamReader parser = new StreamReader(Environment.CurrentDirectory + @"\track.txt");
            string input;
            while ((input = parser.ReadLine()) != null)
            {
                //Ugly station-parsing!
                string x = input;
                string y = x;
                x = x.Replace("-", "");
                y = y.Replace("-", "");
                y = y.Remove(0, 3);
                x = x.Remove(3, 3);
                
                //[A]----------------------[B]
                track.StartLocation = x;
                track.EndLocation = y;
                track.TotalDistance = returnDistance(input);
            }
            parser.Close();
            return track;
        }
        private long returnDistance(string input)
        {
            
            long x = 0;
            try
            {
                foreach (char c in input)
                {
                    if (c == '-')
                    {
                        x++;
                    }
                }
                return x;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
         
            
        }
    }
}