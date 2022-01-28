﻿/*
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

            char input = DisplayMenu();

            //TODO: Handle input
            if (input == 'A')
                AddMovie();
        }

        private static void AddMovie()
        {
            string title = ReadString("Enter a movie title: ", true);
            int duration = ReadInt32("Enter duration in minutes (>= 0): ", 0);
            int releaseYear = ReadInt32("Enter the release year: ", 1900);
            string rating = ReadString("Enter a rating (e.g. PG, PG-13): ", true);
            string genre = ReadString("Enter a genre (optional): ", false);
            bool isColor;
            string description = ReadString("Enter a description (optional): ", false);
        }

        private static int ReadInt32(string message, int minimumValue)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            //TODO: Validate input
            int result = Int32.Parse(input);    //string to int, Double.Parse(), Int64.Parse()
            if (result >= minimumValue)
                return result;

            return -1;
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
