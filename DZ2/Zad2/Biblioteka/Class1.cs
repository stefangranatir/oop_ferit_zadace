using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriasLibrary
{

    public class Episode:IComparable<Episode>
    {
        private int viewers { get; set; }
        private double SumScore { get; set; }
        private double maxScore { get; set; }
        private Description EpisodeDescription { get; set; }
        public Episode(int viewers, double SumScore, double maxScore, Description episodeDescription)
        {
            this.viewers = viewers;
            this.SumScore = SumScore;
            this.maxScore = maxScore;
            EpisodeDescription = episodeDescription;
        }
        public Episode()
        {
            this.viewers = 0;
            this.SumScore = 0;
            this.maxScore = 0;
        }
        public void AddView(double view)
        {
            this.viewers++;
            this.SumScore += view;
            if (this.maxScore < view)
            {
                this.maxScore = view;
            }
        }
        public double GetMaxScore()
        {
            return this.maxScore;
        }
        public double GetAverageScore()
        {
            return this.SumScore / this.viewers;
        }
        public int GetViewerCount()
        {
            return this.viewers;
        }
        public override string ToString()
        {
            return $"{this.viewers},{this.SumScore},{this.maxScore},{this.EpisodeDescription.ToString()}";
        }
        public int CompareTo(Episode other)=>other.GetAverageScore().CompareTo(this.GetAverageScore());
    }
    public class Description
    {
        private int EpisodeNumber { get; set; }
        private TimeSpan EpisodeRunTime { get; set; }
        private string EpisodeName { get; set; }

        public Description(int EpisodeNumber, TimeSpan EpisodeRunTime, string EpisodeName)
        {
            this.EpisodeName = EpisodeName;
            this.EpisodeRunTime = EpisodeRunTime;
            this.EpisodeNumber = EpisodeNumber;
        }
        public override string ToString()
        {
            return $"{this.EpisodeNumber},{this.EpisodeRunTime},{this.EpisodeName}";
        }
    }
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
    }
}
