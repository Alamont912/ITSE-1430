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

        private void OnValidateName ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(_txtboxName, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateHobby ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(_cmbboxHobby, "Hobby is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateProfession ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(_cmbboxProfession, "Profession is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateStatGrit ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < 1 || value > 100)
            {
                _errors.SetError(control, "Your Grit must be between 1 and 100.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateStatMuscle ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < 1 || value > 100)
            {
                _errors.SetError(control, "Your Muscle must be between 1 and 100.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateStatMysticallity ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < 1 || value > 100)
            {
                _errors.SetError(control, "Your Mysticallity must be between 1 and 100.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateStatMoxie ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < 1 || value > 100)
            {
                _errors.SetError(control, "Your Moxie must be between 1 and 100.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateStatGumption ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < 1 || value > 100)
            {
                _errors.SetError(control, "Your Gumption must be between 1 and 100.");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
