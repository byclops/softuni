namespace Blobs.Core.Commands
{
    using Model;
    using AbstractClasses;

    public class Attack: AbstractCommand
    {
        public Attack(AbstractEngine engine):base(engine)
        {

        }

        public override void Run(string[] parameters)
        {
            Blob attacker = this.engine.Db.GetBlob(parameters[1]);
            Blob defender = this.engine.Db.GetBlob(parameters[2]);
            attacker.DealDamage(defender);
        }

        public override string Id
        {
            get
            {
                return "attack";
            }
        }
    }
}
