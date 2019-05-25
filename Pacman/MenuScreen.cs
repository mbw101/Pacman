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
            // TODO: Show high screen
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
