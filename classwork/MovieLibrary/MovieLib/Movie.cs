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

        /// <summary>Gets or sets the title of the movie instance.</summary>
        public string Title
        {
            get { return _title; }     //getter
            set { _title = value; }     //setter
        }

        private string _title;
        public int _duration;               //Hungarian notation identifies 
        public int _releaseYear = 1900;     //fields vs. variables
        public string _rating;           //time for crab
        public string _genre;
        public bool _isClassic;
        public string _description;

        //BW <= 1939
        public bool IsBlackAndWhite
        {
            get { return _isBlackAndWhite; }
            set { }
        }

        private bool _isBlackAndWhite;

        /// <summary>
        /// Determines if the movie instance is in color or not depending on its release year.</summary>
        public void CalculateBlackAndWhite()
        {
            isBlackAndWhite = (_releaseYear <= 1939);
        }

        //All instance methods have a hidden param that represents the instance
        /// <summary>
        /// Validates the movie instance/// </summary>
        /// <returns>Returns error message if any or empty string otherwise.</returns>
        public string Validate(/* Movie this */)
        {
            //var title = "";   LOCAL 'title', not the same as FIELD 'title'

            //Title is required
            if (String.IsNullOrEmpty(_title))
                return "Title is required.";

            if (_duration < 0)
                return "Duration must be at least 0.";

            if (_releaseYear < 1940)
                return "Release year must be at least 1940.";

            if (String.IsNullOrEmpty(_rating))
                return "Rating is required.";

            //Special rule - no classics before 1940
            if (_isClassic && _releaseYear < 1940)
                return "Release year must be at least 1940 to be a classic.";

            return "";  //returns an empty string if valid.
        }

        private int id;
    }
}
