using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs

{
    using Blobs.Interfaces;
    using Blobs.Core;
    using Blobs.Core.Commands;
    using Blobs.Model;

    class BlobsDemo
    {


        static void Main(string[] args)
        {

            var oj = new ObjectGenerator();
            var tmp = oj.Create("ConsoleUI", "Blobs.Core");
            var db = new BaseDB();
            var io = new ConsoleUI();
            var engine = new Engine(db, io);
            engine.Run();


            //var commands = new GetCurrentCommands(db);

            //var tmp = Type.GetType("Blobs.Attack
            //foreach (var command in commands.Keys)
            //{
            //    Console.WriteLine(commands[command].Id);
            //}


            //Console.WriteLine(commands["create"].Run("create Cenko 30 15 Inflated PutridFart".Split(' ')));
            //Console.WriteLine(db.ToString());

            

        }
    }
}
