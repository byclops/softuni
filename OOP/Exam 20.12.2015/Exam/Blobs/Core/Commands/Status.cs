using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Core.Commands
{
    using Blobs.Interfaces;
    using Blobs.AbstractClasses;
    using Blobs.Events;

    public class Status:AbstractCommand
    {
        public override event OutputMessageEventHandler OutputMessage;

        public Status(AbstractEngine engine)
            : base(engine)
        {

        }
        public override void Run(string[] parameters)
        {
            if (this.OutputMessage != null)
            {
                this.OutputMessage(this, new OutputMessageEventArgs(
                    OutputEventsConstants.MessageIdStatus,
                    this.engine.Db.ToString()));
            }
            //this.engine.Io.Write(this.engine.Db.ToString());
        }
        public override string Id
        {
            get
            {
                return "status";
            }
        }
    }
}
