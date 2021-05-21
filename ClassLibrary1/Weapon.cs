using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        //properites - props w/ biz rules (min dmg) listed last.
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //cannot be more than MaxDamage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //value is good to go, just assign the value 
                    _minDamage = value;
                }
                else
                {
                    //tried to set a value outside of the range
                    _minDamage = 1;
                }
            }
        }


        //ctors - all we need is a fully qualified ctor
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            //If you have any properties that utilize biz rules based off of othe properties, the other properties need to be set first. 
            //property = parameter;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            
        }

        public override string ToString()
        {
            return string.Format("{0}\t {1} to {2} Damage\n" +
                "Bonus Hit {3}\n" +
                "{4}", Name, MinDamage, MaxDamage, BonusHitChance, IsTwoHanded ? "Two-Handed" : "One-Handed");
        }
        //methods
    }
}
