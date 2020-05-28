using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator.Models
{
    public abstract class Unit
    {
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public Unit(int health, int damage)
        {
            Health = health;
            Damage = damage;
        }

        public void Attack(Unit other)
        {
            other.ReceiveAttack(this);
        }

        public void ReceiveAttack(Unit attacker)
        {
            Health -= attacker.Damage;

            if (Health <= 0)
            {
                // notify is dead
            }
        }
    }
}
