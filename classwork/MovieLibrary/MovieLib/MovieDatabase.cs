using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public abstract class MovieDatabase : IMovieDatabase
    {
        public Movie Add ( Movie movie )
        {
            //Raise an error using 'throw'. throw-statement ::= throw E(exception)
            //TODO: Validate

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            movie = movie ?? throw new ArgumentNullException(nameof(movie));
                //return "Movie cannot be null";

            var error = new InvalidOperationException();

            //Throw ValidationException if anything wrong 
            ObjectValidator.ValidateObject(movie);
            //if (!ObjectValidator.TryValidateObject(movie, out var errors))
            //    return "Movie is invalid";  //fix validation message
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid";

            var existing = FindByName(movie.Title);
            if (existing != null)
                //return "Movie must be unique";
                throw new InvalidOperationException("Movie must be unique");
            //throw new ArgumentException("Movie must be unique", nameof(movie));

            //Add
            try
            {
                var newMovie = AddCore(movie);
                return newMovie;
            } catch (InvalidOperationException ex){
                //pass through
                //NEVER DO THIS -> throw ex;
                throw;
            } catch( Exception ex)
            {
                //Wrap in a generic exception
                throw new Exception("Error adding movie", ex);
            }
            //movie.Id = newMovie.Id;
            //return "";
        }
        //virtual - you may implement/override
        protected abstract Movie AddCore ( Movie movie );   //abstract - derived types MUST implement
                                                            //abstracts cannot have a base definition
        protected abstract Movie FindByName ( string name );

        //virtual only applies to inheritance.
        //provides a default implementation, but
        //derived types can alter it.
        public void Delete ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");
                //return "ID must be > 0";

            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public void Update ( int id, Movie movie )
        {
            //if (id <= 0)
            //    return "Id must be >= 0";
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

            if (movie == null)
                //return "Movie cannot be null";
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.ValidateObject(movie);
            //if (!ObjectValidator.TryValidateObject(movie, out var errors))
            //    return "Movie is invalid";  //fix validation message
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                //return "Movie must be unique";
                throw new ArgumentException("Movie must be unique", nameof(movie));

            existing = GetCore(id);
            if (existing == null)
                //return "Movie does not exist";
                throw new ArgumentException("Movie does not exist", nameof(movie));

            //Update
            UpdateCore(id, movie);
            //return "";
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        //Iterators - implementation of IEnumerable<T>


        /// <summary>
        /// Gets all of the movies as an array.
        /// </summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll () => GetAllCore(); //Interfaces (contracts) start with "I"

        protected abstract IEnumerable<Movie> GetAllCore ();

        /// <summary>
        /// Gets a movie.
        /// </summary>
        /// <param name="id">The ID of the movie to get.</param>
        /// <returns>The movie, if found.</returns>
        public Movie Get ( int id )
        {
            //if (id <= 0)
            //    return null;
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );
    }
}
