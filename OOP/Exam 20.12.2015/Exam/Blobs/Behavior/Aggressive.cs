using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Behavior
{
    using Blobs.Model;
    using Blobs.Interfaces;
    using Blobs.AbstractClasses;

    public class Aggressive: AbstractBehavior
    {
        private int behaviorDamageBonus;
        private int baseDamage;
        protected override void CalculateAttackEffects(AbstractBlobEntity blob)
        {
           // blob.BehavoirModifiedDamage = blob.AttackModifiedDamage + this.behaviorDamageBonus;
            blob.BehavoirModifiedDamage = blob.AttackModifiedDamage + this.behaviorDamageBonus;
            //blob.AttackModifiedDamage = blob.BehavoirModifiedDamage;
        }

        protected override void CalculateTurnEffects(AbstractBlobEntity blob)
        {
            blob.AttackModifiedDamage -= 5;
            if (blob.AttackModifiedDamage < blob.BaseDamage)
            {
                blob.AttackModifiedDamage = blob.BaseDamage;
            }
            //this.behaviorDamageBonus -= 5;
            //if (this.behaviorDamageBonus < this.baseDamage)
            //{
            //    this.behaviorDamageBonus = this.baseDamage;
            //}
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
