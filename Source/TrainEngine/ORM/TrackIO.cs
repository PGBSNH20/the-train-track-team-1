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
        private string SafeFileName;
        public TrackIO(string safeFileName)
        {
            Track = new _Track();
            SafeFileName = safeFileName;
            Track.StationsID = new List<Station>();
        }
        public void Parse()
        {
            var parser = new StreamReader(Environment.CurrentDirectory + "/TrainRoutes/" + SafeFileName + "/track.txt");
            string input;
            while ((input = parser.ReadLine()) != null && (!String.IsNullOrWhiteSpace(input)))
            {
                var formattedStations = Regex.Replace(input, "[^A-Z]", string.Empty);
                foreach (var c in formattedStations)
                {
                    Track.StationsID.Add(new Station() {ID = c.ToString(), Distance = ReturnStationDistance(input, c)});
                }
                Track.LevelCrossing.Location = ReturnLeveLCrossingDistance(input);
                Track.TotalDistance = ReturnTotalDistance(input);
            }
            parser.Close();
        }

        public static void ExportTrack(string track, string safeFileName)
        {
            try
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName);

            }
            catch (Exception)
            {
                throw;
            }

            var writer = new StreamWriter(Environment.CurrentDirectory + "/TrainRoutes/" + safeFileName + "/track.txt");

            writer.Write(track);
            writer.Flush();
            writer.Close();
        }

        private static long ReturnStationDistance(string track, char id)
        {
            try
            {
                long distance = 0;
                track = Regex.Replace(track, "[^" + id + "-]", string.Empty);
                track = track.Remove(track.IndexOf(id) + 1, track.Length - track.IndexOf(id) - 1);
                foreach (var c in track)
                {
                    if (c == '-')
                    {
                        distance++; //Add a KM
                    }
                }
                return distance;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private static long ReturnLeveLCrossingDistance(string track)
        {
            try
            {
                track = Regex.Replace(track, "[^-=]", string.Empty);
                long levelCrossingDistance = 0;
                track = track.Remove(track.IndexOf('=') + 1, track.Length - track.IndexOf('=') - 1);
                foreach (var i in track)
                {
                    if (i == '-')
                    {
                        levelCrossingDistance++; //Add a KM
                    }
                }
                return levelCrossingDistance;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private static long ReturnTotalDistance(string input)
        {
            long distance = 0;
            try
            {
                foreach (var c in input)
                {
                    if (c == '-')
                    {
                        distance++; //Add a KM
                    }
                }
                return distance;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public class _Track
        {
            public _LevelCrossing LevelCrossing { get; }
            public List<Station> StationsID { get; set; }
            public long TotalDistance { get; set; }
            public _Track()
            {
                LevelCrossing = new _Track._LevelCrossing();
            }
            public class _LevelCrossing
            {
                public long Location { get; set; } //The location which the level crossing occurs measured in KM
            }
            
        }
    }
}