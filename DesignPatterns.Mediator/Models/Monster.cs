using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator.Models
{
    public class Monster : Unit
    {
        public Monster(int health, int damage, int coins)
            : base(health, damage)
        {
            Coins = coins;
        }

        public int Coins { get; private set; }
    }
}
