using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriasLibrary
{
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
        public TimeSpan GetEpisodeRunTime()
        {
            return this.EpisodeRunTime;
        }
    }
}
