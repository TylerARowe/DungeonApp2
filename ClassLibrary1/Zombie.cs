using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Zombie : Monster
    {
 
        public Zombie(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {

        }
        public Zombie()
        {
 
            MaxLife = 12;
            MaxDamage = 4;
            Name = "Zombie";
            HitChance = 13;
            Block = 13;
            MinDamage = 1;
            Life = 6;
            Description = "Shambling disaster of a corpse.";
        }
    }
}