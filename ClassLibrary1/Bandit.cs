using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Bandit : Monster
    {

        public bool IsBoss { get; set; }


        public Bandit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isBoss) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {

            IsBoss = isBoss;
        }
        public Bandit()
        {

            MaxLife = 12;
            MaxDamage = 4;
            Name = "Bandit";
            HitChance = 15;
            Block = 25;
            MinDamage = 3;
            Life = 8;
            Description = "Just your friendly farmer turned rogue.";
            IsBoss = false;
        }

        public override int CalcBlock()
        {

            int calculatedBlock = Block;

            if (IsBoss)
            {
                calculatedBlock += calculatedBlock +5;
            }

            return calculatedBlock;

        }
    }
}
