using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp
{
    class Dungeon
    {
        static void Main(string[] args)
        {

            Console.Title = "_-{THE ARENA}-_";
            Console.WriteLine("\n Fight your way out of the arena, or die trying.\n");
            int score = 0;

            Weapon sword = new Weapon(1, 8, "Long Sword", 10, true);
            Weapon axe = new Weapon(1, 6, "One-handed Axe", 8, false);
            Weapon polearm = new Weapon(1, 12, "Polearm", 15, true);
            Weapon staff = new Weapon(1, 5, "Staff", 9, true);
            
            Player player = new Player("Protogas", 70, 2, 40, 40, Race.Argonian, axe);

            bool exit = false;
            do
            {

                Console.WriteLine(GetRoom());
                Rabbit r1 = new Rabbit();
                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 35, 20, 2, 8, "That's no ordinary rabbit...look at the bones!", true);
                Vampire v1 = new Vampire("The Count", 20, 20, 25, 10, 1, 10, "One Vampire...ah, ah, ah!");
                Zombie z1 = new Zombie();
                Bandit b1 = new Bandit();
                Bandit b2 = new Bandit("Sheild Bandit", 25, 25, 20, 25, 6, 10, "This ones definitely tougher.", true);

                Monster[] monsters = { r1, r2, v1, z1, b1, b2 };

                Random rand = new Random();
                int randomNumber = rand.Next(monsters.Length);
                Monster monster = monsters[randomNumber];
                Console.WriteLine("A monster appears!\n\n " + monster.Name);



                bool reload = false;
                do
                {

                    Console.WriteLine
                        ("\n\n PLEASE SELECT AN OPTION:\n\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit \n\n" +
                        "Current Score: {0}\n\n", score);


                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();
                    #region Switch(User Choice)
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("You attack the monster in front of you.\n");
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {

                                //could put logic here to have the player recieve loot, something along those lines. Might research the ability to create a loot pool and the functionality surrounding it. Possibly even working with pocket monsters? 

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
               
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("You cower with your tail between your legs like the pathetic dog you are.\n");
                            Console.WriteLine($"{monster.Name} attacks you as you run away!\n");
                            Combat.DoAttack(monster, player);
                            reload = true;
           
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Your player is as follows:\n");
                            Console.WriteLine(player);
                            break;
                            
        
                        case ConsoleKey.M:
                            Console.WriteLine("The monster is as follows:\n");
                            Console.WriteLine(monster);
                            break;
         
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("Thank you for playing adventurer, hopefully you return to the dungeon once again.\n");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("User interaction not recognized, please try again.");
                            break;
                    }

   
                    if(player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Oh dear, you are dead!\n");
                        exit = true;
                    }

                    #endregion
                } while (!reload && !exit);
            } while (!exit);

        }


       
        private static string GetRoom()
        {
            string[] rooms =
            {
                "Three low, oblong piles of rubble lie near the center of this small room. Each has a weapon jutting upright from one end -- a longsword, a spear, and a quarterstaff. The piles resemble cairns used to bury dead adventurers.",

                "You peer into this room and spot the white orb of a skull lying on the floor. Suddenly a stone falls from the ceiling and smashes the skull to pieces. An instant later, another stone from the ceiling drops to strike the floor and shatter. You hear a low rumbling and cracking noise.",

                "Several exits lead from this room, but only one is within the mouth of a man. The door opposite you stands within an intricate stone carving of a man's wide-open mouth. The man's nose and eyes loom over the door while his sculpted hair splays out across the wall on either side.",

                "A rusted portcullis stands just beyond the door. Looking into the room, you see three other exits, similarly blocked by portcullises. Four skeletons dressed in aged clothing and rusting armor lie on the floor in the room against the walls. They seem in poses of repose rather than violence.",

                "A chill crawls up your spine and out over your skin as you look upon this room. The carvings on the wall are magnificent, a symphony in stonework -- but given the themes represented, it might be better described as a requiem. Scenes of death, both violent and peaceful, appear on every wall framed by grinning skeletons and ghoulish forms in ragged cloaks.",

                "Thick cobwebs fill the corners of the room, and wisps of webbing hang from the ceiling and waver in a wind you can barely feel. One corner of the ceiling has a particularly large clot of webbing within which a goblin's bones are tangled.",

                "You open the door, and the room comes alive with light and music. A sourceless, warm glow suffuses the chamber, and a harp you cannot see plays soothing sounds. Unfortunately, the rest of the chamber isn't so inviting. The floor is strewn with the smashed remains of rotting furniture. It looks like the room once held a bed, a desk, a chest, and a chair."
            };

            
            Random rand = new Random();
           
            int indexNbr = rand.Next(rooms.Length);
            string room = "******* NEW ROOM ********\n" + rooms[indexNbr] + "\n";
            
            return room;


        }
    }

}
