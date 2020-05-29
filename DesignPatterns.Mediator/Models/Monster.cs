using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator.Models
{
    public class Monster : Unit
    {
        public Monster(string name, int health, int damage)
            : base(name, health, damage)
        {
        }

        public int Coins { get; private set; }
    }
}
