using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Remember to make your classes public to allow access to these blueprints from other projects in your solution. The default is internal, which would make this class only accessible in DungeonLibrary, but it would not be accessible in DungeonApp.

    //We can add the Abstract modifier in the class signature which indicates that this class is an incomplete implementation. This modifier can be used with methods, classes, and properties. Below, we will use the abstract modifier to indicate that we cannot create any instances of this class, but instead it will just serve as a base class for Player and Monster.
    public abstract class Character
    {
        //This class will server as a base/parent class for Player and Monster.
        //In this class, we only need properties/fields that are shared between player and monster.

        //fields
        private int _life;

        //props
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    //GOOD TO GO
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }

        }
        //ctors - since we don't inherit constructors, we will define the CTORS in Player and Monster. We still get the default CTOR, be will be unable to use it since the class is Abstract.

        //methods - we are not going to write out a new ToString() version because we cannot create the Character object.
        //we will create methods that will be inherited by Player, Monster, and any other child classes. These methods are there to prove a very basic functionality, and will be customized in those classes.
        public virtual int CalcBlock()
        {
            //The virtual keyword above allows us to override this method in other classes.
            return Block;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcDamage()
        {
            return 0;
        }

            //Keyword virtual allows the method to be overwritten.
    }
}
