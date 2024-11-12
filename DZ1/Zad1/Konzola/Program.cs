using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klase;

namespace Konzola
{
    internal class Program
    {
        public static Random random = new Random();
        public static double GenerateRandomScore()
        {
            double score = random.NextDouble() * 10;
            return score;
        }

        static void Main(string[] args)
        {
            Episode ep1, ep2;
            ep1 = new Episode();
            ep2 = new Episode(10, 64.39, 8.7);
            int viewers = 10;
            for (int i = 0; i < viewers; i++)
            {
                ep1.AddView(GenerateRandomScore());
                Console.WriteLine(ep1.Max_score);
            }
            if (ep1.Total_sum > ep2.Total_sum)
            {
                Console.WriteLine($"Viewers: {ep1.No_viewers}");
            }
            else
            {
                Console.WriteLine($"Viewers: {ep2.No_viewers}");
            }
        }
    }
}
