namespace Blobs.Behavior
{
    using AbstractClasses;

    public class Aggressive: AbstractBehavior
    {
        private int behaviorDamageBonus;
        private int baseDamage;

        protected override void CalculateAttackEffects(AbstractBlobEntity blob)
        {
            blob.BehavoirModifiedDamage = blob.AttackModifiedDamage + this.behaviorDamageBonus;
        }

        protected override void CalculateTurnEffects(AbstractBlobEntity blob)
        {
            blob.AttackModifiedDamage -= 5;
            if (blob.AttackModifiedDamage < blob.BaseDamage)
            {
                blob.AttackModifiedDamage = blob.BaseDamage;
            }
        }

        protected override void InitializeParameters(AbstractBlobEntity blob)
        {
            this.behaviorDamageBonus = blob.AttackModifiedDamage;
            this.baseDamage = blob.BaseDamage;
        }

        public override string ToString()
        {
            return "AggressiveBehavior";
        }

    }
}
