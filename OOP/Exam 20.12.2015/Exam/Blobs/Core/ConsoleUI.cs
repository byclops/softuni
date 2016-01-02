namespace Blobs.Core
{
    using System;
    using Interfaces;
    public class ConsoleUi: IBlobUi
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
