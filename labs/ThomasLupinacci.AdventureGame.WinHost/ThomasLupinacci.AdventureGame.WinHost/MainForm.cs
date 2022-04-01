using System;
using System.Windows.Forms;

namespace ThomasLupinacci.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private int ReadAsInt32 ( Control control, int defaultValue )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return defaultValue;
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

        private void OnCharacterAdd ( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //Save movie from CharacterForm
                _character = dlg.Character;
                UpdateUI();
                return;

            } while (true);
        }

        private void UpdateUI()
        {
            _lstboxCharacterList.Items.Clear();

            if(_character != null)
                _lstboxCharacterList.Items.Add(_character);
        }

        private Character GetSelectedCharacter()
        {
            return _lstboxCharacterList.SelectedItem as Character;
        }

        private Character _character;

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var menuItem = sender as ToolStripMenuItem;

            var selectedCharacter = GetSelectedCharacter();
            if (selectedCharacter == null)
                return;

            var dlg = new CharacterForm();
            dlg.Character = selectedCharacter;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            //Save
            _character = dlg.Character;
            UpdateUI();
        }

        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            //Get selected character
            var selectedCharacter = GetSelectedCharacter();
            if (selectedCharacter == null)
                return;

            //Confirm deletion
            if (MessageBox.Show(this, $"Are you sure you wanna delete {selectedCharacter.Name}?",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //Delete
            _character = null;
            UpdateUI();
        }
    }
}