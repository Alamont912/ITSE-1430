using System;

using MovieLib.Memory;

namespace MovieLib
{
    /// <summary>
    /// Seeds a movie database
    /// </summary>
    public class SeedDatabase
    {
        public void Seed (IMovieDatabase database)
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
