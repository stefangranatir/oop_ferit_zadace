using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesLibrary
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
