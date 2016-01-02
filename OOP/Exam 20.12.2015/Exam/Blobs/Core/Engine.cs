namespace Blobs.Core
{
    using AbstractClasses;
    using Interfaces;

    public class Engine: AbstractEngine
    {
        public Engine(IBlobDb db, IBlobUi io)
            : base(db, io)
        {

        }

        public override void Run()
        {
            var commands = new GetCurrentCommands(this);
            while (true)
            {
                string line = Io.ReadLine();
                if (line == "drop") break;
                string[] parameters = line.Split(' ');
                commands[parameters[0]].Run(parameters);
                Db.NextTurn();
            }
        }
    }
}
