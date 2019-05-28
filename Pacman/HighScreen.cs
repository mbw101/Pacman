using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Pacman
{
    public partial class HighScreen : UserControl
    {
        public HighScreen()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, "MenuScreen");
        }

        private void backButton_Leave(object sender, EventArgs e)
        {
            backButton.BackColor = Color.Black;
        }

        private void backButton_Enter(object sender, EventArgs e)
        {
            backButton.BackColor = Color.DimGray;
        }
    }
}
