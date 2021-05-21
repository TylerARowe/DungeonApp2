using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
    
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if(value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

       
        public Monster()
        {

        }
        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxDamage = maxDamage;
            MaxLife = maxLife;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            Description = description;

        }
       
        public override string ToString()
        {
            return string.Format("\n===- MONSTER -===\n" +
                "{0}\n" +
                "Life: {1} to {2}\n" +
                "Damage: {3} to {4}\n" +
                "Block: {5}\n" +
                "Description: \n{6}\n",
                Name,
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            
        }

    }
}
