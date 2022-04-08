﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using MovieLib.Memory;

namespace MovieLib.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Extension methods
        // Extends a type with a new method
        // Works with any type
        // 
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);


            IEnumerable<Movie> items = _movies.GetAll();
            if(!items.Any())
            {
                if(MessageBox.Show(this, "Do you want to seed the database?", "Seed",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Seed database
                    //SeedDatabase.Seed(_movies);
                    _movies.Seed();
                    UpdateUI();
                }
            }
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            //Confirm exit
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to quit?", "Quit",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
            {
                e.Cancel = true;
            };
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //Save movie
                var error = _movies.Add(dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    dlg.Movie.Title = "Stur Wurs";
                    UpdateUI();
                    return;
                }

                MessageBox.Show(this, error, "Add failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();

            var movies = _movies.GetAll();  //returns an array of _movies

            //BreakMovies(movies);

            foreach (var movie in movies)
                _lstMovies.Items.Add(movie);
        }

        //private void BreakMovies ( IOrderedEnumerable<Movie> movies )
        //{
        //    if(movies.Any())
        //    {
        //        var firstMovie = movies[0];
        //
        //        firstMovie.Title = "Stur Wurs";
        //    }
        //}

        private void listBox1_SelectedIndexChanged ( object sender, EventArgs e )
        {

        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var menuItem = sender as ToolStripMenuItem;

            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            //Update movie
            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _movies.Update(movie.Id, dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                }

                MessageBox.Show(this, error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirm delete
            if (MessageBox.Show(this, $"Are you sure you want to delete {movie.Title}?", "Delete",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //Delete
            _movies.Delete(movie.Id);
            UpdateUI();
        }

        private Movie GetSelectedMovie()
        {
            return _lstMovies.SelectedItem as Movie;
        }

        private Movie _movie;
        private readonly IMovieDatabase _movies = new MemoryMovieDatabase();

    }
}
