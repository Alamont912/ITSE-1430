using System;

namespace CharacterCreator.ConsoleHost
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Console.WriteLine("Thomas J. Lupinacci\nITSE-1430\n2/14/22\n\n");

            bool done = false;

            do
            {
                char input = DisplayMenu();

                switch (input)
                {
                    case 'C':
                    case 'c': CreateCharacter(); break;

                    case 'V':
                    case 'v': ViewCharacter(); break;

                    case 'E':
                    case 'e': EditCharacter(); break;

                    case 'D':
                    case 'd': DeleteCharacter(); break;

                    case 'Q':
                    case 'q':
                    {
                        if (ConfirmQuit())
                            done = true;
                        break;
                    }
                    default: Console.WriteLine("Invalid option."); break;
                }

            } while (done == false);
        }

        private static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (Y/N) ");
        }

        private static bool ReadBoolean ( string message )
        {
            Console.WriteLine(message);

            do
            {
                ConsoleKeyInfo key = Console.ReadKey();     //read keystrokes

                //Validate
                if (key.Key == ConsoleKey.Y)
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

        private static void DeleteCharacter ()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("There ain't no character to delete, buddy.");
                return;
            }

            bool choice = ReadBoolean("Are ya sure you wanna delete yer character? (Y/N) ");

            if (choice)
            {
                string temp = name;
                name = "";
                hobby = "";
                profession = "";

                statGrit = 0;
                statMuscle = 0;
                statMysticallity = 0;
                statMoxie = 0;
                statGumption = 0;

                backstory = "";

                Console.WriteLine($"{temp} has yee'd their last haw... (character deleted)");
            }
        }

        private static void EditCharacter ()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ain't no character to edit.");
                return;
            }

            if (ReadBoolean($"Change yer name? ({name}) (Y/N)"))
                name = ReadString("What's yer name, pardner?", true);

            if (ReadBoolean($"Change yer hobby? ({hobby}) (Y/N)"))
                hobby = DisplayHobbyMenu();

            if (ReadBoolean($"Change yer profession? ({profession}) (Y/N)"))
                profession = DisplayProfessionMenu();

            if (ReadBoolean($"Change yer GRIT? ({statGrit}) (Y/N)"))
                statGrit = ReadInt("Can you take a hit? What's yer GRIT? : ", 1, 100);

            if (ReadBoolean($"Change yer MUSCLE? ({statMuscle}) (Y/N)"))
                statMuscle = ReadInt("Ready fer a tussel? What's yer MUSCLE? : ", 1, 100);

            if (ReadBoolean($"Change yer MYSTICALLITY? ({statMysticallity}) (Y/N)"))
                statMysticallity = ReadInt("Want to bend yer reality? What's yer MYSTICALLITY? : ", 1, 100);

            if (ReadBoolean($"Change yer MOXIE? ({statMoxie}) (Y/N)"))
                statMoxie = ReadInt("Need a sharp eye to be foxy? What's yer MOXIE? : ", 1, 100);

            if (ReadBoolean($"Change yer GUMPTION? ({statGumption}) (Y/N)"))
                statGumption = ReadInt("Need speed to function? What's yer GUMPTION? : ", 1, 100);

            if (ReadBoolean($"Change yer backstory? ({backstory}) (Y/N)"))
                backstory = ReadString("Have a tale to tell? Got a backstory? : ", false);
        }

        private static void ViewCharacter ()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ain't no character to view.");
                return;
            }

            Console.WriteLine("#####################");
            Console.WriteLine(name);
            Console.WriteLine("#####################");
            Console.WriteLine($"Hobby: {hobby}\n" +
                $"Profession: {profession}\n" +
                $"\n" +
                $"Grit: {statGrit}\nMuscle: {statMuscle}\nMysticllity: {statMysticallity}\n" +
                $"Moxie: {statMoxie}\nGumption: {statGumption}\n\nBackstory: {backstory}\n");

        }

        private static void CreateCharacter ()
        {
            name = ReadString("What's yer name, pardner?", true);
            hobby = DisplayHobbyMenu();
            profession = DisplayProfessionMenu();

            statGrit = ReadInt("Can you take a hit? What's yer GRIT? : ", 1, 100);
            statMuscle = ReadInt("Ready fer a tussel? What's yer MUSCLE? : ", 1, 100);
            statMysticallity = ReadInt("Want to bend yer reality? What's yer MYSTICALLITY? : ", 1, 100);
            statMoxie = ReadInt("Need a sharp eye to be foxy? What's yer MOXIE? : ", 1, 100);
            statGumption = ReadInt("Need speed to function? What's yer GUMPTION? : ", 1, 100);

            backstory = ReadString("Have a tale to tell? Got a backstory? : ", false);
        }

        private static int ReadInt ( string message, int minValue, int maxValue )
        {
            Console.WriteLine(message);

            while (true)
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out int result) && result >= minValue && result <= maxValue)
                    return result;

                Console.WriteLine($"Value must be from {minValue} to {maxValue}.");
            }
        }

        private static string DisplayProfessionMenu ()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("[R]anchhand");
            Console.WriteLine("[C]ookie");
            Console.WriteLine("[S]windler");
            Console.WriteLine("[T]raveler");
            Console.WriteLine("[O]utlaw");
            Console.WriteLine("---------------------");

            do
            {
                string input = ReadString("What kinda man were you 'fore the cows came home? : ", true);

                if (String.Compare(input, "R", true) == 0)
                    return "Ranchhand";
                else if (String.Compare(input, "C", true) == 0)
                    return "Cookie";
                else if (String.Compare(input, "S", true) == 0)
                    return "Swindler";
                else if (String.Compare(input, "T", true) == 0)
                    return "Traveler";
                else if (String.Compare(input, "O", true) == 0)
                    return "Outlaw";
                else
                    Console.WriteLine("Invalid Input");
            } while (true);
        }

        private static string DisplayHobbyMenu ()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("[C]ow Puncher");
            Console.WriteLine("[B]eanslinger");
            Console.WriteLine("[S]nakeoiler");
            Console.WriteLine("[W]anderer");
            Console.WriteLine("[D]eprived");
            Console.WriteLine("---------------------");

            do
            {
                string input = ReadString("What kinda cowboy you wanna be? : ", true);

                if (String.Compare(input, "C", true) == 0)
                    return "Cow Puncher";
                else if (String.Compare(input, "B", true) == 0)
                    return "Beanslinger";
                else if (String.Compare(input, "S", true) == 0)
                    return "Snakeoiler";
                else if (String.Compare(input, "W", true) == 0)
                    return "Wanderer";
                else if (String.Compare(input, "D", true) == 0)
                    return "Deprived";
                else
                    Console.WriteLine("Invalid Input");
            } while (true);
        }

        static string name;
        static string hobby;
        static string profession;

        static int statGrit;
        static int statMuscle;
        static int statMysticallity;
        static int statMoxie;
        static int statGumption;

        static string backstory;

        private static char DisplayMenu ()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Legends of The West");
            Console.WriteLine("---------------------");
            Console.WriteLine("[C]reate Character");
            Console.WriteLine("[V]iew Character");
            Console.WriteLine("[E]dit Character");
            Console.WriteLine("[D]elete Character");
            Console.WriteLine("[Q]uit");
            Console.WriteLine("---------------------");

            do
            {
                string input = ReadString("Please select an option: ", true);

                if (String.Compare(input, "C", true) == 0)
                    return 'C';
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

        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine(message);
            do
            {
                string input = Console.ReadLine();
                if (!required || !String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Value is required.");
            } while (true);
        }
    }
}
