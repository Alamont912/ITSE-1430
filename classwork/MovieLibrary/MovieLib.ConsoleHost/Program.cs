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
            if (ReadBoolean($"Are you sure you want to delete '{movie.Title}'? (Y/N) "))
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

            Console.WriteLine(movie.Title);

            //Console.WriteLine(duration);
            //Console.WriteLine(rating);

            //String concatenation
            //Console.WriteLine(releaseYear + " (" + duration + " mins) - " + rating);

            //String formatting
            //Console.WriteLine("{0} ({1} mins) {2}", releaseYear, duration, rating); is equal to nextline
            //string temp = String.Format("{0} ({1} mins) {2}", releaseYear, duration, rating);
            //Console.WriteLine(temp);

            //String interpolation
            Console.WriteLine($"{movie.ReleaseYear} ({movie.Duration} mins) {movie.Rating}");

            //Console.WriteLine(genre);
            //Console.WriteLine(isColor);
            //Console.WriteLine(genre + " (" + isColor + ")");
            //if(isColor)
            //    Console.WriteLine($"{genre} (color)");
            //else
            //    Console.WriteLine($"{genre} (black and white)");

            //conditional operator
            Console.WriteLine($"{movie.Genre} ({(movie.IsClassic ? "Classic" : "")})");

            Console.WriteLine(movie.Description);
        }

        private static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (Y/N)? ");
        }

        private static void AddMovie()
        {
            movie = new Movie();

            object val = 10;
            val = "Hello";        //catch all tyop, performance suffers from this, inferrs type
            val = null;

            //movie.IsBlackAndWhite = false;  //setter is blank/non-existent, so this is ignored/read only
            do
            {

                movie.Title = ReadString("Enter a movie title: ", true);
                movie.Duration = ReadInt32("Enter duration in minutes (>= 0): ", 0);
                movie.ReleaseYear = ReadInt32("Enter the release year: ", 1900);
                movie.Rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
                movie.Genre = ReadString("Enter a genre (optional): ", false);
                movie.IsClassic = ReadBoolean("Is it a classic? (Y/N) ");
                movie.Description = ReadString("Enter a description (optional): ", false);

                //movie.CalculateBlackAndWhite();

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

        static void Display(object data)
        {
            //assume a string

            //C-style cast - runtime error if wrong, no way to validate at runtime,
            //still compile time safe
            var dataString = (string)data;

            //Type checking

            //is operator - returns boolean if correct type, still needs type cast
            if(data is string)
            {
                dataString = (string)data;
            };

            //as operator - safe, returns null if conversion is not possible, so it only
            // supports types that support null (strings, objects, class types).
            dataString = data as string;
            if(dataString != null)
            {
                
            };

            //pattern-matching
            if(data is string dataStringTwo)    //scope of variable is the if statement
            {
                
            };

            //The Two Type Catagories:

            //Reference
            //-----------------------------
            //Classes
            //
            //Always on the Heap, (new / dynamic memory / global memory), reference of some data
            //
            // M2 = M1 -> M2 points to the same address M1 points to, values are now shared
            //
            // M2 == M1 -> Only 'equal' if they refer to the same object instance in memory, basically a pointer comparison, formally known as "Reference Semantics"
            //
            //These can be null.
            //
            // Initialization construction can be customized.
            //
            // Supports inheritance.
            //
            // Can be mutable. The ability to change values is encouraged.

            //Value
            //-----------------------------
            //Structs
            //
            //Always on the Call Stack, therefore always available, value is directly on stack
            //
            // P2 = P1 -> Two copies, same sets of values, still independent of each other
            //
            // P2 == P1 -> Only 'equal' if all values are equal, formally known as "Value Semantics"
            //
            //These can never be null. It would not make sense.
            //
            // 0 initialized by the runtime.
            //
            // Does not support inheritance.
            //
            // Must be immutable. Once it has a value, it should not change.
        
        }
    }
}
