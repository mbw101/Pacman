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
        const int GHOST_SPEED = 3;
        const int startX = 600;
        const int startY = 400;
        int score = 0;

        // characters
        PacMan player = new PacMan(25, 200, 32, -SPEED, 0, 3);
        Font textFont;
        
        List<Pellet> pellets = new List<Pellet>();
        List<Pellet> removePellets = new List<Pellet>();
        List<Wall> walls = new List<Wall>();
        List<Ghost> ghosts = new List<Ghost>();
        int counter = 0;
        int previousCounter = 0;
        bool animate = false;
        int tmpx, tmpy; // temp variables for pac-man
        int tmpXSpeed, tmpYSpeed;

        // pens, brushes, graphics
        SolidBrush sb = new SolidBrush(Color.Yellow);

        // player controls
        Boolean WDown, ADown, SDown, DDown;

        public GameScreen()
        {
            InitializeComponent();

            // create text graphics
            textFont = new Font("Verdana", 18, FontStyle.Regular);

            tmpXSpeed = player.getXSpeed();
            tmpYSpeed = player.getYSpeed();

            for (int i = 1; i < 16; i++)
            {
                Pellet p = new Pellet(50 + (i * 20), 100, 10, 10, Color.Yellow);
                pellets.Add(p);
            }

            Ghost g = new Ghost(100, 250, 32, GHOST_SPEED, 0, "ambush", Color.Red);
            ghosts.Add(g);

            Wall w = new Wall(25, 25, 12, 100, Color.Blue);

            walls.Add(w);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // game loop
            // check key presses
            if (WDown)
            {
                player.setSpeed(0, -SPEED);
                tmpXSpeed = player.getXSpeed();
                tmpYSpeed = player.getYSpeed();
            }
            else if (ADown)
            {
                player.setSpeed(-SPEED, 0);
                tmpXSpeed = player.getXSpeed();
                tmpYSpeed = player.getYSpeed();
            }
            else if (SDown)
            {
                player.setSpeed(0, SPEED);
                tmpXSpeed = player.getXSpeed();
                tmpYSpeed = player.getYSpeed();
            }
            else if (DDown)
            {
                player.setSpeed(SPEED, 0);
                tmpXSpeed = player.getXSpeed();
                tmpYSpeed = player.getYSpeed();
            }

            // check all collisions
            foreach (Pellet p in pellets)
            {
                // check collision
                if (player.collision(p))
                {
                    removePellets.Add(p);

                    score += p.score;
                }
            }

            // remove all pellets that have to be removed
            foreach (Pellet p in removePellets)
            {
                pellets.Remove(p);
            }

            // TODO: Check to see if the player's move is allowed

            // Check collision with all level walls
            foreach (Wall wall in walls)
            {
                if (player.collision(wall))
                {
                    if (tmpXSpeed == 0 && tmpYSpeed == 0)
                    {
                        tmpXSpeed = player.getXSpeed();
                        tmpYSpeed = player.getYSpeed();
                    }

                    player.setSpeed(0, 0);
                    player.setPosition(tmpx, tmpy);
                }
                else
                {
                    tmpx = player.rect.X;
                    tmpy = player.rect.Y;


                    // move pac-man
                    player.move();
                    Rectangle tempRect = player.rect;

                    if (wall.rect.IntersectsWith(tempRect))
                    {
                        player.setPosition(tmpx, tmpy);
                    }
                             
                }
            }

            // move ghosts
            foreach (Ghost g in ghosts)
            {
                g.move(player);
            }

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
            sb.Color = Color.Yellow;

            // going right
            if (tmpXSpeed == SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 30, 300);
            }
            // going left
            else if (tmpXSpeed == -SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 210, 300);
            }
            // going up
            else if (tmpYSpeed == -SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 315, 265);
            }
            // going down
            else if (tmpYSpeed == SPEED && !animate)
            {
                e.Graphics.FillPie(sb, player.rect, 150, 240);
            }
            else
            {
                e.Graphics.FillPie(sb, player.rect, 0, 360);
            }

            // draw pellets
            foreach (Pellet p in pellets)
            {
                sb.Color = p.colour;

                e.Graphics.FillRectangle(sb, p.rect);
            }

            // Draw walls
            foreach (Wall w in walls)
            {
                sb.Color = w.colour;

                e.Graphics.FillRectangle(sb, w.rect);
            }

            // draw ghosts
            foreach (Ghost g in ghosts)
            {
                sb.Color = g.colour;

                e.Graphics.FillRectangle(sb, g.rect);
            }

            // draw score
            sb.Color = Color.White;

            e.Graphics.DrawString("Score: " + score, textFont, sb, new Point(500, Height - 100));

            // TODO: Draw lives
            e.Graphics.DrawString("Lives: " + player.lives, textFont, sb, new Point(10, Height - 100));
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
