using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Behavior
{
    using Blobs.Interfaces;
    using Blobs.AbstractClasses;

    public class Inflated: AbstractBehavior
    {

        protected override void CalculateAttackEffects(AbstractBlobEntity blob)
        {
            blob.BehavoirModifiedDamage = blob.AttackModifiedDamage;
            blob.AttackModifiedDamage = blob.BaseDamage;
        }
        protected override void CalculateTurnEffects(AbstractBlobEntity blob)
        {
            blob.Health -=10;
            
        }


        protected override void InitializeParameters(AbstractBlobEntity blob)
        {
            blob.Health +=50;
        }
        public override string ToString()
        {
            return "InflatedBehavior";
        }
    }
}
