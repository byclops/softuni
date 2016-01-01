using System;

namespace Blobs.AbstractClasses
{

    using Blobs.Core;
    using Blobs.Core.Commands;
    using Blobs.Interfaces;
    using Blobs.Events;

    public abstract class AbstractEngine
    {
        public bool reportBehaviorToggle = false;
        public bool reportKilledBlob = false;
        // public event OutputMessageEventHandler MessageReceived;

        public AbstractEngine(IBlobDB db, IBlobUI io)
        {
            this.Db = db;
            this.Io = io;
            this.VerbosityLevel = OutputEventsConstants.MessageIdStatus;
            //this.MessageReceived += OnIncomingOutputMessage;
        }

        public abstract void Run();

        public int VerbosityLevel {get; set;}
        public IBlobDB Db { get; private set; }
        public IBlobUI Io { get; private set; }

        public void OnIncomingOutputMessage(object sender, OutputMessageEventArgs eventArgs)
        {
            if ((eventArgs.Verbocity & this.VerbosityLevel) !=0)
                this.Io.Write(eventArgs.Message);
        }
    }
}
