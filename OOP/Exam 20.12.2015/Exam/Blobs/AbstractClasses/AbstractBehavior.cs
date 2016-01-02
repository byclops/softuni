namespace Blobs.AbstractClasses
{
    using System;

    public abstract class AbstractBehavior 
    {
        protected int activeTurnsCount = -1;
        public bool IsActive
        {
            get { return this.activeTurnsCount > -1; }
        }

        public void ApplyEffects(AbstractBlobEntity blob)
        {
            if (this.activeTurnsCount >-1)
            {
                CalculateAttackEffects(blob);
            }

            else
            {
                blob.BehavoirModifiedDamage = blob.AttackModifiedDamage;
                blob.AttackModifiedDamage = blob.BaseDamage;
            }
        }

        public virtual void ApplyTurnEffects(AbstractBlobEntity blob)
        {
            if (this.activeTurnsCount>0)
            {
                CalculateTurnEffects(blob);
            }

            if (this.activeTurnsCount > -1)
            {
                this.activeTurnsCount++;
            }
        }

        protected abstract void CalculateAttackEffects(AbstractBlobEntity blob);
        protected abstract void CalculateTurnEffects(AbstractBlobEntity blob);
        protected virtual void InitializeParameters(AbstractBlobEntity blob)
        {

        }

        public void Activate(AbstractBlobEntity blob)
        {
            if (this.activeTurnsCount > -1)
            {
                throw new Exception("Behavior already Active");
            }

            this.activeTurnsCount = 0;
            this.InitializeParameters(blob);
        }
    }
}
