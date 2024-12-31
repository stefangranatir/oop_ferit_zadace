using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSeriesLibrary;

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
            string fileName = "shows.tv";

            IPrinter printer = new ConsolePrinter();
            printer.Print($"Reading data from file {fileName}");

            List<Episode> episodes = TvUtilities.LoadEpisodesFromFile(fileName);
            Season season = new Season(1, episodes);

            printer.Print(season.ToString());
            foreach (var episode in season)
            {
                episode.AddView(TvUtilities.GenerateRandomScore());
            }
            printer.Print(season.ToString());

            Season copy = new Season(season);
            copy[0].AddView(1.0);
            if (copy[0].GetAverageScore() == season[0].GetAverageScore())
            {
                printer.Print("This is not the correct copy implementation!");
            }

            try
            {
                season.Remove("Pilot");
                season.Remove("Nope");
            }
            catch (EpisodeNameException e)
            {
                printer.Print($"{e.Message}, Name: {e.Title}");
            }
            printer.Print(season.ToString());

        }
    }
}
