using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public string Add ( Movie movie )
        {
            //TODO: Validate

            if (movie == null)
                return "Movie cannot be null";

            if (!ObjectValidator.TryValidateObject(movie, out var errors))
                return "Movie is invalid";  //fix validation message
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid";

            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique";

            //Add
            var newMovie = AddCore(movie);
            movie.Id = newMovie.Id;
            return "";
        }
        //virtual - you may implement/override
        protected abstract Movie AddCore ( Movie movie );   //abstract - derived types MUST implement
                                                            //abstracts cannot have a base definition
        protected abstract Movie FindByName ( string name );

        //virtual only applies to inheritance.
        //provides a default implementation, but
        //derived types can alter it.
        public string Delete ( int id )
        {
            if (id <= 0)
                return "ID must be > 0";

            DeleteCore(id);
            return "";
        }

        protected abstract void DeleteCore ( int id );

        public string Update ( int id, Movie movie )
        {
            if (id <= 0)
                return "Id must be >= 0";

            if (movie == null)
                return "Movie cannot be null";

            if (!ObjectValidator.TryValidateObject(movie, out var errors))
                return "Movie is invalid";  //fix validation message
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                return "Movie must be unique";

            existing = GetCore(id);
            if (existing == null)
                return "Movie does not exist";

            //Update
            UpdateCore(id, movie);
            return "";
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        //Iterators - implementation of IEnumerable<T>


        /// <summary>
        /// Gets all of the movies as an array.
        /// </summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll ()  //Interfaces (contracts) start with "I"
        {
            //TODO: handle null
            return GetAllCore();
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        /// <summary>
        /// Gets a movie.
        /// </summary>
        /// <param name="id">The ID of the movie to get.</param>
        /// <returns>The movie, if found.</returns>
        public Movie Get ( int id )
        {
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );
    }
}
