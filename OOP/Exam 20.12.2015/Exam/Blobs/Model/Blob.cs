        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Model
{
    using Blobs.Interfaces;
    using Blobs.Behavior;
    using Blobs.Attack;
    using Blobs.AbstractClasses;
    using Blobs.Events;


    public class Blob : AbstractBlobEntity
    {
        //public event OutputMessageEventHandler OutputMessage;

        private int health;

        private int baseHealth;
  
        public Blob(string name, int health, int damage, AbstractBehavior behavior, AbstractAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.baseHealth = health;
            //this.Damage = damage;
            this.BaseDamage = damage;
            this.AttackModifiedDamage = damage;
            this.BehavoirModifiedDamage = damage;
            this.Behavior = behavior;
            this.Attack = attack;

        }

        public override int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                if (this.health<0)
                {
                    this.health = 0;
                    if (this.Behavior.IsActive) this.OnBlobDeath();
                    //if (this.Behavior.IsActive && this.OutputMessage != null)
                    //{
                    //    this.OutputMessage(this, 
                    //        new OutputMessageEventArgs(2,String.Format("Blob {0} was killed ", this.Name)));
                    //}
                }

                if (this.health<=this.baseHealth/2)
                {
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
            if (this.IsAlive && victum.IsAlive)
            {
                this.Attack.ApplyEffects(this);
                this.Behavior.ApplyEffects(this);
                victum.Health -=this.BehavoirModifiedDamage;
                //this.AttackModifiedDamage = this.BaseDamage;

            }

        }

        public override string ToString()
        {
            string result;

            if (this.IsAlive)
            {
                result = String.Format(
                    "Blob {0}: {1} HP, {2} Damage",
                    this.Name,
                    this.Health,
                    this.AttackModifiedDamage);
            }

            else
            {
                result = String.Format("Blob {0} KILLED", this.Name);
            }
                
            return result;
        }
        public void NextTurn()
        {
            this.Behavior.ApplyTurnEffects(this);
          
        }
    }
}
