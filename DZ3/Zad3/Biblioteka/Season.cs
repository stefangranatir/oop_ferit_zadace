using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriasLibrary
{
    public class Season
    {
        private Episode[] episodes;
        private int SeasonNumber {  get; }
        public int Length => episodes.Length;
        public Season(int SeasonNumber, Episode[] episodes)
        {
            this.SeasonNumber = SeasonNumber;
            this.episodes = episodes;
        }
        public Episode this[int EpisodeIndex]
        {
            get
            {
                if(EpisodeIndex < 0 || EpisodeIndex >= episodes.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return episodes[EpisodeIndex]; }
            set
            {
                if (EpisodeIndex < 0 || EpisodeIndex >= episodes.Length)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                episodes[EpisodeIndex] = value;
            }
        }
        public int GetTotalViewers()
        {
            int TotalViewers = 0;
            foreach (Episode episode in episodes)
            {
                TotalViewers += episode.GetViewerCount();
            }
            return TotalViewers;
        }
        public DateTime GetBingeEnd()
        {
            TimeSpan WholeSeason= TimeSpan.Zero;
            DateTime now = DateTime.Now;
            foreach (Episode episode in episodes)
            {
                WholeSeason += episode.EpisodeDescription.GetEpisodeRunTime();
            }
            return now.Add(WholeSeason);
        }
        public TimeSpan GetBingeDuration()
        {
            TimeSpan WholeSeason = TimeSpan.Zero;
            foreach (Episode episode in episodes)
            {
                WholeSeason += episode.EpisodeDescription.GetEpisodeRunTime();
            }
            return WholeSeason;
        }
        public override string ToString()
        {
            string result = $"Season {this.SeasonNumber}:\n" +
                            "=================================================\n";
            foreach (Episode episode in episodes)
            {
                result += episode.ToString() + Environment.NewLine; ;
            }
            result += "=================================================\n" +
                      $"Total viewers: {GetTotalViewers()}\n" +
                      $"Total duration: {GetBingeDuration()}\n" +
                      "=================================================\n";
            return result;
        }
    }
}
