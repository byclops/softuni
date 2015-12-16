using Empires.Core;

namespace Empires
{
    class EmpiresDemo
    {
        static void Main(string[] args)
        {

            //var io = new IO(Console.ReadLine,x=>Console.WriteLine(x));
            //var engine = new Engine(io);
            var engine = new Engine(new IO(), new BaseDB());
            engine.Run();
        }
    }
}
