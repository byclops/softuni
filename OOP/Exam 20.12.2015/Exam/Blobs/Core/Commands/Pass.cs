namespace Blobs.Core.Commands
{
    using AbstractClasses;

    public class Pass: AbstractCommand
    {
        public Pass(AbstractEngine engine)
            : base(engine)
        {

        }

        public override void Run(string[] parameters)
        {

        }

        public override string Id
        {
            get
            {
                return "pass";
            }
        }
    }
}
