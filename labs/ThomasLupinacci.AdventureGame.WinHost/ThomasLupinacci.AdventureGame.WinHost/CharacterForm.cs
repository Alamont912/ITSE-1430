using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThomasLupinacci.AdventureGame.WinHost
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        private int ReadAsInt32 ( Control control, int defaultValue )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return defaultValue;
        }
        private void OnSave ( object sender, EventArgs e )
        {
            //Check all children for validation
            if (!ValidateChildren())
                return;

            //create new character object
            var character = new Character();

            //set properties from UI CharacterForm
            character.Name = _txtboxName.Text;
            character.Hobby = _cmbboxHobby.Text;
            character.Profession = _cmbboxProfession.Text;
            character.StatGrit = ReadAsInt32(_txtboxStatGrit, -1);
            character.StatMuscle = ReadAsInt32(_txtboxStatMuscle, -1);
            character.StatMysticallity = ReadAsInt32(_txtboxStatMysticallity, -1);
            character.StatMoxie = ReadAsInt32(_txtboxStatMoxie, -1);
            character.StatGumption = ReadAsInt32(_txtboxStatGumption, -1);
            character.Backstory = _txtboxDescription.Text;

            //Validate
            var error = character.Validate();
            if(String.IsNullOrEmpty(error))
            {
                //Valid, so close
                Character = character;  //save new character to be used
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            //Display Error
            MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //Load UI
            if (Character != null)
            {
                _txtboxName.Text = Character.Name;
                _cmbboxHobby.Text = Character.Hobby;
                _cmbboxProfession.Text = Character.Profession;
                _txtboxStatGrit.Text = Character.StatGrit.ToString();
                _txtboxStatMuscle.Text = Character.StatMuscle.ToString();
                _txtboxStatMysticallity.Text = Character.StatMysticallity.ToString();
                _txtboxStatMoxie.Text = Character.StatMoxie.ToString();
                _txtboxStatGumption.Text = Character.StatGumption.ToString();
                _txtboxDescription.Text = Character.Backstory;
            }
        }
    }
}
