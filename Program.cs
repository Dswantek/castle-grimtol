using System;
using System.Collections.Generic;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Project.Game adventureGame = new Game();
            adventureGame.Playing = true;
            Console.BackgroundColor = ConsoleColor.Black;
            adventureGame.Setup();
            // int userEnergy = 10;


            while (adventureGame.Playing)
            {
                string command = adventureGame.GetUserInput().ToLower();
                string[] choice = command.Split(' ');

                if (choice[0] == "q" || choice[0] == "quit")
                {
                    //ends the game
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to quit? Y/N");
                    var answer = Console.ReadLine().ToLower();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (answer == "y" || answer == "yes")
                    {
                        adventureGame.Playing = false;
                    }
                }
                else if (choice[0] == "l" || choice[0] == "look")
                {
                    adventureGame.Look();
                }
                else if (choice[0] == "r" || choice[0] == "reset")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure you want to restart? Y/N");
                    var answer = Console.ReadLine().ToLower();
                    Console.ForegroundColor = ConsoleColor.White;
                    if (answer == "y" || answer == "yes")
                    {
                        adventureGame.Reset();
                    }
                }
                else if (choice[0] == "h" || choice[0] == "help")
                {
                    adventureGame.UserHelp();
                }
                switch (choice[0])
                {
                    case "run":
                    case "go":
                        switch (choice[1])
                        {
                            case "n":
                            case "north":
                                adventureGame.Move("north");
                                break;
                            case "s":
                            case "south":
                                adventureGame.Move("south");
                                break;
                            case "e":
                            case "east":
                                adventureGame.Move("east");
                                break;
                            case "w":
                            case "west":
                                adventureGame.Move("west");
                                break;
                            case "d":
                            case "down":
                                adventureGame.Move("down");
                                break;
                        }
                        break;
                    case "grab":
                    case "pickup":
                    case "take":
                        switch (choice[1])
                        {
                            case "s":
                            case "syringe":
                                adventureGame.TakeItem("syringe");
                                Console.WriteLine("I don't know why I took this..... might accidently poke me!");
                                // adventureGame.UseItem("syringe");
                                break;
                            case "g":
                            case "gun":
                                adventureGame.TakeItem("gun");
                                break;
                            case "k":
                            case "key":
                                adventureGame.TakeItem("key");
                                break;
                            case "b":
                            case "baseball":
                            case "baseball bat":
                            case "bat":
                                adventureGame.TakeItem("bat");
                                break;
                            case "revolver":
                                adventureGame.TakeItem("revolver");
                                break;
                            case "nikes":
                                adventureGame.TakeItem("nikes");
                                break;
                        }
                        break;
                    case "use":
                        switch (choice[1])
                        {
                            case "s":
                            case "syringe":
                                adventureGame.UseItem("syringe");
                                break;
                            case "g":
                            case "gun":
                                adventureGame.UseItem("gun");
                                break;
                            case "k":
                            case "key":
                                adventureGame.UseItem("key");
                                break;
                            case "b":
                            case "baseball":
                            case "baseball bat":
                            case "bat":
                                adventureGame.UseItem("bat");
                                break;
                            case "revolver":
                                adventureGame.UseItem("revolver");
                                break;
                            case "nikes":
                                adventureGame.UseItem("nikes");
                                break;
                        }
                        break;
                }

        // Planned on using this to end the game but didn't want to limit people on how many guesses they could have so you can see all the options.

                // if (userEnergy > 0)
                // {
                //     Console.WriteLine($"This is not an action that can be performed..... Your energy has decreased and you have become weaker. {userEnergy} more times and you might not have enough energy to make it out alive. Try again");
                //     userEnergy -= 1;
                // }
                // else if (userEnergy <= 0)
                // {
                //     Console.WriteLine("You are out of energy. The living dead have come to devour your corpse. You will soon become one of them and hunt fo other humans and living beings like yourself. Better luck next time.\n");
                //     Console.WriteLine("Would you like to play again?? Y/N\n");
                //     string playAgain = Console.ReadLine();
                //     if (playAgain.ToLower() == "y" || playAgain.ToLower() == "yes")
                //     {
                //         adventureGame.Reset();
                //     }
                //     else
                //     {
                //         adventureGame.Playing = false;
                //         Console.WriteLine("You are a coward! You will never amount to anything until you can complete this game and escape.");
                //     }
                // }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------GAME OVER!!----------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
