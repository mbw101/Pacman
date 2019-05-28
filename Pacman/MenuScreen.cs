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
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();

            Cursor.Hide();
        }

        private void playerButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, "GameScreen");
        }

        private void highButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, "HighScreen");
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playerButton_Enter(object sender, EventArgs e)
        {
            playerButton.BackColor = Color.DimGray;
        }

        private void playerButton_Leave(object sender, EventArgs e)
        {
            playerButton.BackColor = Color.Black;
        }

        private void highButton_Leave(object sender, EventArgs e)
        {
            highButton.BackColor = Color.Black;
        }

        private void highButton_Enter(object sender, EventArgs e)
        {
            highButton.BackColor = Color.DimGray;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.DimGray;
        }

        private void exitButton_Leave(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Black;
        }
    }
}
