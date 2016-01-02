namespace Blobs.Core.Commands
{
    using AbstractClasses;
    using Events;

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
