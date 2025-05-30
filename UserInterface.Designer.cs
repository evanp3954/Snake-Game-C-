﻿namespace KSU.CIS300.Snake
{
    partial class UserInterface
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
            uxPictureBox = new System.Windows.Forms.PictureBox();
            uxMenuStrip = new System.Windows.Forms.MenuStrip();
            uxToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            uxToolStripMenuItem_NewGame = new System.Windows.Forms.ToolStripMenuItem();
            uxEasyGame = new System.Windows.Forms.ToolStripMenuItem();
            uxNormalGame = new System.Windows.Forms.ToolStripMenuItem();
            uxHardGame = new System.Windows.Forms.ToolStripMenuItem();
            uxlabelScore = new System.Windows.Forms.Label();
            uxScore = new System.Windows.Forms.Label();
            uxIsAI = new System.Windows.Forms.CheckBox();
            uxAIspeed = new System.Windows.Forms.NumericUpDown();
            uxAIspeedLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)uxPictureBox).BeginInit();
            uxMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uxAIspeed).BeginInit();
            SuspendLayout();
            // 
            // uxPictureBox
            // 
            uxPictureBox.BackColor = System.Drawing.Color.Black;
            uxPictureBox.Location = new System.Drawing.Point(6, 47);
            uxPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            uxPictureBox.Name = "uxPictureBox";
            uxPictureBox.Size = new System.Drawing.Size(606, 386);
            uxPictureBox.TabIndex = 0;
            uxPictureBox.TabStop = false;
            uxPictureBox.Paint += PictureBox_Paint;
            // 
            // uxMenuStrip
            // 
            uxMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { uxToolStripMenuItem_File });
            uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            uxMenuStrip.Name = "uxMenuStrip";
            uxMenuStrip.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            uxMenuStrip.Size = new System.Drawing.Size(624, 29);
            uxMenuStrip.TabIndex = 1;
            uxMenuStrip.Text = "menuStrip1";
            // 
            // uxToolStripMenuItem_File
            // 
            uxToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { uxToolStripMenuItem_NewGame });
            uxToolStripMenuItem_File.Name = "uxToolStripMenuItem_File";
            uxToolStripMenuItem_File.Size = new System.Drawing.Size(48, 25);
            uxToolStripMenuItem_File.Text = "File";
            // 
            // uxToolStripMenuItem_NewGame
            // 
            uxToolStripMenuItem_NewGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { uxEasyGame, uxNormalGame, uxHardGame });
            uxToolStripMenuItem_NewGame.Name = "uxToolStripMenuItem_NewGame";
            uxToolStripMenuItem_NewGame.Size = new System.Drawing.Size(178, 30);
            uxToolStripMenuItem_NewGame.Text = "New Game";
            // 
            // uxEasyGame
            // 
            uxEasyGame.Name = "uxEasyGame";
            uxEasyGame.Size = new System.Drawing.Size(154, 30);
            uxEasyGame.Text = "Easy";
            uxEasyGame.Click += EasyGame_Click;
            // 
            // uxNormalGame
            // 
            uxNormalGame.Name = "uxNormalGame";
            uxNormalGame.Size = new System.Drawing.Size(154, 30);
            uxNormalGame.Text = "Normal";
            uxNormalGame.Click += NormalGame_Click;
            // 
            // uxHardGame
            // 
            uxHardGame.Name = "uxHardGame";
            uxHardGame.Size = new System.Drawing.Size(154, 30);
            uxHardGame.Text = "Hard";
            uxHardGame.Click += HardGame_Click;
            // 
            // uxlabelScore
            // 
            uxlabelScore.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            uxlabelScore.AutoSize = true;
            uxlabelScore.BackColor = System.Drawing.Color.White;
            uxlabelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            uxlabelScore.Location = new System.Drawing.Point(466, 8);
            uxlabelScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            uxlabelScore.Name = "uxlabelScore";
            uxlabelScore.Size = new System.Drawing.Size(71, 24);
            uxlabelScore.TabIndex = 2;
            uxlabelScore.Text = "Score:";
            uxlabelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxScore
            // 
            uxScore.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            uxScore.BackColor = System.Drawing.Color.White;
            uxScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            uxScore.Location = new System.Drawing.Point(538, 10);
            uxScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            uxScore.Name = "uxScore";
            uxScore.Size = new System.Drawing.Size(74, 27);
            uxScore.TabIndex = 3;
            uxScore.Text = "0";
            uxScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uxIsAI
            // 
            uxIsAI.AutoSize = true;
            uxIsAI.BackColor = System.Drawing.Color.WhiteSmoke;
            uxIsAI.Location = new System.Drawing.Point(62, 8);
            uxIsAI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uxIsAI.Name = "uxIsAI";
            uxIsAI.Size = new System.Drawing.Size(93, 25);
            uxIsAI.TabIndex = 4;
            uxIsAI.Text = "AI Player";
            uxIsAI.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            uxIsAI.UseVisualStyleBackColor = false;
            uxIsAI.KeyDown += UserInterface_KeyDown;
            uxIsAI.PreviewKeyDown += UserInterface_PreviewKeyDown;
            // 
            // uxAIspeed
            // 
            uxAIspeed.Location = new System.Drawing.Point(258, 3);
            uxAIspeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uxAIspeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            uxAIspeed.Name = "uxAIspeed";
            uxAIspeed.Size = new System.Drawing.Size(75, 29);
            uxAIspeed.TabIndex = 5;
            uxAIspeed.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // uxAIspeedLabel
            // 
            uxAIspeedLabel.AutoSize = true;
            uxAIspeedLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            uxAIspeedLabel.Location = new System.Drawing.Point(172, 10);
            uxAIspeedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            uxAIspeedLabel.Name = "uxAIspeedLabel";
            uxAIspeedLabel.Size = new System.Drawing.Size(71, 21);
            uxAIspeedLabel.TabIndex = 6;
            uxAIspeedLabel.Text = "AI Speed";
            // 
            // UserInterface
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Silver;
            ClientSize = new System.Drawing.Size(624, 449);
            Controls.Add(uxAIspeedLabel);
            Controls.Add(uxAIspeed);
            Controls.Add(uxIsAI);
            Controls.Add(uxScore);
            Controls.Add(uxlabelScore);
            Controls.Add(uxPictureBox);
            Controls.Add(uxMenuStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MainMenuStrip = uxMenuStrip;
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "UserInterface";
            Text = "Classic Snake";
            KeyDown += UserInterface_KeyDown;
            PreviewKeyDown += UserInterface_PreviewKeyDown;
            ((System.ComponentModel.ISupportInitialize)uxPictureBox).EndInit();
            uxMenuStrip.ResumeLayout(false);
            uxMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)uxAIspeed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox uxPictureBox;
        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem uxToolStripMenuItem_NewGame;
        private System.Windows.Forms.Label uxlabelScore;
        private System.Windows.Forms.Label uxScore;
        private System.Windows.Forms.ToolStripMenuItem uxEasyGame;
        private System.Windows.Forms.ToolStripMenuItem uxNormalGame;
        private System.Windows.Forms.ToolStripMenuItem uxHardGame;
        private System.Windows.Forms.CheckBox uxIsAI;
        private System.Windows.Forms.NumericUpDown uxAIspeed;
        private System.Windows.Forms.Label uxAIspeedLabel;
    }
}

