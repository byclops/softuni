namespace Blobs.AbstractClasses
{
    using Events;

    public abstract class AbstractCommand
    {
    
        public virtual event OutputMessageEventHandler OutputMessage;
        public AbstractEngine engine;
        //private readonly string id;

        protected AbstractCommand(AbstractEngine engine)
        {
            this.engine = engine;
        }

        public abstract string Id { get; }
        public abstract void Run(string[] parameters);
    }
}
