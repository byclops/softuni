namespace Blobs.AbstractClasses
{
    using Interfaces;
    using Events;

    public abstract class AbstractEngine
    {
        public bool reportBehaviorToggle = false;
        public bool reportKilledBlob = false;

        protected AbstractEngine(IBlobDb db, IBlobUi io)
        {
            this.Db = db;
            this.Io = io;
            this.VerbosityLevel = OutputEventsConstants.MessageIdStatus;
        }

        public int VerbosityLevel {get; set;}
        public IBlobDb Db { get;}
        public IBlobUi Io { get;}

        public abstract void Run();
        public void OnIncomingOutputMessage(object sender, OutputMessageEventArgs eventArgs)
        {
            if ((eventArgs.Verbocity & this.VerbosityLevel) !=0)
                this.Io.Write(eventArgs.Message);
        }
    }
}
