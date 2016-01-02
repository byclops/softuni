namespace Blobs.Model
{
    using System;
    using AbstractClasses;

    public class Blob : AbstractBlobEntity
    {
        private int health;

        private readonly int baseHealth;
  
        public Blob(string name, int health, int damage, AbstractBehavior behavior, AbstractAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.baseHealth = health;
            this.BaseDamage = damage;
            this.AttackModifiedDamage = damage;
            this.BehavoirModifiedDamage = damage;
            this.Behavior = behavior;
            this.Attack = attack;
        }

        public sealed override int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                if (this.health<0)
                {
                    this.health = 0;
                    if (this.Behavior.IsActive) this.OnBlobDeath();
                }

                if (this.health > this.baseHealth/2) return;

                try 
                {
                    this.Behavior.Activate(this);
                    this.OnBehaviorActivation();
                    if (this.Health == 0) this.OnBlobDeath();
                }

                catch (Exception e)
                {

                }
            }
        }

        public override bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }

        public override void DealDamage(AbstractBlobEntity victum)
        {
            if (!this.IsAlive || !victum.IsAlive) return;
            this.Attack.ApplyEffects(this);
            this.Behavior.ApplyEffects(this);
            victum.Health -=this.BehavoirModifiedDamage;
        }

        public override string ToString()
        {
            string result;

            if (this.IsAlive)
            {
                result = $"Blob {this.Name}: {this.Health} HP, {this.AttackModifiedDamage} Damage";
            }

            else
            {
                result = $"Blob {this.Name} KILLED";
            }
                
            return result;
        }

        public void NextTurn()
        {
            this.Behavior.ApplyTurnEffects(this);
        }
    }
}
