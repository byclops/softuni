using System;

namespace Empires.Core
{
    class IO
    {
        private Func<string> readLineMethod;
        private Action<string> writeLineMethod;

        public IO()

        //Console is the default IO method!
        {
            this.readLineMethod = Console.ReadLine;
            this.writeLineMethod = new Action<string>(x=>Console.WriteLine(x));
        }

        //Custom IO method is also possible
        public IO(Func<string> readLineMethod, Action<string> writeLineMethod)
        {
            this.readLineMethod = readLineMethod;
            this.writeLineMethod = writeLineMethod;
        }
        public string ReadLine()
        {
            return this.readLineMethod();
        }
        public void WriteLine(string line)
        {
            this.writeLineMethod(line);
        }
    }
}
