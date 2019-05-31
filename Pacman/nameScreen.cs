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

            if (index == 0)
            {
                firstLabel.BackColor = Color.DodgerBlue;
                Refresh();
            }
        }

        private void NameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (index == 0)
                    {
                        firstLabel.BackColor = Color.DodgerBlue;
                        secondLabel.BackColor = Color.White;

                        if (FDOrder < 25)
                        {
                            FDOrder++;
                            firstLabel.Text = letters[FDOrder];
                        }
                    }
                    else if (index == 1)
                    {
                        firstLabel.BackColor = Color.DodgerBlue;
                        secondLabel.BackColor = Color.DodgerBlue;

                        if (SDOrder < 25)
                        {
                            SDOrder++;
                            secondLabel.Text = letters[SDOrder];
                        }
                    }
                    Refresh();
                    break;
                case Keys.S:
                    if (index == 0)
                    {
                        firstLabel.BackColor = Color.DodgerBlue;
                        secondLabel.BackColor = Color.White;

                        if (FDOrder > 0)
                        {
                            FDOrder--;
                            firstLabel.Text = letters[FDOrder];
                        }
                    }
                    else if (index == 1)
                    {
                        firstLabel.BackColor = Color.DodgerBlue;
                        secondLabel.BackColor = Color.DodgerBlue;

                        if (SDOrder > 0)
                        {
                            SDOrder--;
                            secondLabel.Text = letters[SDOrder];
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
            }
        }
    }
}
