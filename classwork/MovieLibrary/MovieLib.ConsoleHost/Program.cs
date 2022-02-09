/*
 * Your Name
 * ITSE 1430
 * Lab #
 */
using System;

namespace MovieLib.ConsoleHost
{
    class Program
    {
        //Entry point
        static void Main(string[] args)
        {
            //TODO: Display a menu
            do
            {
                char input = DisplayMenu();

                //TODO: Handle input
                //if (input == 'A')
                //    AddMovie();
                //else if (input == 'V')
                //    ViewMovie();
                //else if (input == 'Q')
                //    if (ConfirmQuit())
                //        break;  //Exit loop construct

                switch(input)
                {
                    case 'A':
                    case 'a': AddMovie(); break;

                    case 'V':
                    case 'v': ViewMovie(); break;

                    case 'Q':
                    case 'q':
                    {
                        if (ConfirmQuit())
                            break;
                        break;
                    };
                    default: Console.WriteLine("Invalid option."); break;
                };
            } while (true);
        }

        private static void ViewMovie ()
        {
            //TODO: Does movie exist?
            Console.WriteLine(title);

            //Console.WriteLine(duration);
            //Console.WriteLine(rating);

            //String concatenation
            //Console.WriteLine(releaseYear + " (" + duration + " mins) - " + rating);

            //String formatting
            //Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating); is equal to nextline
            //string temp = String.Format("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //Console.WriteLine(temp);

            //String interpolation
            Console.WriteLine($"{releaseYear} ({duration} mins) {rating}");

            //Console.WriteLine(genre);
            //Console.WriteLine(isColor);
            //Console.WriteLine(genre + " (" + isColor + ")");
            //if(isColor)
            //    Console.WriteLine($"{genre} (color)");
            //else
            //    Console.WriteLine($"{genre} (black and white)");

            //conditional operator
            Console.WriteLine($"{genre} ({(isColor ? "Color" : "Black and White")})");

            Console.WriteLine(description);
        }

        private static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (Y/N)? ");
        }

        private static void AddMovie()
        {
            title = ReadString("Enter a movie title: ", true);
            duration = ReadInt32("Enter duration in minutes (>= 0): ", 0);
            releaseYear = ReadInt32("Enter the release year: ", 1900);
            rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
            genre = ReadString("Enter a genre (optional): ", false);
            isColor = ReadBoolean("In color? (Y/N) ");
            description = ReadString("Enter a description (optional): ", false);
        }

        //Unit 1 only!!     Could this be a global variable?
        static string title;
        static int duration;
        static int releaseYear;
        static string rating;           //time for crab
        static string genre;
        static bool isColor;
        static string description;

        static bool ReadBoolean ( string message )
        {
            //TODO: Fix prompt
            Console.Write(message);

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(); //read keys as users type them

                //Validate
                if (key.Key == ConsoleKey.Y)    //handles case-sensitivity
                {
                    Console.WriteLine();
                    return true;
                } 
                else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine();
                    return false;
                };
            } while (true);
        }

        private static int ReadInt32(string message, int minimumValue)
        {
            Console.Write(message);

            while(true)
            {
                //string input = Console.ReadLine();
                var input = Console.ReadLine();     //type inferencing
                                                    //compiler infers type based on usage
                                                    //ZERO impact on runtime behavior

                //TODO: Validate input
                //int result;
                //int result = Int32.Parse(input);    //string to int, Double.Parse(), Int64.Parse()
                //if (Int32.TryParse(input, out int result))   //parsing, but returns output param 
                //    if (result >= minimumValue)         //indicating success
                //        return result;
                if (Int32.TryParse(input, out var result) && result >= minimumValue)
                    return result;

                Console.WriteLine("Value must be >= " + minimumValue);
            };
        }

        //Functions are PascalCased verbs and should do a single, logical thing
        private static string ReadString(string message, bool required)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            //TODO: Validate input, if required

            return input;
        }

        static char DisplayMenu()
        {
            Console.WriteLine("A)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");

            string input = Console.ReadLine();

            //Validate Input
            if (input == "A")
                return 'A';
            else if (input == "V")
                return 'V';
            else if (input == "E")
                return 'E';
            else if (input == "D")
                return 'D';
            else if (input == "Q")
                return 'Q';
            else
            {
                Console.WriteLine("Invalid Input");
                return 'X';
            };
        }
    }
}
