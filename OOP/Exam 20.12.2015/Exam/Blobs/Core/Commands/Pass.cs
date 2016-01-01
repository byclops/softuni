using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Core.Commands
{
    using Blobs.Interfaces;
    using Blobs.AbstractClasses;


    public class Pass: AbstractCommand
    {
        public Pass(AbstractEngine engine)
            : base(engine)
        {

        }
        public override void Run(string[] parameters)
        {
        }
        public override string Id
        {
            get
            {
                return "pass";
            }
        }
    }
}
