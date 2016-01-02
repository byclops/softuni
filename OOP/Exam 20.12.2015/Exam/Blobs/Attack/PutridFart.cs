namespace Blobs.Attack
{
    using AbstractClasses;

    public class PutridFart: AbstractAttack
    {
        public override void ApplyEffects(AbstractBlobEntity blob)
        {
            blob.AttackModifiedDamage = blob.BaseDamage;
        }
    }
}
