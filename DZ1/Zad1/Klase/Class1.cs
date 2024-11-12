using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Episode
    {
        private int no_viewers;
        private double total_sum;
        private double max_score;

        public int No_viewers { get => no_viewers; set => no_viewers = value; }
        public double Total_sum { get => total_sum; set => total_sum = value; }
        public double Max_score { get => max_score; set => max_score = value; }

        public Episode() { }

        public Episode(int no_viewers, double total_sum, double max_score)
        {
            this.no_viewers = no_viewers;
            this.total_sum = total_sum;
            this.max_score = max_score;
        }

        public void AddView(double random_no)
        {
            No_viewers++;
            Total_sum += random_no;
            if (random_no > Max_score) Max_score = random_no;
        }
    }

}
