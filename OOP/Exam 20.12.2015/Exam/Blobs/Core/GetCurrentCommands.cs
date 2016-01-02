
namespace Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AbstractClasses;

    public class GetCurrentCommands
    {
        private Dictionary<string, AbstractCommand> commands = new Dictionary<string, AbstractCommand>();
        public GetCurrentCommands(AbstractEngine engine)
        {

            foreach (Type type in
                Assembly.GetAssembly(typeof(AbstractCommand)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(AbstractCommand))))
            {
                AbstractCommand command = (AbstractCommand)Activator.CreateInstance(type, engine);
                this.commands[command.Id] = command;
                command.OutputMessage += engine.OnIncomingOutputMessage;
            }

        }

        public AbstractCommand this[string index]
        {
            get
            {
                return commands[index];
            }
        }

        public IEnumerable<string> Keys { get { return this.commands.Keys; } }
    }
}