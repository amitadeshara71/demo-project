﻿namespace CountFourGame
{
    partial class frmCount4
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
            this.btnResetGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResetGame
            // 
            this.btnResetGame.Location = new System.Drawing.Point(0, 0);
            this.btnResetGame.Name = "btnResetGame";
            this.btnResetGame.Size = new System.Drawing.Size(75, 23);
            this.btnResetGame.TabIndex = 0;
            this.btnResetGame.Text = "Reset Game";
            this.btnResetGame.UseVisualStyleBackColor = true;
            this.btnResetGame.Click += new System.EventHandler(this.btnResetGame_Click);
            // 
            // frmCount4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 419);
            this.Controls.Add(this.btnResetGame);
            this.Name = "frmCount4";
            this.Text = "Count 4 Board";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCount4_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmCount4_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResetGame;
    }
}

