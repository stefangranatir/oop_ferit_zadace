using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSeriesLibrary;
using System.IO;

namespace TVSeriesLibrary
{
    public class FilePrinter:IPrinter
    {
        private string FileName;
        public FilePrinter(string FileName)
        {
            this.FileName = FileName;
        }
        public void Print(string output)
        {
            File.WriteAllText(this.FileName, output);
        }
    }
}
