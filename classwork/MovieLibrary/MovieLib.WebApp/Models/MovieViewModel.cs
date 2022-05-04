using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLib.WebApp.Models
{
    //Class - Wraps data and functionality, pascal-cased nouns
    //default access: internal for a class, private for a class member

    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class MovieViewModel //: IValidatableObject
    {
        public MovieViewModel()
        { }

        public MovieViewModel (Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;

            Duration = movie.Duration;
            ReleaseYear = movie.ReleaseYear;

            Rating = movie.Rating;
            Genre = movie.Genre;
            Description = movie.Description;

            IsClassic = movie.IsClassic;
        }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        /// <summary>Gets or sets duration in minutes.</summary>
        /// 
        [RangeAttribute(0, Int32.MaxValue)]
        public int Duration { get; set; }   //auto-makes. field not needed.
                                            //private int _duration;               //Hungarian notation identifies

        /// <summary>Gets or sets release year of movie..</summary>
        /// 
        [RangeAttribute(Movie.MinimumReleaseYear, 2100)]
        public int ReleaseYear { get; set; } = Movie.MinimumReleaseYear;    //auto-property field-initializer!
        //private int _releaseYear = 1900;     //fields vs. variables

        /// <summary>Gets or sets rating of movie.</summary>
        /// 
        [Required(AllowEmptyStrings = false)]
        public string Rating { get; set; }

        /// <summary>Gets or sets genre of movie.</summary>
        /// 
        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        /// <summary>Gets or sets the classical status of movie.</summary>
        public bool IsClassic { get; set; }
        //private bool _isClassic;

        /// <summary>Gets or sets the description of movie.</summary>
        public string Description { get; set; }

        public int Id { get; set; } //auto-property with mixed-access.
    }
}
