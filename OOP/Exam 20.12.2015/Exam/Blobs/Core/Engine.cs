using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Core
{
    using Blobs.AbstractClasses;
    using Blobs.Interfaces;
    using Blobs.Core.Commands;

    public class Engine: AbstractEngine
    {
        public Engine(IBlobDB db, IBlobUI io)
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
                //Io.Write(output);
                Db.NextTurn();

            }

        }
    }
}
