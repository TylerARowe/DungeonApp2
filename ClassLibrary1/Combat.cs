using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This class will not have fields, properties or ctors, as it is just a warehouse for different methods that will be a part of our combat functionality.

        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(3000);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //If the attacker hits, calc dmg.
                int damageDealt = attacker.CalcDamage();

                //assign the damage delt.
                defender.Life -= damageDealt;

                //write the result
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage\n", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0} missed! How pathetic.\n", attacker.Name);
            }//end else
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            //static methods. 
            //player attacks first.
            DoAttack(player, monster);
            /*
             * possible miss logic? work on in free time. Have to research this.
             */
             if(monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
