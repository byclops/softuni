namespace Blobs
{
    using Blobs.Core;

    class BlobsDemo
    {
        static void Main(string[] args)
        {
            //var oj = new ObjectGenerator();
            //var tmp = oj.Create("ConsoleUi", "Blobs.Core");
            var db = new BaseDb();
            var io = new ConsoleUi();
            var engine = new Engine(db, io);
            engine.Run();
        }
    }
}
