using System;
using System.Collections.Generic;
using System.Text;

namespace _10._The_Heigan_Dance
{
    public class Heigan
    {
        public double hitPoints { get; set; } = 3_000_000; 
        public bool isDead { get; set; } = false;


        public void takeDamage(double playerDamge)
        {
            this.hitPoints -= playerDamge;
            if (hitPoints<=0)
            {
                this.isDead = true;
            }
        }

        public void printResult()
        {
            if (this.isDead)
            {
                Console.WriteLine("Heigan: Defeated!");

            }
            else
            {
                Console.WriteLine($"Heigan: {this.hitPoints:f2}");
            }
        }
    }
}
