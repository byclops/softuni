namespace Blobs.Attack
{
    using Blobs.Interfaces;
    using Blobs.Model;
    using Blobs.AbstractClasses;

    public class PutridFart: AbstractAttack, IAttack
    {
        public override void ApplyEffects(AbstractBlobEntity blob)
        {
            blob.AttackModifiedDamage = blob.BaseDamage;
        }
    }
}
