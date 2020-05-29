using System;

namespace DesignPatterns.Mediator.Models
{
    public class Player : Unit
    {
        public Player(string name, int health, int damage, ConsoleColor color)
            : base(name, health, damage)
        {
            Color = color;
        }

        public ConsoleColor Color { get; private set; }
    }
}
