﻿using System;

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
        //automatically initializes to 0 or to an entered value. Do not make public.

        public const int MinimumReleaseYear = 1900;     //const mean 'read-only'.
        public readonly DateTime MinimumReleasedDate = new DateTime(1900, 1, 1);    //readonly for a value that will be set once and then never change its value.
        //Use Properties to expose data.

        /// <summary>Gets or sets the title of the movie instance.</summary>
        public string Title
        {
            //get { return !String.IsNullOrEmpty(_title) ? _title : ""; }     //getter
            //get { return (_title != null) ? _title : " "; }
            get { return _title ?? ""; }    //null coalescing 
            set { _title = (value != null) ? value.Trim() : null; }     //setter
        }
        private string _title;

        /// <summary>Gets or sets duration in minutes.</summary>
        public int Duration { get; set; }   //auto-makes. field not needed.
                                            //private int _duration;               //Hungarian notation identifies

        /// <summary>Gets or sets release year of movie..</summary>
        public int ReleaseYear { get; set; } = 1900;    //auto-property field-initializer!
        //private int _releaseYear = 1900;     //fields vs. variables

        /// <summary>Gets or sets rating of movie.</summary>
        public string Rating
        {
            get { return !String.IsNullOrEmpty(_rating) ? _rating : ""; }
            set { _rating = value; }
        }
        private string _rating;           //time for prawn!

        /// <summary>Gets or sets genre of movie.</summary>
        public string Genre
        {
            get { return !String.IsNullOrEmpty(_genre) ? _genre : ""; }
            set { _genre = value; }
        }
        private string _genre;

        /// <summary>Gets or sets the classical status of movie.</summary>
        public bool IsClassic { get; set; }
        //private bool _isClassic;

        /// <summary>Gets or sets the description of movie.</summary>
        public string Description
        {
            get { return !String.IsNullOrEmpty(_description) ? _description : ""; }
            set { _description = value; }
        }
        private string _description;

        //Calculated Property := BW <= 1939         constantly updated and calculated, not stored
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < 1939; }  //getter is optional.
            // the setter is optional. You must have at least one of these.
        }

        //private bool _isBlackAndWhite;

        /// <summary>
        /// Determines if the movie instance is in color or not depending on its release year.</summary>
        //private void CalculateBlackAndWhite()
        //{
        //    _isBlackAndWhite = (ReleaseYear <= 1939);
        //}

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

            if (Duration < 0)
                return "Duration must be at least 0.";

            if (ReleaseYear < MinimumReleaseYear)
                return $"Release year must be at least {MinimumReleaseYear}.";

            if (String.IsNullOrEmpty(Rating))
                return "Rating is required.";

            //Special rule - no classics before 1940
            if (IsClassic && ReleaseYear < 1940)
                return "Release year must be at least 1940 to be a classic.";

            return "";  //returns an empty string if valid.
        }
        public int Id { get; private set; } //auto-property with mixed-access.
        //{
        //    get { return _id; }     //can optionally have an access mod, only one can have one,
        //    private set { _id = value; }    //must be more restrictive than property access mod
        //}
        //private int _id;
    }
}