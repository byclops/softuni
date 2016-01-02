namespace Blobs.Attack
{
    using AbstractClasses;

    public class Blobplode : AbstractAttack
    {
        public override void ApplyEffects(AbstractBlobEntity blob)
        {
            blob.AttackModifiedDamage = blob.BaseDamage *2;
            blob.Health -= blob.Health/2;
        }
    }
}
