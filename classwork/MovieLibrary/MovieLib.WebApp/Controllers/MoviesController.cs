using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MovieLib.WebApp.Models;

namespace MovieLib.WebApp.Controllers
{
    public class MoviesController : Controller                  //<url>/controller/action
    {                                                           //<url>/class/method
        public MoviesController( IMovieDatabase database)       //Must be global, derive from 'Controller',
        {                                                       //public, and creatable for runtime to use
            _database = database;                               //A new Controller is made for each request,
                                                                //so fields cannot be stored
        }

        //Actions
        //Must be a public method that must return IActionResult(or derived type)
        [HttpGet]   //can only be called if this is a Get request
        public IActionResult Index ()
        {
            var movies = _database.GetAll();
            var models = movies.Select(x => new MovieViewModel(x));

            return View(models);  //"Index.cshtml"
            //return View("List.cshtml", models);
        }

        [HttpGet]
        public IActionResult Details ( int id )
        {
            var movie = _database.Get(id);

            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);

            return View(model);
        }

        // movies/edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _database.Get(id);

            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var newMovie = model.ToMovie();

                _database.Update(model.Id, newMovie);

                return RedirectToAction("Index");
            }catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create ()
        {
            var model = new MovieViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create ( MovieViewModel model )
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var newMovie = model.ToMovie();

                _database.Add(newMovie);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete ( int id )
        {
            var movie = _database.Get(id);

            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete ( MovieViewModel model )
        {
            try
            {
                _database.Delete(model.Id);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        private readonly IMovieDatabase _database;
    }
}
