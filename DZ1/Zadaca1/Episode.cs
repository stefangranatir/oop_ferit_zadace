using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    internal class Episode
    {
        private int viewers { get; set; }
        private double SumScore { get; set; }
    private double maxScore { get; set; }
public Episode(int viewers, double SumScore, double maxScore)
        {
            this.viewers = viewers;
            this.SumScore=SumScore;
            this.maxScore = maxScore;
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
    }
}
