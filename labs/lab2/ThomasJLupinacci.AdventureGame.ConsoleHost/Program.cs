/*
 * Thomas J. Lupinacci III
 * 3/7/22
 * ITSE 1430
*/

using System;

namespace ThomasJLupinacci.AdventureGame.ConsoleHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creates world
            World GameWorld = new World();

            //spawns player at starting room of world
            Player myPlayer = new Player(GameWorld.StartingRoom);

            DisplayIntro();

            bool menuLoop = true;

            //game loop
            do
            {
                Console.WriteLine($"{myPlayer.CurrentRoom.Name}\n" +
                                  $"{myPlayer.CurrentRoom.Description}");

                int input = DisplayMenu();
                
                switch(input)
                {
                    case 0:
                    {
                        if (ConfirmQuit())
                            menuLoop = false;
                        break;
                    };

                    case 1: Move(myPlayer); break;

                    case 2: Look(); break;



                    default: Console.WriteLine("Invalid option."); break;
                };

            } while (menuLoop);
        }

        private static void Look ()
        {
            Console.WriteLine("This feature is unavailable at the moment.\n");
        }

        private static void Move (Player myPlayer)
        {
            Console.WriteLine("Which Direction?");
            Console.WriteLine("".PadLeft(20, '-'));
            Console.WriteLine("1. North");
            Console.WriteLine("2. East");
            Console.WriteLine("3. South");
            Console.WriteLine("4. West");
            Console.WriteLine("".PadLeft(20, '-'));

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                if (myPlayer.CurrentRoom.North != null)
                    myPlayer.CurrentRoom = myPlayer.CurrentRoom.North;
                else
                    Console.WriteLine("You've hit the border! Try another direction.\n");
                break;

                case "2":
                if (myPlayer.CurrentRoom.East != null)
                    myPlayer.CurrentRoom = myPlayer.CurrentRoom.East;
                else
                    Console.WriteLine("You've hit the border! Try another direction.\n");
                break;

                case "3":
                if (myPlayer.CurrentRoom.South != null)
                    myPlayer.CurrentRoom = myPlayer.CurrentRoom.South;
                else
                    Console.WriteLine("You've hit the border! Try another direction.\n");
                break;

                case "4":
                if (myPlayer.CurrentRoom.West != null)
                    myPlayer.CurrentRoom = myPlayer.CurrentRoom.West;
                else
                    Console.WriteLine("You've hit the border! Try another direction.\n");
                break;

                default:
                Console.WriteLine("Nevermind, then.\n");
                break;
            }
        }

        private static int DisplayMenu ()
        {
            Console.WriteLine("Player Menu");
            Console.WriteLine("".PadLeft(20, '-'));
            Console.WriteLine("1. Move");
            Console.WriteLine("2. Look");
            Console.WriteLine("0. Quit");
            Console.WriteLine("".PadLeft(20, '-'));

            do
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0": return 0; break;
                    case "1": return 1; break;
                    case "2": return 2; break;
                    default: Console.WriteLine("Invalid input."); break;
                }
            } while (true);
        }

        private static void DisplayIntro ()
        {
            Console.WriteLine("Thomas J. Lupinacci III\n" +
                              "ITSE 1430\n" +
                              "Spring 2022\n\n");
        }

        private static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (Y/N)? ");
        }

        static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(); //read keys as users type them

                //Validate
                if (key.Key == ConsoleKey.Y)    //handles case-sensitivity
                {
                    Console.WriteLine();
                    return true;
                } else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine();
                    return false;
                };
            } while (true);
        }
    }
}
