using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesLibrary
{

    public class Episode:IComparable<Episode>
    {
        private int viewers { get; set; }
        private double SumScore { get; set; }
        private double maxScore { get; set; }
        public Description EpisodeDescription { get; private set; }
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

        public Episode(Episode e)
        {
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
            if (this.viewers != 0)
            {
                return this.SumScore / this.viewers;
            }
            return -1;
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
    
   
}
