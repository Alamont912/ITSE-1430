using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {
        //not visible in interface
        public void Foo()
        {

        }

        public string Add ( Movie movie )
        {
            //TODO: Validate

            if (movie == null)
                return "Movie cannot be null";

            if (!new ObjectValidator().TryValidateObject(movie, out var errors))
                return "Movie is invalid";  //fix validation message
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid";

            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique";

            //Add
            movie.Id = _id++;
            _movies.Add(movie.Copy());
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
        public void Delete ( int id )
        {
            //Find by movie.Id
            foreach (var item in _movies)
            {
                if (item.Id == id)
                {
                    _movies.Remove(item);
                    return;
                }
            }
        }

        public string Update ( int id, Movie movie )
        {
            if (id <= 0)
                return "Id must be >= 0";

            if (movie == null)
                return "Movie cannot be null";

            if (!new ObjectValidator().TryValidateObject(movie, out var errors))
                return "Movie is invalid";  //fix validation message
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                return "Movie must be unique";

            existing = FindById(id);
            if (existing == null)
                return "Movie does not exist";

            //Update
            existing.CopyFrom(movie);
            return "";
        }

        //Iterators - implementation of IEnumerable<T>


        /// <summary>
        /// Gets all of the movies as an array.
        /// </summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll ()  //Interfaces (contracts) start with "I"
        {
            //Need to clone movies so changes outside of database do not impact original
            //return _movies.ToArray();
            foreach (var movie in _movies)      //makes a true copy array from a list of movies.
            {
                //System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
                //items[index++] = movie.Copy();
                yield return movie.Copy();
            };
            //return items;
        }

        /// <summary>
        /// Gets a movie.
        /// </summary>
        /// <param name="id">The ID of the movie to get.</param>
        /// <returns>The movie, if found.</returns>
        public Movie Get ( int id )
        {
            //var movie = FindById(id);

            //return movie?.Copy();   //might not find it, so null conditional

            return FindById(id)?.Copy();
        }

        private Movie FindById ( int id )
        {
            foreach (var item in _movies)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        private readonly List<Movie> _movies = new List<Movie>();

        //Simple identifier system
        private int _id = 1;
    }
}
