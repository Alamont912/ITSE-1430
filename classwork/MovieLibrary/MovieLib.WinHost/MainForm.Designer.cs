﻿
namespace MovieLib.WinHost
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.characterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miCharacterAdd = new System.Windows.Forms.ToolStripMenuItem();
            this._miCharacterEdit = new System.Windows.Forms.ToolStripMenuItem();
            this._miCharacterDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._lstMovies = new System.Windows.Forms.ListBox();
            this._mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.characterToolStripMenuItem,
            this.helpToolStripMenuItem});
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this._mainMenu.Size = new System.Drawing.Size(896, 30);
            this._mainMenu.TabIndex = 0;
            this._mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // _miFileExit
            // 
            this._miFileExit.Name = "_miFileExit";
            this._miFileExit.Size = new System.Drawing.Size(116, 26);
            this._miFileExit.Text = "E&xit";
            this._miFileExit.Click += new System.EventHandler(this.OnFileExit);
            // 
            // characterToolStripMenuItem
            // 
            this.characterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miCharacterAdd,
            this._miCharacterEdit,
            this._miCharacterDelete});
            this.characterToolStripMenuItem.Name = "characterToolStripMenuItem";
            this.characterToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.characterToolStripMenuItem.Text = "&Movie";
            // 
            // _miCharacterAdd
            // 
            this._miCharacterAdd.Name = "_miCharacterAdd";
            this._miCharacterAdd.Size = new System.Drawing.Size(224, 26);
            this._miCharacterAdd.Text = "&Add";
            this._miCharacterAdd.Click += new System.EventHandler(this.OnMovieAdd);
            // 
            // _miCharacterEdit
            // 
            this._miCharacterEdit.Name = "_miCharacterEdit";
            this._miCharacterEdit.Size = new System.Drawing.Size(224, 26);
            this._miCharacterEdit.Text = "&Edit";
            this._miCharacterEdit.Click += new System.EventHandler(this.OnMovieEdit);
            // 
            // _miCharacterDelete
            // 
            this._miCharacterDelete.Name = "_miCharacterDelete";
            this._miCharacterDelete.Size = new System.Drawing.Size(224, 26);
            this._miCharacterDelete.Text = "&Delete";
            this._miCharacterDelete.Click += new System.EventHandler(this.OnMovieDelete);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // _miHelpAbout
            // 
            this._miHelpAbout.Name = "_miHelpAbout";
            this._miHelpAbout.Size = new System.Drawing.Size(133, 26);
            this._miHelpAbout.Text = "&About";
            this._miHelpAbout.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // _lstMovies
            // 
            this._lstMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lstMovies.FormattingEnabled = true;
            this._lstMovies.ItemHeight = 20;
            this._lstMovies.Location = new System.Drawing.Point(0, 30);
            this._lstMovies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._lstMovies.Name = "_lstMovies";
            this._lstMovies.Size = new System.Drawing.Size(896, 718);
            this._lstMovies.TabIndex = 1;
            this._lstMovies.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 748);
            this.Controls.Add(this._lstMovies);
            this.Controls.Add(this._mainMenu);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuStrip = this._mainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(912, 784);
            this.Name = "MainForm";
            this.Text = "Form1";
            this._mainMenu.ResumeLayout(false);
            this._mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _miFileExit;
        private System.Windows.Forms.ToolStripMenuItem characterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _miCharacterAdd;
        private System.Windows.Forms.ToolStripMenuItem _miCharacterEdit;
        private System.Windows.Forms.ToolStripMenuItem _miCharacterDelete;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
        private System.Windows.Forms.ListBox _lstMovies;
    }
}

