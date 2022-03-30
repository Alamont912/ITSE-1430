using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase
    {
        public string Add ( Movie movie )
        {
            //TODO: Validate

            if (movie == null)
                return "Movie cannot be null";

            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return "Movie is invalid";

            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique";

            _movies.Add(movie);
            return "";
        }

        private Movie FindByName ( string name )
        {
            //1. loop variant is readonly
            //2. array cannot change
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
                    return movie;

            return null;
        }

        //virtual only applies to inheritance.
        //provides a default implementation, but
        //derived types can alter it.
        public void Delete ( Movie movie )
        {

        }

        public void Update ( Movie movie )
        {

        }

        public Movie[] GetAll()
        {
            //TODO: broken
            return _movies.ToArray();
        }

        public Movie Get ()
        {
            return null;
        }

        private readonly List<Movie> _movies = new List<Movie>();
    }
}
