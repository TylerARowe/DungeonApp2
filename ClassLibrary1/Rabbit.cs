using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monster
    {
        //We created a child monster with at least one unique property below/
        //fields

        //props
        public bool IsFluffy { get; set; }


        //ctors
        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            //just handle unique properties from your class.
            IsFluffy = isFluffy;
        }
        public Rabbit()
        {
            //Set values for this constructor so that when an instance of an object is created using this default ctor, the rabbit or the instance of a rabbit will already have some values for it's properties. 
            //Set Max values
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
        //methods
        //Override the block method to say if the rabbit is fluffy, they get a 50% bonus to their block value.
        public override int CalcBlock()
        {
            //typically when dealing with a method that has a return type, you create a variable of the type you need to return with some default value. Then we write the return line and finally write the code in between.
            int calculatedBlock = Block;

            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;

        }
    }
}
