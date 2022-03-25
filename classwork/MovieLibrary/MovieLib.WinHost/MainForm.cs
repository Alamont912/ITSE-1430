using System;
using System.Windows.Forms;

namespace MovieLib.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            //Save movie
            _movie = dlg.Movie;
            UpdateUI();
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();
            if(_movie != null)
                _lstMovies.Items.Add(_movie);
        }

        private Movie _movie;

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

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            //Save movie
            _movie = dlg.Movie;
            UpdateUI();
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
            _movie = null;
            UpdateUI();
        }

        private Movie GetSelectedMovie()
        {
            return _lstMovies.SelectedItem as Movie;
        }
    }
}
