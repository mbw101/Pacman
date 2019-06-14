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
            this.coinLabel = new System.Windows.Forms.Label();
            this.playerButton = new System.Windows.Forms.Button();
            this.highButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("mono 07_66", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Gold;
            this.titleLabel.Location = new System.Drawing.Point(194, 34);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(418, 78);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "PAC-MAN";
            // 
            // coinLabel
            // 
            this.coinLabel.AutoSize = true;
            this.coinLabel.Font = new System.Drawing.Font("mono 07_55", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinLabel.ForeColor = System.Drawing.Color.White;
            this.coinLabel.Location = new System.Drawing.Point(253, 163);
            this.coinLabel.Name = "coinLabel";
            this.coinLabel.Size = new System.Drawing.Size(287, 52);
            this.coinLabel.TabIndex = 4;
            this.coinLabel.Text = "Insert Coin";
            // 
            // playerButton
            // 
            this.playerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playerButton.Font = new System.Drawing.Font("monooge 05_56", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerButton.ForeColor = System.Drawing.Color.Blue;
            this.playerButton.Location = new System.Drawing.Point(300, 256);
            this.playerButton.Name = "playerButton";
            this.playerButton.Size = new System.Drawing.Size(200, 60);
            this.playerButton.TabIndex = 0;
            this.playerButton.Text = "Play";
            this.playerButton.UseVisualStyleBackColor = true;
            this.playerButton.Click += new System.EventHandler(this.playerButton_Click);
            this.playerButton.Enter += new System.EventHandler(this.playerButton_Enter);
            this.playerButton.Leave += new System.EventHandler(this.playerButton_Leave);
            // 
            // highButton
            // 
            this.highButton.BackColor = System.Drawing.Color.Black;
            this.highButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highButton.Font = new System.Drawing.Font("monooge 05_56", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highButton.ForeColor = System.Drawing.Color.Blue;
            this.highButton.Location = new System.Drawing.Point(300, 351);
            this.highButton.Name = "highButton";
            this.highButton.Size = new System.Drawing.Size(200, 60);
            this.highButton.TabIndex = 1;
            this.highButton.Text = "Scores";
            this.highButton.UseVisualStyleBackColor = false;
            this.highButton.Click += new System.EventHandler(this.highButton_Click);
            this.highButton.Enter += new System.EventHandler(this.highButton_Enter);
            this.highButton.Leave += new System.EventHandler(this.highButton_Leave);
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("monooge 05_56", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Blue;
            this.exitButton.Location = new System.Drawing.Point(300, 442);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 60);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click_1);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            this.exitButton.Leave += new System.EventHandler(this.exitButton_Leave);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.highButton);
            this.Controls.Add(this.playerButton);
            this.Controls.Add(this.coinLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label coinLabel;
        private System.Windows.Forms.Button playerButton;
        private System.Windows.Forms.Button highButton;
        private System.Windows.Forms.Button exitButton;
    }
}
