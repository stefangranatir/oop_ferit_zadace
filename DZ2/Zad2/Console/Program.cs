using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSeriasLibrary;

namespace ConsoleUI
{
    internal class Program
    {
        public static readonly Random rnd = new Random();
        public static double GenerateRandomScore()
        {
            double a = rnd.NextDouble();
            return a * 10;
        }
        public static void Main(string[] args)
        {
            Description description = new Description(1, TimeSpan.FromMinutes(45), "Pilot");
            Console.WriteLine(description);
            Episode episode = new Episode(10, 88.64, 9.78, description);
            Console.WriteLine(episode);

            // Assume that the number of rows in the text file is always at least 10. 
            // Assume a valid input file.
            string fileName = "shows.txt";
            string[] episodesInputs = File.ReadAllLines(fileName);
            Episode[] episodes = new Episode[episodesInputs.Length];
            for (int i = 0; i < episodes.Length; i++)
            {
                episodes[i] = TvUtilities.Parse(episodesInputs[i]);
            }

            Console.WriteLine("Episodes:");
            Console.WriteLine(string.Join<Episode>(Environment.NewLine, episodes));
            TvUtilities.Sort(episodes);
            Console.WriteLine("Sorted episodes:");
            string sortedEpisodesOutput = string.Join<Episode>(Environment.NewLine, episodes);
            Console.WriteLine(sortedEpisodesOutput);
            File.WriteAllText("sorted.tv", sortedEpisodesOutput);

        }
    }
}
