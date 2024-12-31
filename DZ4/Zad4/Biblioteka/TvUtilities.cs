using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TVSeriesLibrary
{
    public static class TvUtilities
    {
        private static Random random = new Random();

        public static double GenerateRandomScore()
        {
            return random.NextDouble() * 10;
        }
        public static Episode Parse(string input)
        {
            var parts = input.Split(',');
            int viewerCount = int.Parse(parts[0]);
            double totalScore = double.Parse(parts[1]);
            double maxScore = double.Parse(parts[2]);
            int episodeNumber = int.Parse(parts[3]);
            TimeSpan duration = TimeSpan.Parse(parts[4]);
            string title = parts[5];
            var description = new Description(episodeNumber, duration, title);
            return new Episode(viewerCount, totalScore, maxScore, description);
        }
        public static void Sort(Episode[] episodes)
        {
            Array.Sort(episodes);
        }
        public static List<Episode> LoadEpisodesFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            List<Episode> episodes = new List<Episode>();

            for (int i = 0; i < lines.Length; i++)
            {
                episodes.Add(ParseEpisode(lines[i]));
            }

            return episodes;
        }
        private static Episode ParseEpisode(string line)
        {
            string[] parts = line.Split(',');
            int viewers = int.Parse(parts[0]);
            double totalScore = double.Parse(parts[1]);
            double maxScore = double.Parse(parts[2]);
            int episodeNumber = int.Parse(parts[3]);
            TimeSpan duration = TimeSpan.FromMinutes(int.Parse(parts[4]));
            string title = parts[5];

            Description description = new Description(episodeNumber, duration, title);
            return new Episode(viewers, totalScore, maxScore, description);
        }

    }
}
