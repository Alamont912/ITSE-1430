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
            bool menuLoop = true;
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

                    case 'D':
                    case 'd': DeleteMovie(); break;

                    case 'Q':
                    case 'q':
                    {
                        if (ConfirmQuit())
                            menuLoop = false;
                        break;
                    };
                    default: Console.WriteLine("Invalid option."); break;
                };
            } while (menuLoop);
        }

        private static void DeleteMovie ()
        {
            if (movie == null)
            {
                Console.WriteLine("No movie to delete.");
                return;
            };

            //delete the movie
            if (ReadBoolean($"Are you sure you want to delete '{movie._title}'? (Y/N) "))
                movie = null;
        }

        private static void ViewMovie ()
        {
            //TODO: Does movie exist?
            //if(String.IsNullOrEmpty(movie.title))
            if(movie == null)
            {
                Console.WriteLine("No movie to view.");
                return;
            }

            Console.WriteLine(movie._title);

            //Console.WriteLine(duration);
            //Console.WriteLine(rating);

            //String concatenation
            //Console.WriteLine(releaseYear + " (" + duration + " mins) - " + rating);

            //String formatting
            //Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating); is equal to nextline
            //string temp = String.Format("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //Console.WriteLine(temp);

            //String interpolation
            Console.WriteLine($"{movie._releaseYear} ({movie._duration} mins) {movie._rating}");

            //Console.WriteLine(genre);
            //Console.WriteLine(isColor);
            //Console.WriteLine(genre + " (" + isColor + ")");
            //if(isColor)
            //    Console.WriteLine($"{genre} (color)");
            //else
            //    Console.WriteLine($"{genre} (black and white)");

            //conditional operator
            Console.WriteLine($"{movie._genre} ({(movie._isClassic ? "Classic" : "")})");

            Console.WriteLine(movie._description);
        }

        private static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (Y/N)? ");
        }

        private static void AddMovie()
        {
            movie = new Movie();

            do
            {

                movie.Title = ReadString("Enter a movie title: ", true);
                movie._duration = ReadInt32("Enter duration in minutes (>= 0): ", 0);
                movie._releaseYear = ReadInt32("Enter the release year: ", 1900);
                movie._rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
                movie._genre = ReadString("Enter a genre (optional): ", false);
                movie._isClassic = ReadBoolean("Is it a classic? (Y/N) ");
                movie._description = ReadString("Enter a description (optional): ", false);

                movie.CalculateBlackAndWhite();

                var error = movie.Validate();

                if (String.IsNullOrEmpty(error))
                    return;

                Console.WriteLine(error);
            } while (true);
        }

        //Unit 1 only!!     Could this be a global variable?
        static Movie movie;

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
            do
            {
                string input = Console.ReadLine();

                //TODO: Validate input, if required
                if (!required || !String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Value is required.");
            } while (true);

        }

        static char DisplayMenu()
        {
            Console.WriteLine("Movie Library");
            //Console.WriteLine("--------------");
            Console.WriteLine("".PadLeft(20, '-'));
            Console.WriteLine("A)dd Movie");
            Console.WriteLine("V)iew Movie");
            Console.WriteLine("E)dit Movie");
            Console.WriteLine("D)elete Movie");
            Console.WriteLine("Q)uit");
            Console.WriteLine("".PadLeft(20, '-'));

            do
            {
                string input = Console.ReadLine();

                //Validate Input
                if (String.Compare(input, "A", true) == 0)
                    return 'A';
                else if (String.Compare(input, "V", true) == 0)
                    return 'V';
                else if (String.Compare(input, "E", true) == 0)
                    return 'E';
                else if (String.Compare(input, "D", true) == 0)
                    return 'D';
                else if (String.Compare(input, "Q", true) == 0)
                    return 'Q';
                else
                    Console.WriteLine("Invalid Input");
            } while (true);
        }
    }
}
