using DesignPatterns.Mediator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mediator.Events
{
    public class AttackOtherPlayerEvent : Event
    {
        public Player Attacker;
        public Player Defender;
    }
}
