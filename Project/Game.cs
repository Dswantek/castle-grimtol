using System.Collections.Generic;
using System;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public Boolean Playing { get; set; }

        public List<Room> Rooms { get; private set; }
        public List<Item> Items { get; private set; }

        public void Setup()
        {
            Console.Clear();
            Rooms = new List<Room>();

            Room room1 = new Room()
            {
                Description = "This place doesn't look safe. The TV is on and its a warning screen saying get out of the city before its too late. Call 311 if you can or tune to 1300am for updates.\nYou see a radio and its broken. There is a phone across the room. You dial 311 and someone picks up. They explain to you that the worst has happened.\nThere is a zombie Apocalypse and the city has been shut down in hopes of containing it. They will come to save you if you can get to the rooftop before the zombies get you.\nNext to the phone on the ground is a key without any description on it. There is a door to your south and to your west.",
                Name = "Starting room, Dentist Office in downtown NYC",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            Room room2 = new Room()
            {
                Description = "The main stairwell. The way up is blocked. Maybe if we go to a different floor we can find a way up, an elevator or another stairway. There is a door down one flight to the east and you can go back to the start if you go north.",
                Name = "Stairs",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            Room room3 = new Room()
            {
                Description = "Your in the main lobby of the building. All the doors are closed but you can hear/see zombies trying to make there way in... better hurry and find a way of here before they get you. There is a door to the south and the door you came through to the east. Or we could kill some zombies?? Look around to see if there are any items.",
                Name = "Lobby",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            Room room4 = new Room()
            {
                Description = "Alright you are on the elevator now. It is going up very slowly! Oh no... I think its going to stop. Hurry get out before it crashes to the floor below! There is a door above you, north, and a door behind you, south.",
                Name = "Elevator",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room room5 = new Room()
            {
                Description = "Finally the top floor. Lets find the stairs so you can get to the helicopter and escape! There is a door to your south, west, and northwest",
                Name = "Top Floor",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room rooftop = new Room()
            {
                Description = "You escaped!! Now hurry run to the helicopter before they break through the door! There is a pair of new Jordan's.... Do you want those before you go??",
                Name = "Rooftop",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room elevatorShaft = new Room()
            {
                Description = "NOOOOOOO!! What is this? Looks like you fell into the elevator shaft. You broke your leg. Looks like this is where you will die! I don't see any doors but there is an elevator above you, a syringe and a revolver on the ground, and no door to escape.",
                Name = "Elevator Shaft",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room death = new Room()
            {
                Description = "You jumped out of the building in hopes of falling to your death.... You are weak! You will soon hit the ground and hopefully die.\n..... You managed to live from the fall and escaped the building... but the zombies are now attacking you and you will soon become one of them.\nYOU LOSE",
                Name = "You Committed Suicide",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room escaped = new Room()
            {
                Description = "You made it! The helicopter pulled away as you jumped on. You escaped the Zombie Apocalypse... for now.",
                Name = "Congratulations You Won",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            Item syringe = new Item()
            {
                Description = "This looks sketchy, what is this black liquid inside it?",
                Name = "Syringe",
                Available = true
            };
            Item bat = new Item()
            {
                Description = "This is a baseball bat! SMASH SOME BRAINS!!!",
                Name = "Bat",
                Available = true
            };
            Item gun = new Item()
            {
                Description = "Might need this at some point... wink wink",
                Name = "Gun",
                Available = true
            };
            Item revolver = new Item()
            {
                Description = "Could be worse.... At least I won't die a zombie.",
                Name = "Revolver",
                Available = true
            };
            Item key = new Item()
            {
                Description = "This could come in handy",
                Name = "Key",
                Available = true
            };
            Item nikes = new Item()
            {
                Description = "You can't pass on a fresh new pair of Jordans. Better stop and slip these on real quick\nUse them to escape! Its the only way!",
                Name = "Nikes",
                Available = true
            };


            CurrentRoom = room1;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("------------------ZOMBIE Apocalypse------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What is your name: ");
            var name = Console.ReadLine();

            //Attempted to solve issue where player can have no name or a space as a name.
            // int attempts = 3;
            // while (name == " ")
            // {
            //     if (name == " " && attempts > 0)
            //     {
            //         attempts--;
            //         Console.WriteLine($"Please enter a valid name. You have {attempts} left");
            //         Console.WriteLine("What is your name: ");
            //     }
            //     else
            //     {
            //         EndGame();
            //     }
            // }
            
            CurrentPlayer = new Player(name);
            Console.WriteLine($"\n\nWelcome to the game {CurrentPlayer.Name}.\nBe careful and choose wisely. One false move and it could all be over. Good Luck!\n\n");
            UserHelp();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n\n{CurrentRoom.Name}");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("You slowly wake up. Lights are flickering the tv is on. You realize you're at the dentist. How long have you been here? Where is everyone? What time is it? Take a look around to see whats in the room.\n");
            Console.ForegroundColor = ConsoleColor.White;

            room1.Exits.Add("south", room2);
            room1.Exits.Add("north", room5);
            room1.Exits.Add("west", elevatorShaft);
            room2.Exits.Add("east", room3);
            room2.Exits.Add("north", room1);
            room3.Exits.Add("south", room4);
            room3.Exits.Add("west", room2);
            // room4.Exits.Add("north", room3);
            room4.Exits.Add("northeast", room1);
            room4.Exits.Add("north", room5);
            room5.Exits.Add("northwest", room1);
            room5.Exits.Add("south", room4);
            room5.Exits.Add("west", rooftop);
            rooftop.Exits.Add("north", escaped);


            //Fall to your Death... going down!
            room1.Exits.Add("down", death);
            room2.Exits.Add("down", death);
            room3.Exits.Add("down", death);
            room4.Exits.Add("down", death);
            room5.Exits.Add("down", death);
            rooftop.Exits.Add("down", death);


            elevatorShaft.Items.Add(syringe);
            elevatorShaft.Items.Add(revolver);
            room1.Items.Add(bat);
            room1.Items.Add(key);
            room3.Items.Add(gun);
            rooftop.Items.Add(nikes);
        }




        public void Move(string direction)
        {
            //given a string direction....
            //check if currentRoom.exits contains a key for direction
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                //a lot of things we can do in this instance
                Console.Clear();
                CurrentRoom = CurrentRoom.Exits[direction];
                //Insert color here
                if (CurrentRoom.Name.ToLower() == "you committed suicide")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"--------------{CurrentRoom.Name}--------------\n{CurrentRoom.Description}");
                    EndGame();
                }
                else if (CurrentRoom.Name.ToLower() == "congratulations you won")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"--------------{CurrentRoom.Name}--------------\n{CurrentRoom.Description}");
                    EndGame();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"--------------{CurrentRoom.Name}--------------");
                    Console.WriteLine($"{CurrentRoom.Description}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                //Insert color here
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("This is not a command that is acceptable. Try again");
            }
        }

        public void Reset()
        {
            Playing = true;
            Setup();
        }

        public void TakeItem(string itemName)
        {

            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);

            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
                Console.WriteLine($"You took the {item.Name}");
                PlayerInventory();
            }
        }
        public void UseItem(string itemName)
        {
            Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
            if (item.Name.ToLower() == "syringe")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Oh no..... Whats happening.... This feels weird.....\nWOW! I feel like the hulk! Lets get out of here!");
                Console.WriteLine("Looks like you can't be stopped! You broke out of the building and are now invincible. I guess thats one way to escape");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Want to play again? Try to actually escape this time without super powers.\nY/N?");
                var answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "y")
                {
                    Reset();
                }
                else if (answer == "n" || answer == "no")
                {
                    Playing = false;
                }
            }
            else if (item.Name.ToLower() == "revolver")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("I guess this is the end. At least you didn't become a zombie and you have a huge casket made of concrete :)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Want to play again? Try to actually escape this time without killing yourself\nY/N?");
                var answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "y")
                {
                    Reset();
                }
                else if (answer == "n" || answer == "no")
                {
                    Playing = false;
                }
            }
            else if (item.Name.ToLower() == "gun")
            {
                if (CurrentRoom.Name == "Lobby")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Time to kill some zombies! Get ready!");
                    Console.WriteLine("There are 24 Zombies and 12 bullets. How will you kill them all?\nHint: There is a large tank of gas in the middle of the room.");
                    Console.ForegroundColor = ConsoleColor.White;
                    var answer = Console.ReadLine().ToLower();
                    if (answer == "shoot tank")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You killed all the zombies! Good job. Now you have time to figure out what to do next.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Wrong. You now have 12 zombies runnning at you! Hurry get out of here!");
                        Console.WriteLine("You were killed by the zombies. Better luck next time!\n Want to play again? Y/N");
                        Console.ForegroundColor = ConsoleColor.White;
                        var playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "y" || playAgain == "yes")
                        {
                            Reset();
                        }
                        else
                        {
                            Playing = false;
                        }
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You cannot use this item in this room");
                }
            }
            else if (item.Name.ToLower() == "bat")
            {
                if (CurrentRoom.Name == "Stairs")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Zombies are coming up the stairs! Good thing you pulled your bat out. This is a baseball bat but you're not playing baseball... one strike and you're out. Good luck!");
                    Console.WriteLine("If you can answer this question you will survive.\nWhat is the capitol city of Wyoming?");
                    var riddleAnswer = Console.ReadLine().ToLower();
                    if (riddleAnswer == "cheyenne")
                    {
                        Console.WriteLine("Great job! You survived! There are plenty more where that came from so watch your back!");
                        // could make the bat unavailable after using it.....
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong Answer! You were eaten by zombies! It's only a matter of time before you become one of them. Better luck next time!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Would you like to play again?");
                        var playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "y" || playAgain == "yes")
                        {
                            Reset();
                        }
                        else
                        {
                            Playing = false;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You cannot use this item in this room. Try again!");
                }
            }
            else if (item.Name.ToLower() == "key")
            {
                if (CurrentRoom.Name == "Top Floor")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("A las the key was useful. You opened the door to the rooftop and now you can go through the door and make your way to the helicopter! If you are fast enough!");
                    // Rooms.rooftop.Locked = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You cannot use this item in this room. Try again!");
                }
            }
            else if (item.Name.ToLower() == "nikes")
            {
                if (CurrentRoom.Name == "Rooftop")
                {
                    Console.Beep();
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--------Congratulations You Escaped!--------\nYou made it! The helicopter pulled away as you jumped on. You escaped the Zombie Apocalypse... for now. \nWant to play again? Y/N");
                    var playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "y" || playAgain == "yes")
                    {
                        Reset();
                    }
                    else
                    {
                        Playing = false;
                    }

                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That item does not exist. Try one of the items in your inventory");
            }
        }

        public string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What do you want to do? ");
            var input = Console.ReadLine();
            return input;
        }

        public void Look()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{CurrentRoom.Description}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("-------Available Items-------");
            foreach (Item item in CurrentRoom.Items)
            {
                if (CurrentRoom.Items.Count > 0 && item.Available == true)
                {
                    Console.WriteLine($"{item.Name}: {item.Description}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no Items available in this room");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            PlayerInventory();
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void PlayerInventory()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------Inventory----------");
            foreach (Item item in CurrentPlayer.Inventory)
            {
                if (CurrentPlayer.Inventory.Count > 0)
                {
                    Console.WriteLine($"{item.Name}: {item.Description}");
                }
                else
                {
                    Console.WriteLine("Your inventory is empty");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void UserHelp()
        {
            Console.Write("-----HELP------\nAnytime you need help type help to see this list again.\nActions that you can make:\nMove: Tell me which direction you wish to move by typing 'go' and then the direction\n     Example: you want to move to the south type 'go s' or 'go south'\nLook: If you want to look around the room just type look and you will get the description of the room and available items in that room\nPickup Items: If you would like to pick up items just type 'pickup' and then the item name\n     Example: if you want to pickup a sword just type 'pickup sword'\nUse Items: If you want to use the item type 'use' and then the item name\n     Example: you want to use the sword type 'use sword'\n        Be careful when you use items..... it might hurt you \nReset: If you want to start over just type 'reset'\n          note: all your progress will be lost.\n");
        }

        public void EndGame()
        {
            Console.WriteLine("Want to play again? Y/N");
            var answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer == "yes")
            {
                Reset();
            }
            else
            {
                Playing = false;
            }
        }

    }
}