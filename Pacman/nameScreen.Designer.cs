namespace Pacman
{
    partial class NameScreen
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
            this.firstLabel = new System.Windows.Forms.Label();
            this.secondLabel = new System.Windows.Forms.Label();
            this.thirdLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameTImer2 = new System.Windows.Forms.Timer(this.components);
            this.saveLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstLabel
            // 
            this.firstLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.firstLabel.Font = new System.Drawing.Font("monoeger 05_55", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstLabel.Location = new System.Drawing.Point(266, 239);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(68, 80);
            this.firstLabel.TabIndex = 0;
            this.firstLabel.Text = "A";
            // 
            // secondLabel
            // 
            this.secondLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.secondLabel.Font = new System.Drawing.Font("monoeger 05_55", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondLabel.Location = new System.Drawing.Point(366, 239);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(68, 80);
            this.secondLabel.TabIndex = 1;
            this.secondLabel.Text = "A";
            // 
            // thirdLabel
            // 
            this.thirdLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thirdLabel.Font = new System.Drawing.Font("monoeger 05_55", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thirdLabel.Location = new System.Drawing.Point(466, 239);
            this.thirdLabel.Name = "thirdLabel";
            this.thirdLabel.Size = new System.Drawing.Size(68, 80);
            this.thirdLabel.TabIndex = 2;
            this.thirdLabel.Text = "A\r\n";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("mono 07_55", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.scoreLabel.Location = new System.Drawing.Point(191, 10);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(389, 57);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Your score is ";
            // 
            // gameTImer2
            // 
            this.gameTImer2.Enabled = true;
            this.gameTImer2.Interval = 16;
            this.gameTImer2.Tick += new System.EventHandler(this.gameTImer2_Tick);
            // 
            // saveLabel
            // 
            this.saveLabel.AutoSize = true;
            this.saveLabel.BackColor = System.Drawing.Color.Black;
            this.saveLabel.Font = new System.Drawing.Font("monooge 05_56", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLabel.ForeColor = System.Drawing.Color.Blue;
            this.saveLabel.Location = new System.Drawing.Point(575, 489);
            this.saveLabel.Name = "saveLabel";
            this.saveLabel.Size = new System.Drawing.Size(125, 36);
            this.saveLabel.TabIndex = 3;
            this.saveLabel.Text = "Save ";
            // 
            // NameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.saveLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.thirdLabel);
            this.Controls.Add(this.secondLabel);
            this.Controls.Add(this.firstLabel);
            this.Name = "NameScreen";
            this.Size = new System.Drawing.Size(800, 600);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.NameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstLabel;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Label thirdLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer gameTImer2;
        private System.Windows.Forms.Label saveLabel;
    }
}
