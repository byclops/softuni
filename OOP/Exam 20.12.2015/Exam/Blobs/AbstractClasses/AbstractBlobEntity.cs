namespace Blobs.AbstractClasses
{
    using Interfaces;
    using Events;


    public abstract class AbstractBlobEntity: IOutputEnabled
    {
        public event OutputMessageEventHandler OutputMessage;
        public abstract int Health { get; set; }
        public virtual bool IsAlive { get; set; }
        public string Name { get; protected set; }
        public int BaseDamage { get; protected set; }
        public int AttackModifiedDamage { get; set; }
        public int BehavoirModifiedDamage { get; set; }
        protected AbstractBehavior Behavior { get; set; }
        public abstract void DealDamage(AbstractBlobEntity victum);
        protected AbstractAttack Attack { get; set; }

        public virtual void OnBehaviorActivation()
        {
            this.OutputMessage?.Invoke(this,
                new OutputMessageEventArgs(
                    OutputEventsConstants.MessageIdBehaviorActivated,
                    $"Blob {this.Name} toggled {this.Behavior}\n"));
        }

        public virtual void OnBlobDeath()
        {
            this.OutputMessage?.Invoke(this, new OutputMessageEventArgs(
                OutputEventsConstants.MessageIdKilled,
                $"Blob {this.Name} was killed\n"));
        }
    }
}
