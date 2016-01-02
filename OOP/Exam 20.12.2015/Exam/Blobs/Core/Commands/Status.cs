namespace Blobs.Core.Commands
{
    using AbstractClasses;
    using Events;

    public class Status:AbstractCommand
    {
        public override event OutputMessageEventHandler OutputMessage;

        public Status(AbstractEngine engine)
            : base(engine)
        {

        }

        public override void Run(string[] parameters)
        {
            this.OutputMessage?.Invoke(this, new OutputMessageEventArgs(
                OutputEventsConstants.MessageIdStatus,
                this.engine.Db.ToString()));
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
