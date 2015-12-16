using System;
namespace Empires.BaseClasses
{
    public abstract class Unit
    {
        private int health;
        private int attackDamage;
        public Unit(int health, int attackDamage)
        {
            if (health < 1)
            {
                throw new ArgumentOutOfRangeException("Initial unit Health must be positive");
            }
            else
            {
                this.Health = health;
            }
            this.AttackDamage = attackDamage;
        }
        public int Health 
        { 
            get { return this.health; }
            set
            {
                if (value > 0)
                {
                    this.health = value;
                }
                else 
                {
                    this.health = 0;
                }
            }
        }
        public int AttackDamage
        {
            get
            {
                return this.attackDamage;
            }
            set
            {
                if (value >= 0)
                    this.attackDamage = value;
                else
                    throw new ArgumentOutOfRangeException("Unit Attack Damage value must be non-negative!");
            }
        }

        public string ID
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
