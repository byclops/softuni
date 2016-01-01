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

    public class Attack: AbstractCommand
    {
        public Attack(AbstractEngine engine):base(engine)
        {

        }
        public override void Run(string[] parameters)
        {
            Blob attacker = this.engine.Db.GetBlob(parameters[1]);
            Blob defender = this.engine.Db.GetBlob(parameters[2]);
            attacker.DealDamage(defender);
        }

        public override string Id
        {
            get
            {
                return "attack";
            }
        }
    }
}
