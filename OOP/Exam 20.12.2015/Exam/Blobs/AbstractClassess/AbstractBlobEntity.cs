using System;

namespace Blobs.Interfaces
{
    using Blobs.AbstractClasses;
    using Blobs.Events;


    public abstract class AbstractBlobEntity: IOutputEnabled
    {
        public event OutputMessageEventHandler OutputMessage;
        //public int Damage { get; protected set; }
        public abstract int Health { get; set; }
        public virtual bool IsAlive { get; set; }
        public string Name { get; protected set; }
        public int BaseDamage { get; protected set; }
        public int AttackModifiedDamage { get; set; }
        public int BehavoirModifiedDamage { get; set; }
        protected AbstractBehavior Behavior { get; set; }

        protected AbstractAttack Attack { get; set; }
        public abstract void DealDamage(AbstractBlobEntity victum);
        //void ReceiveDamage(int damage);
        public virtual void OnBehaviorActivation()
        {
            if (this.OutputMessage != null)
            {
                this.OutputMessage(this,
                new OutputMessageEventArgs(
                    OutputEventsConstants.MessageIdBehaviorActivated, 
                    String.Format(
                    "Blob {0} toggled {1}\n",
                    this.Name,
                    this.Behavior.ToString())));
            }

        }
        public virtual void OnBlobDeath()
        {
            if (this.OutputMessage != null)
            {
                this.OutputMessage(this, new OutputMessageEventArgs(
                    OutputEventsConstants.MessageIdKilled, 
                    String.Format("Blob {0} was killed\n", this.Name)));
            }

        }
    }
}
