using System;

using MovieLib.Memory;

namespace MovieLib
{
    //Static classes contain only static members
    //Static members do not require an instance
    //Static members must be called using type name
    //Static members can only refer to other static members

    //Extension Methods
    // In a static public/internal class
    // Must be a static method
    // First parameter must be preceded by 'this'
    /// <summary>
    /// Seeds a movie database
    /// </summary>
    public static class SeedDatabase
    {
        public static void Seed (this IMovieDatabase database)
        {
            database.Add(new Movie() {
                Title = "Jaws",
                Genre = "Horror",
                ReleaseYear = 1977,
                Duration = 124,
                Rating = "PG",
                IsClassic = true
            });

            database.Add(new Movie() {
                Title = "Shrek",
                Genre = "Comedy",
                ReleaseYear = 2001,
                Duration = 90,
                Rating = "PG",
                IsClassic = false
            });
        }
    }

}
