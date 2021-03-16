using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TrainEngine.Models;
using TrainEngine.Interfaces;
namespace TrainEngine
{
    public class TrackIO : ITrackIO
    {
        public Track Track { get; set; }
        private string SafeFileName;
        public TrackIO(string safeFileName)
        {
            Track = new Track();
            SafeFileName = safeFileName;
            Track.StationsID = new List<Station>();
        }
        public void Parse(bool testing = false)
        {
            StreamReader parser;
            if (testing)
            {
                var a = Directory.GetParent(Environment.CurrentDirectory);
                var b = Directory.GetParent(a.ToString());
                var c = Directory.GetParent(b.ToString());
                var d = Directory.GetParent(c.ToString());
                parser = new StreamReader(d + "/TrainConsole/bin/Debug/net5.0/TrainRoutes/" + SafeFileName + "/track.txt");
            }
            else
            {
                parser = new StreamReader(Environment.CurrentDirectory + "/TrainRoutes/" + SafeFileName + "/track.txt");
            }


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
        private static long ReturnLeveLCrossingDistance(string track)
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
        private static long ReturnTotalDistance(string input)
        {
            long distance = 0;

            foreach (var c in input)
            {
                if (c == '-')
                {
                    distance++; //Add a KM
                }
            }
            return distance;
        }
    }
}