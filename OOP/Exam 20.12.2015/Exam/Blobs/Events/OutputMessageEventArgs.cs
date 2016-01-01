using System;

namespace Blobs.Events
{
    public class OutputMessageEventArgs: EventArgs
    {
        public OutputMessageEventArgs(int verbocity, string message)
        {
            this.Verbocity = verbocity;
            this.Message = message;
        }
        public string Message { get; private set; }
        public int Verbocity { get; private set; }
    }
}
