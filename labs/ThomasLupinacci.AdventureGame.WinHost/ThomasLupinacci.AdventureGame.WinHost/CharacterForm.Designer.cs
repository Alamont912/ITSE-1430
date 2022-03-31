namespace ThomasLupinacci.AdventureGame.WinHost
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this._txtboxName = new System.Windows.Forms.TextBox();
            this._txtboxStatGrit = new System.Windows.Forms.TextBox();
            this._txtboxStatMuscle = new System.Windows.Forms.TextBox();
            this._txtboxStatMysticallity = new System.Windows.Forms.TextBox();
            this._txtboxStatMoxie = new System.Windows.Forms.TextBox();
            this._txtboxStatGumption = new System.Windows.Forms.TextBox();
            this._cmbboxHobby = new System.Windows.Forms.ComboBox();
            this._cmbboxProfession = new System.Windows.Forms.ComboBox();
            this._txtboxDescription = new System.Windows.Forms.TextBox();
            this._lblName = new System.Windows.Forms.Label();
            this._lblHobby = new System.Windows.Forms.Label();
            this._lblProfession = new System.Windows.Forms.Label();
            this._lblStatGrit = new System.Windows.Forms.Label();
            this._lblStatMuscle = new System.Windows.Forms.Label();
            this._lblStatMysticallity = new System.Windows.Forms.Label();
            this._lblStatMoxie = new System.Windows.Forms.Label();
            this._lblStatGumption = new System.Windows.Forms.Label();
            this._lblStats = new System.Windows.Forms.Label();
            this._lblBackstory = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtboxName
            // 
            this._txtboxName.Location = new System.Drawing.Point(109, 47);
            this._txtboxName.Name = "_txtboxName";
            this._txtboxName.Size = new System.Drawing.Size(125, 27);
            this._txtboxName.TabIndex = 0;
            // 
            // _txtboxStatGrit
            // 
            this._txtboxStatGrit.Location = new System.Drawing.Point(109, 272);
            this._txtboxStatGrit.Name = "_txtboxStatGrit";
            this._txtboxStatGrit.Size = new System.Drawing.Size(125, 27);
            this._txtboxStatGrit.TabIndex = 3;
            this._txtboxStatGrit.Text = "50";
            // 
            // _txtboxStatMuscle
            // 
            this._txtboxStatMuscle.Location = new System.Drawing.Point(109, 322);
            this._txtboxStatMuscle.Name = "_txtboxStatMuscle";
            this._txtboxStatMuscle.Size = new System.Drawing.Size(125, 27);
            this._txtboxStatMuscle.TabIndex = 4;
            this._txtboxStatMuscle.Text = "50";
            // 
            // _txtboxStatMysticallity
            // 
            this._txtboxStatMysticallity.Location = new System.Drawing.Point(109, 372);
            this._txtboxStatMysticallity.Name = "_txtboxStatMysticallity";
            this._txtboxStatMysticallity.Size = new System.Drawing.Size(125, 27);
            this._txtboxStatMysticallity.TabIndex = 5;
            this._txtboxStatMysticallity.Text = "50";
            // 
            // _txtboxStatMoxie
            // 
            this._txtboxStatMoxie.Location = new System.Drawing.Point(109, 422);
            this._txtboxStatMoxie.Name = "_txtboxStatMoxie";
            this._txtboxStatMoxie.Size = new System.Drawing.Size(125, 27);
            this._txtboxStatMoxie.TabIndex = 6;
            this._txtboxStatMoxie.Text = "50";
            // 
            // _txtboxStatGumption
            // 
            this._txtboxStatGumption.Location = new System.Drawing.Point(109, 472);
            this._txtboxStatGumption.Name = "_txtboxStatGumption";
            this._txtboxStatGumption.Size = new System.Drawing.Size(125, 27);
            this._txtboxStatGumption.TabIndex = 7;
            this._txtboxStatGumption.Text = "50";
            // 
            // _cmbboxHobby
            // 
            this._cmbboxHobby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbboxHobby.FormattingEnabled = true;
            this._cmbboxHobby.Items.AddRange(new object[] {
            "Cow Punchin\'",
            "Beanslingin\'",
            "Snakeoilin\'",
            "Wanderin\'",
            "Deprivin\'"});
            this._cmbboxHobby.Location = new System.Drawing.Point(109, 96);
            this._cmbboxHobby.Name = "_cmbboxHobby";
            this._cmbboxHobby.Size = new System.Drawing.Size(151, 28);
            this._cmbboxHobby.TabIndex = 1;
            // 
            // _cmbboxProfession
            // 
            this._cmbboxProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbboxProfession.FormattingEnabled = true;
            this._cmbboxProfession.Items.AddRange(new object[] {
            "Ranchhand",
            "Cookie",
            "Swindler",
            "Traveler",
            "Outlaw"});
            this._cmbboxProfession.Location = new System.Drawing.Point(109, 147);
            this._cmbboxProfession.Name = "_cmbboxProfession";
            this._cmbboxProfession.Size = new System.Drawing.Size(151, 28);
            this._cmbboxProfession.TabIndex = 2;
            // 
            // _txtboxDescription
            // 
            this._txtboxDescription.Location = new System.Drawing.Point(334, 83);
            this._txtboxDescription.Multiline = true;
            this._txtboxDescription.Name = "_txtboxDescription";
            this._txtboxDescription.Size = new System.Drawing.Size(218, 317);
            this._txtboxDescription.TabIndex = 8;
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(12, 50);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(49, 20);
            this._lblName.TabIndex = 9;
            this._lblName.Text = "Name";
            // 
            // _lblHobby
            // 
            this._lblHobby.AutoSize = true;
            this._lblHobby.Location = new System.Drawing.Point(12, 99);
            this._lblHobby.Name = "_lblHobby";
            this._lblHobby.Size = new System.Drawing.Size(54, 20);
            this._lblHobby.TabIndex = 10;
            this._lblHobby.Text = "Hobby";
            // 
            // _lblProfession
            // 
            this._lblProfession.AutoSize = true;
            this._lblProfession.Location = new System.Drawing.Point(12, 150);
            this._lblProfession.Name = "_lblProfession";
            this._lblProfession.Size = new System.Drawing.Size(77, 20);
            this._lblProfession.TabIndex = 11;
            this._lblProfession.Text = "Profession";
            // 
            // _lblStatGrit
            // 
            this._lblStatGrit.AutoSize = true;
            this._lblStatGrit.Location = new System.Drawing.Point(12, 275);
            this._lblStatGrit.Name = "_lblStatGrit";
            this._lblStatGrit.Size = new System.Drawing.Size(33, 20);
            this._lblStatGrit.TabIndex = 12;
            this._lblStatGrit.Text = "Grit";
            // 
            // _lblStatMuscle
            // 
            this._lblStatMuscle.AutoSize = true;
            this._lblStatMuscle.Location = new System.Drawing.Point(12, 325);
            this._lblStatMuscle.Name = "_lblStatMuscle";
            this._lblStatMuscle.Size = new System.Drawing.Size(55, 20);
            this._lblStatMuscle.TabIndex = 13;
            this._lblStatMuscle.Text = "Muscle";
            // 
            // _lblStatMysticallity
            // 
            this._lblStatMysticallity.AutoSize = true;
            this._lblStatMysticallity.Location = new System.Drawing.Point(12, 375);
            this._lblStatMysticallity.Name = "_lblStatMysticallity";
            this._lblStatMysticallity.Size = new System.Drawing.Size(83, 20);
            this._lblStatMysticallity.TabIndex = 14;
            this._lblStatMysticallity.Text = "Mysticallity";
            // 
            // _lblStatMoxie
            // 
            this._lblStatMoxie.AutoSize = true;
            this._lblStatMoxie.Location = new System.Drawing.Point(12, 425);
            this._lblStatMoxie.Name = "_lblStatMoxie";
            this._lblStatMoxie.Size = new System.Drawing.Size(50, 20);
            this._lblStatMoxie.TabIndex = 15;
            this._lblStatMoxie.Text = "Moxie";
            // 
            // _lblStatGumption
            // 
            this._lblStatGumption.AutoSize = true;
            this._lblStatGumption.Location = new System.Drawing.Point(12, 475);
            this._lblStatGumption.Name = "_lblStatGumption";
            this._lblStatGumption.Size = new System.Drawing.Size(75, 20);
            this._lblStatGumption.TabIndex = 16;
            this._lblStatGumption.Text = "Gumption";
            // 
            // _lblStats
            // 
            this._lblStats.AutoSize = true;
            this._lblStats.Location = new System.Drawing.Point(12, 239);
            this._lblStats.Name = "_lblStats";
            this._lblStats.Size = new System.Drawing.Size(41, 20);
            this._lblStats.TabIndex = 17;
            this._lblStats.Text = "Stats";
            // 
            // _lblBackstory
            // 
            this._lblBackstory.AutoSize = true;
            this._lblBackstory.Location = new System.Drawing.Point(334, 50);
            this._lblBackstory.Name = "_lblBackstory";
            this._lblBackstory.Size = new System.Drawing.Size(72, 20);
            this._lblBackstory.TabIndex = 18;
            this._lblBackstory.Text = "Backstory";
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(334, 466);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(94, 29);
            this._btnSave.TabIndex = 19;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(458, 466);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(94, 29);
            this._btnCancel.TabIndex = 20;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._lblBackstory);
            this.Controls.Add(this._lblStats);
            this.Controls.Add(this._lblStatGumption);
            this.Controls.Add(this._lblStatMoxie);
            this.Controls.Add(this._lblStatMysticallity);
            this.Controls.Add(this._lblStatMuscle);
            this.Controls.Add(this._lblStatGrit);
            this.Controls.Add(this._lblProfession);
            this.Controls.Add(this._lblHobby);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._txtboxDescription);
            this.Controls.Add(this._cmbboxProfession);
            this.Controls.Add(this._cmbboxHobby);
            this.Controls.Add(this._txtboxStatGumption);
            this.Controls.Add(this._txtboxStatMoxie);
            this.Controls.Add(this._txtboxStatMysticallity);
            this.Controls.Add(this._txtboxStatMuscle);
            this.Controls.Add(this._txtboxStatGrit);
            this.Controls.Add(this._txtboxName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "CharacterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox _txtboxName;
        private TextBox _txtboxStatGrit;
        private TextBox _txtboxStatMuscle;
        private TextBox _txtboxStatMysticallity;
        private TextBox _txtboxStatMoxie;
        private TextBox _txtboxStatGumption;
        private ComboBox _cmbboxHobby;
        private ComboBox _cmbboxProfession;
        private TextBox _txtboxDescription;
        private Label _lblName;
        private Label _lblHobby;
        private Label _lblProfession;
        private Label _lblStatGrit;
        private Label _lblStatMuscle;
        private Label _lblStatMysticallity;
        private Label _lblStatMoxie;
        private Label _lblStatGumption;
        private Label _lblStats;
        private Label _lblBackstory;
        private Button _btnSave;
        private Button _btnCancel;
    }
}