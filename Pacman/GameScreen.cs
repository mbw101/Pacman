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
    public partial class GameScreen : UserControl
    {
        // movement speed
        const int SPEED = 4;
        const int startX = 600;
        const int startY = 400;

        // characters
        PacMan player = new PacMan(startX, startY, 32, -SPEED, 0, 3);
        List<Pellet> pellets = new List<Pellet>();
        List<Ghost> ghosts = new List<Ghost>();
        int counter = 0;
        int previousCounter = 0;
        bool animate = false;

        // pens, brushes, graphics
        SolidBrush sb = new SolidBrush(Color.Yellow);

        // player controls
        Boolean WDown, ADown, SDown, DDown;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // game loop
            if (WDown)
            {
                player.setSpeed(0, -SPEED);
            }
            else if (ADown)
            {
                player.setSpeed(-SPEED, 0);
            }
            else if (SDown)
            {
                player.setSpeed(0, SPEED);
            }
            else if (DDown)
            {
                player.setSpeed(SPEED, 0);
            }

            // move pac-man
            player.move();

            // increase counter
            counter++;

            // animation for mouth
            if (counter - 10 > previousCounter && !animate)
            {
                animate = true;
            }
            else if (counter - 20 > previousCounter)
            {
                animate = false;

                previousCounter = counter = 0;
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // going right
            if (player.getXSpeed() == SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 30, 300);
            }
            // going left
            else if (player.getXSpeed() == -SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 210, 300);
            }
            // going up
            else if (player.getYSpeed() == -SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 315, 265);
            }
            // going down
            else if (player.getYSpeed() == SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 150, 240);
            }
            else
            {
                e.Graphics.FillPie(sb, player.rect, 0, 360);
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    ADown = true;
                    break;
                case Keys.D:
                    DDown = true;
                    break;
                case Keys.W:
                    WDown = true;
                    break;
                case Keys.S:
                    SDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    ADown = false;
                    break;
                case Keys.D:
                    DDown = false;
                    break;
                case Keys.W:
                    WDown = false;
                    break;
                case Keys.S:
                    SDown = false;
                    break;
                default:
                    break;
            }
        }
    }
}
