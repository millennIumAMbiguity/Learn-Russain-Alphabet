namespace Learn_Russian_Alphabet
{
	partial class Form1
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
			if (disposing && (components != null)) { components.Dispose(); }

			base.Dispose(disposing);
		}

#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components                         = new System.ComponentModel.Container();
			this.label                              = new System.Windows.Forms.Label();
			this.contextMenu                        = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.difficultyToolStripMenuItem        = new System.Windows.Forms.ToolStripMenuItem();
			this.alphabetToolStripMenuItem          = new System.Windows.Forms.ToolStripMenuItem();
			this.alphabetSoundOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.translateWordToolStripMenuItem  = new System.Windows.Forms.ToolStripMenuItem();
			this.typeWordToolStripMenuItem          = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem          = new System.Windows.Forms.ToolStripMenuItem();
			this.autoPlayToolStripMenuItem          = new System.Windows.Forms.ToolStripMenuItem();
			this.readTypedLetterToolStripMenuItem   = new System.Windows.Forms.ToolStripMenuItem();
			this.inputLabel                         = new System.Windows.Forms.Label();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// label
			// 
			this.label.Dock       =  System.Windows.Forms.DockStyle.Fill;
			this.label.Font       =  new System.Drawing.Font("Bahnschrift Condensed", 120F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label.ForeColor  =  System.Drawing.SystemColors.Control;
			this.label.ImageAlign =  System.Drawing.ContentAlignment.TopLeft;
			this.label.Location   =  new System.Drawing.Point(0, 0);
			this.label.Name       =  "label";
			this.label.Padding    =  new System.Windows.Forms.Padding(0, 0, 0, 30);
			this.label.Size       =  new System.Drawing.Size(525, 225);
			this.label.TabIndex   =  1;
			this.label.Text       =  "Спасибо, не надо.";
			this.label.TextAlign  =  System.Drawing.ContentAlignment.MiddleCenter;
			this.label.Click      += new System.EventHandler(this.label_Click);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.difficultyToolStripMenuItem, this.settingsToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(137, 48);
			// 
			// difficultyToolStripMenuItem
			// 
			this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.alphabetToolStripMenuItem, this.alphabetSoundOnlyToolStripMenuItem, this.translateWordToolStripMenuItem, this.typeWordToolStripMenuItem});
			this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
			this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.difficultyToolStripMenuItem.Text = "Gamemode";
			// 
			// alphabetToolStripMenuItem
			// 
			this.alphabetToolStripMenuItem.Checked    =  true;
			this.alphabetToolStripMenuItem.CheckState =  System.Windows.Forms.CheckState.Checked;
			this.alphabetToolStripMenuItem.Name       =  "alphabetToolStripMenuItem";
			this.alphabetToolStripMenuItem.Size       =  new System.Drawing.Size(195, 22);
			this.alphabetToolStripMenuItem.Text       =  "Alphabet";
			this.alphabetToolStripMenuItem.Click      += new System.EventHandler(this.alphabetToolStripMenuItem_Click);
			// 
			// alphabetSoundOnlyToolStripMenuItem
			// 
			this.alphabetSoundOnlyToolStripMenuItem.Name  =  "alphabetSoundOnlyToolStripMenuItem";
			this.alphabetSoundOnlyToolStripMenuItem.Size  =  new System.Drawing.Size(195, 22);
			this.alphabetSoundOnlyToolStripMenuItem.Text  =  "Alphabet (Sound Only)";
			this.alphabetSoundOnlyToolStripMenuItem.Click += new System.EventHandler(this.alphabetSoundOnlyToolStripMenuItem_Click);
			// 
			// typeWordToolStripMenuItem
			// 
			this.typeWordToolStripMenuItem.Name  =  "typeWordToolStripMenuItem";
			this.typeWordToolStripMenuItem.Size  =  new System.Drawing.Size(195, 22);
			this.typeWordToolStripMenuItem.Text  =  "Type Word";
			this.typeWordToolStripMenuItem.Click += new System.EventHandler(this.typeWordToolStripMenuItem_Click);
			// 
			// translateWordToolStripMenuItem
			// 
			this.translateWordToolStripMenuItem.Name  =  "translateWordToolStripMenuItem";
			this.translateWordToolStripMenuItem.Size  =  new System.Drawing.Size(195, 22);
			this.translateWordToolStripMenuItem.Text  =  "Translate Word";
			this.translateWordToolStripMenuItem.Click += new System.EventHandler(this.translateWordToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.autoPlayToolStripMenuItem, this.readTypedLetterToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// autoPlayToolStripMenuItem
			// 
			this.autoPlayToolStripMenuItem.Checked    =  true;
			this.autoPlayToolStripMenuItem.CheckState =  System.Windows.Forms.CheckState.Checked;
			this.autoPlayToolStripMenuItem.Name       =  "autoPlayToolStripMenuItem";
			this.autoPlayToolStripMenuItem.Size       =  new System.Drawing.Size(167, 22);
			this.autoPlayToolStripMenuItem.Text       =  "Auto Play";
			this.autoPlayToolStripMenuItem.Click      += new System.EventHandler(this.autoPlayToolStripMenuItem_Click);
			// 
			// readTypedLetterToolStripMenuItem
			// 
			this.readTypedLetterToolStripMenuItem.Checked    =  true;
			this.readTypedLetterToolStripMenuItem.CheckState =  System.Windows.Forms.CheckState.Checked;
			this.readTypedLetterToolStripMenuItem.Name       =  "readTypedLetterToolStripMenuItem";
			this.readTypedLetterToolStripMenuItem.Size       =  new System.Drawing.Size(167, 22);
			this.readTypedLetterToolStripMenuItem.Text       =  "Read Typed Letter";
			this.readTypedLetterToolStripMenuItem.Click      += new System.EventHandler(this.readTypedLetterToolStripMenuItem_Click);
			// 
			// inputLabel
			// 
			this.inputLabel.BackColor  = System.Drawing.Color.Transparent;
			this.inputLabel.Dock       = System.Windows.Forms.DockStyle.Bottom;
			this.inputLabel.Font       = new System.Drawing.Font("Bahnschrift Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.inputLabel.ForeColor  = System.Drawing.SystemColors.Control;
			this.inputLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.inputLabel.Location   = new System.Drawing.Point(0, 183);
			this.inputLabel.Name       = "inputLabel";
			this.inputLabel.Size       = new System.Drawing.Size(525, 42);
			this.inputLabel.TabIndex   = 2;
			this.inputLabel.Text       = "input";
			this.inputLabel.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor           = System.Drawing.SystemColors.ControlText;
			this.ClientSize          = new System.Drawing.Size(525, 225);
			this.Controls.Add(this.inputLabel);
			this.Controls.Add(this.label);
			this.Name     =  "Form1";
			this.Text     =  "Learn Russian";
			this.Load     += new System.EventHandler(this.Form1_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.ToolStripMenuItem readTypedLetterToolStripMenuItem;

		private System.Windows.Forms.Label inputLabel;

		private System.Windows.Forms.ToolStripMenuItem autoPlayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem typeWordToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem translateWordToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem alphabetSoundOnlyToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem alphabetToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;

		private System.Windows.Forms.ContextMenuStrip contextMenu;

		private System.Windows.Forms.Label label;

#endregion
	}
}