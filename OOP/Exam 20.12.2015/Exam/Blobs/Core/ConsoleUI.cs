using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Core
{
    using Blobs.Interfaces;
    public class ConsoleUI: IBlobUI
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
        public void Write(string line)
        {
            Console.Write(line);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
