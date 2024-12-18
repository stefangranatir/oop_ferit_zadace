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
            string fileName = "shows.tv";
            string outputFileName = "storage.tv";
            Episode[] episodes = TvUtilities.LoadEpisodesFromFile(fileName);
            Season season = new Season(1, episodes);
            

            IPrinter printer = new ConsolePrinter();
            printer.Print($"Reading data from file {fileName}");

            printer.Print($"Good season? Total viewers: {season.GetTotalViewers()}");
            printer.Print($"Watch whole season? Ends at: {season.GetBingeEnd()}");

            

            printer.Print(season.ToString());
            for (int i = 0; i < season.Length; i++)
            {
                season[i].AddView(TvUtilities.GenerateRandomScore());
            }
            printer.Print(season.ToString());

            printer = new FilePrinter(outputFileName);
            printer.Print(season.ToString());

            Console.ReadKey();

        }
    }
}
