using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.AbstractClasses
{
    using Blobs.Interfaces;
    using Blobs.Core;
    using Blobs.Events;

    public abstract class AbstractCommand
    {
    
        private readonly string id;
        public virtual event OutputMessageEventHandler OutputMessage;
        public AbstractEngine engine;
        public AbstractCommand(AbstractEngine engine)
        {
            this.engine = engine;
        }
        public abstract string Id { get; }
        public abstract void Run(string[] parameters);
    }
}
