using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monster
    {
   
        public bool IsFluffy { get; set; }



        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {

            IsFluffy = isFluffy;
        }
        public Rabbit()
        {
   
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Rabbit";
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Life = 6;
            Description = "It's just a cute little bunny...Why would you want to fight this?";
            IsFluffy = false;
        }

        public override int CalcBlock()
        {
           int calculatedBlock = Block;

            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;

        }
    }
}
