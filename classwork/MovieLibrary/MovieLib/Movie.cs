using System;

namespace MovieLib
{
    //Class - Wraps data and functionality, pascal-cased nouns
    //default access: internal for a class, private for a class member

    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class Movie
    {
        //Fields - Where the data is stored - looks just like a local variable by design!
        //automatically initializes to 0 or to an entered value.
        public string title;
        public int duration;
        public int releaseYear = 1900;
        public string rating;           //time for crab
        public string genre;
        public bool isColor;
        public string description;

        private int id;
    }
}
