using System;

namespace DesignPatterns.Mediator.Models
{
    public abstract class GameUnit
    {
        public Action<string, int> onTakeDamage;
        public Action<string> onDeath;

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public GameUnit(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void Attack(GameUnit other)
        {
            other.ReceiveAttack(this);
        }

        public void ReceiveAttack(GameUnit attacker)
        {
            Health -= attacker.Damage;

            onTakeDamage?.Invoke(attacker.Name, attacker.Damage);

            if (Health <= 0)
            {
                onDeath?.Invoke(Name);
            }
        }
    }
}
