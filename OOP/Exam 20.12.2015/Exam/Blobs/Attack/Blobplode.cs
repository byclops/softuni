namespace Blobs.Attack
{
    using Blobs.Interfaces;
    using Blobs.Model;
    using Blobs.AbstractClasses;

    public class Blobplode : AbstractAttack, IAttack
    {

        public override void ApplyEffects(AbstractBlobEntity blob)
        {
            blob.AttackModifiedDamage = blob.BaseDamage *2;
            blob.Health -= blob.Health/2;
        }
    }
}
