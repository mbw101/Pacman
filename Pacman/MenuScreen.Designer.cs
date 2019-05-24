namespace Pacman
{
    partial class MenuScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.playLabel = new System.Windows.Forms.Label();
            this.scoresLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.coinLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("mono 07_65", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(187, 27);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(376, 78);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "PAC-MAN";
            // 
            // playLabel
            // 
            this.playLabel.AutoSize = true;
            this.playLabel.Font = new System.Drawing.Font("mono 07_66", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playLabel.ForeColor = System.Drawing.Color.White;
            this.playLabel.Location = new System.Drawing.Point(304, 242);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(156, 47);
            this.playLabel.TabIndex = 0;
            this.playLabel.Text = "Play";
            this.playLabel.Click += new System.EventHandler(this.playLabel_Click);
            // 
            // scoresLabel
            // 
            this.scoresLabel.AutoSize = true;
            this.scoresLabel.Font = new System.Drawing.Font("mono 07_66", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoresLabel.ForeColor = System.Drawing.Color.White;
            this.scoresLabel.Location = new System.Drawing.Point(192, 332);
            this.scoresLabel.Name = "scoresLabel";
            this.scoresLabel.Size = new System.Drawing.Size(360, 47);
            this.scoresLabel.TabIndex = 1;
            this.scoresLabel.Text = "Highscores";
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("mono 07_66", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.Color.White;
            this.exitLabel.Location = new System.Drawing.Point(304, 421);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(156, 47);
            this.exitLabel.TabIndex = 2;
            this.exitLabel.Text = "Exit";
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // coinLabel
            // 
            this.coinLabel.AutoSize = true;
            this.coinLabel.Font = new System.Drawing.Font("Orbit-B BT", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinLabel.ForeColor = System.Drawing.Color.White;
            this.coinLabel.Location = new System.Drawing.Point(286, 174);
            this.coinLabel.Name = "coinLabel";
            this.coinLabel.Size = new System.Drawing.Size(174, 38);
            this.coinLabel.TabIndex = 4;
            this.coinLabel.Text = "Insert Coin";
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.coinLabel);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.scoresLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(800, 600);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuScreen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.Label scoresLabel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label coinLabel;
    }
}
