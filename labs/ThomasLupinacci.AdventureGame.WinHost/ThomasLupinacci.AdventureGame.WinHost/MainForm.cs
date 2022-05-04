/*
 * Written by Thomas J. Lupinacci III for TCCD ITSE-1430 on 3/31/2022
 * Lab #3
 */

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

        ICharacterRoster _roster = new Memory.MemoryCharacterRoster();

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

                //Save character from CharacterForm to roster
                _roster.Add(dlg.Character);
                UpdateUI();
                return;

            } while (true);
        }

        private void UpdateUI()
        {
            //_lstboxCharacterList.Items.Clear();

            if(_roster != null)
            {
                var binding = new BindingSource();
                binding.DataSource = _roster.GetAll();

                _lstboxCharacterList.DataSource = binding;
                _lstboxCharacterList.DisplayMember = nameof(Character.Name);
            }
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
            _roster.Update(selectedCharacter.Id, dlg.Character);
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