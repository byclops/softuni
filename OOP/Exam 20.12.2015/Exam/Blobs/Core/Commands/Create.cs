using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Core.Commands
{
    using Blobs.Interfaces;
    using Blobs.Model;
    using Blobs.AbstractClasses;


    public class Create: AbstractCommand
    {
        public Create(AbstractEngine engine)
            : base(engine)
        {

        }

        public override void Run(string[] parameters)
        {
            string name = parameters[1];
            int health = int.Parse(parameters[2]);
            int damage = int.Parse(parameters[3]);
            var factory = new ObjectGenerator();
            var behavior = (AbstractBehavior)factory.Create(parameters[4], "Blobs.Behavior");
            var attack = (AbstractAttack)factory.Create(parameters[5], "Blobs.Attack");
            var blob = new Blob(name, health, damage, behavior, attack);
            engine.Db.AddBlob(blob);
            engine.Db.GetBlob(name).OutputMessage += engine.OnIncomingOutputMessage;
        }
        public override string Id
        {
            get
            {
                return "create";
            }
        }
    }
}
