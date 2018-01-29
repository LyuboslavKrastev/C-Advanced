using System;
using System.Collections.Generic;
using System.Text;

namespace _10._The_Heigan_Dance
{
    public class Player
    {
        public double hitPoints { get; set; } = 18500;
        public int Damage { get; set; }
        public bool isPlagued { get; set; } = false;
        public bool isDead { get; set; } = false;
        public Position currentPosition { get; set; } = new Position(7, 7);
        public string fatalSpell { get; set; }

        public void plagueDamage()
        {
            hitPoints -= 3500;
            isPlagued = false;
            if (hitPoints <= 0)
            {
                this.isDead = true;
            }
        }
        public void eruptionDamage()
        {
            hitPoints -= 6000;
            if (hitPoints <= 0)
            {
                this.isDead = true;
            }
        }
        public void printResult()
        {
            if (this.isDead)
            {
                Console.WriteLine($"Player: Killed by {this.fatalSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {this.hitPoints}");
            }
            Console.WriteLine($"Final position: {this.currentPosition.row}, {this.currentPosition.col}");
        }
    }
}
