using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TVSeriesLibrary
{
    public class Season : IEnumerable<Episode>
    {
        private List<Episode> episodes;
        private int SeasonNumber { get; set; }
        public int Length => episodes.Count;
        public Season()
        {
            episodes = new List<Episode>();
            SeasonNumber = 0;
        }
        public Season(int SeasonNumber, List<Episode> episodes)
        {
            this.SeasonNumber = SeasonNumber;
            this.episodes = episodes;
        }
        public Episode this[int EpisodeIndex]
        {
            get
            {
                if (EpisodeIndex < 0 || EpisodeIndex >= episodes.Count)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                return episodes[EpisodeIndex];
            }
            set
            {
                if (EpisodeIndex < 0 || EpisodeIndex >= episodes.Count)
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
            TimeSpan WholeSeason = TimeSpan.Zero;
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
        public void SetSeasonNumber(int number)
        {
            this.SeasonNumber = number;
        }
        public void SetEpisodes(List<Episode> episodes)
        {
            this.episodes = episodes;
        }
        public IEnumerator<Episode> GetEnumerator()
        {
            return episodes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void AddEpisode(Episode episode)
        {
            episodes.Add(episode);
        }
        public void Remove(string Name)
        {
            var RemoveEpisode = episodes.Where(e => e.EpisodeDescription.EpisodeName == Name).FirstOrDefault();
            if (RemoveEpisode == null)
            {
                throw new EpisodeNameException("Problem with episode name", Name);
            }
            foreach (Episode episode in episodes)
            {

                if (episode.EpisodeDescription.EpisodeName == Name)
                {
                    episodes.Remove(episode);
                    break;
                }
            }
            
        }
        public Season(Season other)
        {
            this.SeasonNumber = other.SeasonNumber;
            this.episodes = new List<Episode>(other.episodes.Select(e => new Episode(e)));

        }
    }
}
