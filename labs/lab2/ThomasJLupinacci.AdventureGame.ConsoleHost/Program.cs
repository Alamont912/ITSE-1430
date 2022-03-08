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
            DisplayIntro();

            bool menuLoop = true;

            //game loop
            do
            {
                int input = DisplayMenu();
                
                switch(input)
                {
                    case 0:
                    {
                        if (ConfirmQuit())
                            menuLoop = false;
                        break;
                    };

                    case 1: Move(); break;

                    case 2: Look(); break;



                    default: Console.WriteLine("Invalid option."); break;
                };

            } while (menuLoop);
        }

        private static void Look ()
        {

        }

        private static void Move ()
        {

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
