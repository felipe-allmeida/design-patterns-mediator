using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator.Models
{
    public class Player : Unit
    {
        public Player(int health, int damage, ConsoleColor color)
            : base(health, damage)
        {
            Color = color;
        }

        public ConsoleColor Color { get; private set; }
    }
}
