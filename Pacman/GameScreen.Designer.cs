namespace Pacman
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 16;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 16);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(0, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 16);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(784, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 214);
            this.label3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(688, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 98);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(688, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(393, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 100);
            this.label6.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(784, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 214);
            this.label7.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(688, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(588, 442);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 32);
            this.label9.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(686, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 148);
            this.label10.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(718, 350);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 32);
            this.label11.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(752, 416);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 32);
            this.label12.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(638, 480);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 16);
            this.label13.TabIndex = 12;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 600);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
