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

    public class ReportEvents: AbstractCommand
    {
        public ReportEvents(AbstractEngine engine)
            : base(engine)
        {
            engine.reportBehaviorToggle = true;
            engine.reportKilledBlob = true;
        }

        public override void Run(string[] parameters)
        {
            this.engine.VerbosityLevel += OutputEventsConstants.MessageIdKilled;
            this.engine.VerbosityLevel += OutputEventsConstants.MessageIdBehaviorActivated;

        }
        public override string Id
        {   
            get
            {
                return "report-events";
            }
        }
    }
}
