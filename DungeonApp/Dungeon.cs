using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp
{
    class Dungeon

        //a few notes
        //this is a good baseline, and I really like the ideas here but,
        //I'd like to create the logic for loot, for random levels of monsters, ie. one star two star three star versions of monsters. (This could most likely be handled by arrays and lists? idk, need to look into it.) 
        //possible werewolf class that is only available if you're playing on a full/new moon?
        //vampire class unavailable until after DateTime. etc. only available at night.
        //loot pools, different levels of weapons. Weapon drops, weapon durability?
        //Location, does this really have to stay a dungeon? Can we make this more of an outdoor location? 
        //How will we implement this into Unity (if thats something that needs to be done)
        //Working on room descriptions, I should probably come up with my own room descriptions.
        //Make sure I understand what the fuck this code actually means. No point in writing anything if I dont really understand the functionality.
        //This is due in 4-6 weeks. Take my time. Dont rush things.
        //Also dont be a procrastinator.
        //Ascii title sequence.
        //Bleh.

    {
        static void Main(string[] args)
        {
            //This is the program that will control the flow of the overall experience for the user. All classes will be created in seperate files and refered to in this program to allow us to use instances of monsters, players, weapons, rooms, etc. 

            Console.Title = "_-{DUNGEON APP}-_";
            Console.WriteLine("\n Fight your way out of the dungeon, or die trying.\n");
            int score = 0;

            //TODO 1. CREATE THE PLAYER - NEED TO CREATE A CLASS FOR THIS.
            //TODO 2. WEAPON(S).


            Weapon sword = new Weapon(1, 8, "Long Sword", 10, true);
            //Console.WriteLine(sword);
            Player player = new Player("Sir Arthur", 70, 2, 40, 40, Race.Canadian, sword);
            


            //TODO 3. CREATE A LOOP FOR THE ARENA(S) AND MONSTER(S).
            bool exit = false;
            do
            {
                //Enter a room. 
                //TODO 4. CALL GetRoom()
                Console.WriteLine(GetRoom());
                //TODO 5. Create a monster for the room - learn about creating objects and then randomly selecting them. 
                Rabbit r1 = new Rabbit();
                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 35, 20, 2, 8, "That's no ordinary rabbit...look at the bones!", true);
                Vampire v1 = new Vampire("The Count", 20, 20, 25, 10, 1, 10, "One Vampire...ah, ah, ah!");
                //since all of our monsters will inherit from the monster class all can be placed into a collection of Monster objects.
                Monster[] monsters = { r1, r2, v1 };

                //randomly select a monster from the array.

                Random rand = new Random();
                int randomNumber = rand.Next(monsters.Length);
                Monster monster = monsters[randomNumber];
                Console.WriteLine("A monster appears!\n\n " + monster.Name);

                //TODO 6. CREATE LOOP FOR THE ROOM.

                bool reload = false;
                do
                {
                    //TODO 7. CREATE A MENU
                    Console.WriteLine
                        ("\n\n PLEASE SELECT AN OPTION:\n\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit \n\n" +
                        "Current Score: {0}\n\n", score);

                    //TODO 8. CATCH USER CHOICE

                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    //Above will execute upon input without having to hit enter.


                    //BUILD LOGIC FOR LOOT


                    //TODO 9. CLEAR THE CONSOLE AND BUILD THE SWITCH BASED ON USERCHOICE
                    Console.Clear();
                    #region Switch(User Choice)
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("You attack the monster in front of you.\n");
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //could put logic here to have the player recieve loot, something along those lines. Might research the ability to create a loot pool and the functionality surrounding it. Possibly even working with pocket monsters? Unknown. More research needed.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true;//New room get
                                score++;
                            }
                            //TODO 10. BUILD ATTACK LOGIC
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("You cower with your tail between your legs like the pathetic dog you are.\n");
                            Console.WriteLine($"{monster.Name} attacks you as you run away!\n");
                            Combat.DoAttack(monster, player);
                            reload = true;
                            //TODO 11. BUILD RUN AWAY LOGIC
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Your player is as follows:\n");
                            Console.WriteLine(player);
                            break;
                            
                        //TODO 12. ADD PLAYER INFORMATION 
                        case ConsoleKey.M:
                            Console.WriteLine("The monster is as follows:\n");
                            Console.WriteLine(monster);
                            break;
                            //TODO 13. ADD MONSTER INFORMATION
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("Thank you for playing adventurer, hopefully you return to the dungeon once again.\n");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("User interaction not recognized, please try again.");
                            break;
                    }

                    //TODO 14. HANDLE PLAYER LIFE
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


        //TODO 15. CREATE GetRoom() & PLUG IT IN TO THE TODO ABOVE
        private static string GetRoom()//why doesnt this work? //>:( 
            //could this be refractored to be an enum? If so, would the functionality work the same? and could we call upon rooms in such a way that the console will still display the rooms in an adequate way
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

            //generate a Random object and get a random room description
            Random rand = new Random();
            //since the maxValue in the Next() is exclusive, we can just use the Length property to include all indexes from our array.
            int indexNbr = rand.Next(rooms.Length);
            string room = "******* NEW ROOM ********\n" + rooms[indexNbr] + "\n";
            //return room
            return room;


        }
    }

}
