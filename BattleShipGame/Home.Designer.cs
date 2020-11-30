namespace BattleShipGame
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEnterName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lstLeagueTable = new System.Windows.Forms.ListBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lblLeagueTable = new System.Windows.Forms.Label();
            this.lblChooseDifficulty = new System.Windows.Forms.Label();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Copperplate Gothic Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // picIcon
            // 
            this.picIcon.Image = global::BattleShipGame.Properties.Resources.Battleship_84x84;
            this.picIcon.Location = new System.Drawing.Point(253, 22);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(84, 84);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("a_MachinaOrtoSht", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(12, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 76);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "The Battleship\r\nGame";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnterName
            // 
            this.lblEnterName.AutoSize = true;
            this.lblEnterName.Font = new System.Drawing.Font("Copperplate Gothic Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterName.Location = new System.Drawing.Point(31, 113);
            this.lblEnterName.Name = "lblEnterName";
            this.lblEnterName.Size = new System.Drawing.Size(282, 31);
            this.lblEnterName.TabIndex = 3;
            this.lblEnterName.Text = "Enter your name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Copperplate Gothic Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Red;
            this.txtName.Location = new System.Drawing.Point(34, 148);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(276, 39);
            this.txtName.TabIndex = 4;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstLeagueTable
            // 
            this.lstLeagueTable.BackColor = System.Drawing.Color.Honeydew;
            this.lstLeagueTable.FormattingEnabled = true;
            this.lstLeagueTable.Location = new System.Drawing.Point(34, 332);
            this.lstLeagueTable.Name = "lstLeagueTable";
            this.lstLeagueTable.Size = new System.Drawing.Size(276, 69);
            this.lstLeagueTable.TabIndex = 5;
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.btnStartGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnStartGame.FlatAppearance.BorderSize = 2;
            this.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Copperplate Gothic Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(34, 193);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(276, 37);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lblLeagueTable
            // 
            this.lblLeagueTable.AutoSize = true;
            this.lblLeagueTable.Font = new System.Drawing.Font("Copperplate Gothic Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeagueTable.Location = new System.Drawing.Point(58, 299);
            this.lblLeagueTable.Name = "lblLeagueTable";
            this.lblLeagueTable.Size = new System.Drawing.Size(229, 31);
            this.lblLeagueTable.TabIndex = 8;
            this.lblLeagueTable.Text = "League Table:";
            // 
            // lblChooseDifficulty
            // 
            this.lblChooseDifficulty.AutoSize = true;
            this.lblChooseDifficulty.Font = new System.Drawing.Font("Copperplate Gothic Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseDifficulty.Location = new System.Drawing.Point(20, 233);
            this.lblChooseDifficulty.Name = "lblChooseDifficulty";
            this.lblChooseDifficulty.Size = new System.Drawing.Size(312, 31);
            this.lblChooseDifficulty.TabIndex = 9;
            this.lblChooseDifficulty.Text = "Choose Difficulty:";
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Checked = true;
            this.rbEasy.Font = new System.Drawing.Font("Copperplate Gothic Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEasy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.rbEasy.Location = new System.Drawing.Point(66, 261);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(105, 35);
            this.rbEasy.TabIndex = 10;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "Easy";
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Font = new System.Drawing.Font("Copperplate Gothic Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.rbHard.Location = new System.Drawing.Point(177, 261);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(113, 35);
            this.rbHard.TabIndex = 11;
            this.rbHard.Text = "Hard";
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(354, 411);
            this.Controls.Add(this.rbHard);
            this.Controls.Add(this.rbEasy);
            this.Controls.Add(this.lblChooseDifficulty);
            this.Controls.Add(this.lblLeagueTable);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lstLeagueTable);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEnterName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(370, 450);
            this.MinimumSize = new System.Drawing.Size(370, 450);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Battleship Game";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Home_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEnterName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox lstLeagueTable;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblLeagueTable;
        private System.Windows.Forms.Label lblChooseDifficulty;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

