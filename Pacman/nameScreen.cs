using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class NameScreen : UserControl
    {
        static List<string> letters = 
            new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
                "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
        int index = 0;
        static int FDOrder = 0;
        static int SDOrder = 0;
        static int TDOrder = 0;
        string FD = letters[FDOrder];
        string SD = letters[SDOrder];
        string TD = letters[TDOrder];

        public NameScreen()
        {
            InitializeComponent();
            scoreLabel.Text += GameScreen.score + "!";
        }

        private void NameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (index == 0)
                    {
                        if (FDOrder < 25)
                        {
                            FDOrder++;
                            firstLabel.Text = letters[FDOrder];
                        }
                    }
                    else if (index == 1)
                    {
                        if (SDOrder < 25)
                        {
                            SDOrder++;
                            secondLabel.Text = letters[SDOrder];
                        }
                    }
                    else if (index == 2)
                    {
                        if (TDOrder < 25)
                        {
                            TDOrder++;
                            thirdLabel.Text = letters[TDOrder];
                        }
                    }
                    break;
                case Keys.S:
                    if (index == 0)
                    {
                        if (FDOrder > 0)
                        {
                            FDOrder--;
                            firstLabel.Text = letters[FDOrder];
                        }
                    }
                    else if (index == 1)
                    {
                        if (SDOrder > 0)
                        {
                            SDOrder--;
                            secondLabel.Text = letters[SDOrder];
                        }
                    }
                    else if (index == 2)
                    {
                        if (TDOrder > 0)
                        {
                            TDOrder--;
                            thirdLabel.Text = letters[TDOrder];
                        }
                    }
                    break;
                case Keys.A:
                    if (index == 0)
                        index = 3;
                    else
                        index--;
                    break;
                case Keys.D:
                    if (index == 3)
                        index = 0;
                    else
                        index++;
                    break;
                case Keys.Enter:
                    if (index == 3)
                    {
                        FD = letters[FDOrder];
                        SD = letters[SDOrder];
                        TD = letters[TDOrder];

                        // save initial
                        string initial = FD + SD + TD;

                        // create high score object and add it to the list
                        Highscore hs = new Highscore(initial, GameScreen.score);
                        HighScreen.highscores.Add(hs);

                        // load all previous high scores
                        HighScreen.loadHighscores();

                        // save the highscores that are in the list
                        HighScreen.saveHighscores();

                        // change to the highscore screen
                        Form1.ChangeScreen(this, "HighScreen");

                        Refresh();
                    }
                    break;           
            }
        }

        private void gameTImer2_Tick(object sender, EventArgs e)
        {
            switch (index)
            {
                case 0:
                    firstLabel.BackColor = Color.DodgerBlue;
                    secondLabel.BackColor = Color.White;
                    thirdLabel.BackColor = Color.White;
                    saveLabel.BackColor = Color.White;
                    break;
                case 1:
                    firstLabel.BackColor = Color.White;
                    secondLabel.BackColor = Color.DodgerBlue;
                    thirdLabel.BackColor = Color.White;
                    saveLabel.BackColor = Color.White;
                    break;
                case 2:
                    firstLabel.BackColor = Color.White;
                    secondLabel.BackColor = Color.White;
                    thirdLabel.BackColor = Color.DodgerBlue;
                    saveLabel.BackColor = Color.White;
                    break;
                case 3:
                    firstLabel.BackColor = Color.White;
                    secondLabel.BackColor = Color.White;
                    thirdLabel.BackColor = Color.White;
                    saveLabel.BackColor = Color.DodgerBlue;
                    break;
            }
        }
    }
}
