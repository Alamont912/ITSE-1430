using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie )
        {
            //Add
            movie.Id = _id++;
            _movies.Add(movie.Copy());
            return movie;
        }

        protected override Movie FindByName ( string name )
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
        protected override void DeleteCore ( int id )
        {
            //Find by movie.Id
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
                _movies.Remove(movie);
            //foreach (var item in _movies)
            //{
            //    if (item.Id == id)
            //    {
            //        _movies.Remove(item);
            //        return;
            //    }
            //}
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            var existing = FindById(id);

            existing.CopyFrom(movie);
        }

        //Iterators - implementation of IEnumerable<T>


        /// <summary>
        /// Gets all of the movies as an array.
        /// </summary>
        /// <returns>The movies in the database.</returns>
        protected override IEnumerable<Movie> GetAllCore ()  //Interfaces (contracts) start with "I"
        {
            //Need to clone movies so changes outside of database do not impact original

            //return _movies.ToArray();

            //foreach (var movie in _movies)      //makes a true copy array from a list of movies.
            //{
            //    //System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
            //    //items[index++] = movie.Copy();
            //    yield return movie.Copy();
            //};

            //return items;

            return _movies.Select(x => x.Copy());
        }

        /// <summary>
        /// Gets a movie.
        /// </summary>
        /// <param name="id">The ID of the movie to get.</param>
        /// <returns>The movie, if found.</returns>
        protected override Movie GetCore ( int id )
        {
            //var movie = FindById(id);

            //return movie?.Copy();   //might not find it, so null conditional

            return FindById(id)?.Copy();
        }

        private Movie FindById ( int id )
        {
            //LINQ:
            //   What :: Data desired  entire movie
            //   Where:: IEnumerable<T> _movies
            //   When :: Condition ids match

            //Approach 1
            //IEnumerable<Movie> matches = _movies.Where(IsMatchingId);
            //var match = matches.FirstOrDefault();

            //Approach 2
            //var movie = _movies.Where(IsMatchingId)
            //   (Movie item) => item.Id == id
            //var movie = _movies.Where(item => item.Id == id)
            //                   .FirstOrDefault();
            //return movie;

            //Approach 3
            return _movies.FirstOrDefault(x => x.Id == id);

            //Approach 4
            //foreach (var item in _movies)
            //{
            //    if (item.Id == id)
            //        return item;
            //};

            //return null;
        }

        private readonly List<Movie> _movies = new List<Movie>();

        //Simple identifier system
        private int _id = 1;
    }
}
