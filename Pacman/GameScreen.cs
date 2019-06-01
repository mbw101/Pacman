using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.Threading;

namespace Pacman
{
    public partial class GameScreen : UserControl
    {
        // movement speed
        const int SPEED = 3;
        const int GHOST_SPEED = 2;
        const int startX = 600;
        const int startY = 400;
        int score = 0;

        // characters
        PacMan player = new PacMan(686, 214, 32, -SPEED, 0, 3);
        Font textFont;

        // sounds
        SoundPlayer death = new SoundPlayer(Properties.Resources.pacman_death);
        
        List<Pellet> pellets = new List<Pellet>();
        List<Pellet> removePellets = new List<Pellet>();
        List<Wall> walls = new List<Wall>();
        List<Ghost> ghosts = new List<Ghost>();
         
        int counter = 0;
        int previousCounter = 0;
        bool animate = false, collided = false, moved = false;
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

            initLevel();
        }


        public void initLevel()
        {
            tmpXSpeed = player.getXSpeed();
            tmpYSpeed = player.getYSpeed();

            for (int i = 1; i < 36; i++)
            {
                Pellet p = new Pellet(32 + (i * 20), 50, 10, 10, Color.Yellow);
                pellets.Add(p);
            }

            for (int i = 1; i < 25; i++)
            {
                Pellet p = new Pellet(52, 50 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }

            Ghost g = new Ghost(100, 250, 32, GHOST_SPEED, 0, 200, "ambush", Color.Red);

            ghosts.Clear();
            ghosts.Add(g);


            /*Wall w = new Wall(25, 25, 12, 240, Color.Blue);

            Wall w = new Wall(25, 25, 12, 240, Color.Blue);
            Wall w2 = new Wall(25, 25, 740, 12, Color.Blue);
            Wall w3 = new Wall(765, 25, 12, 240, Color.Blue);
            Wall w4 = new Wall(25, 305, 12, 240, Color.Blue);
            Wall w5 = new Wall(765, 305, 12, 240, Color.Blue);
            Wall w6 = new Wall(25, 545, 752, 12, Color.Blue);

            //Wall w7 = new Wall(15, 305, 12, 15, Color.Yellow);
            // TODO: Figure out a way to have pac-man teleport when he exits 
            
            Wall w7 = new Wall(15, 305, 12, 15, Color.Yellow);
            // TODO: Figure out a way to have pac-man teleport when he exits 

            walls.Add(w);
            walls.Add(w2);
            walls.Add(w3);
            walls.Add(w4);
            walls.Add(w5);
            walls.Add(w6);

            */
        }

        public void saveHighscores()
        {
            XmlWriter writer = XmlWriter.Create("Resources//highscores.xml");
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // create a temporary location of pac-man
            int tempX = player.rect.X;
            int tempY = player.rect.Y;

            int tempX2 = ghosts[0].rect.X;
            int tempY2 = ghosts[0].rect.Y;

            // set pac-man's direction
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

            // move pac-man
            player.move();

            foreach (Ghost g in ghosts)
            {
                g.move();

                if (player.Collision(g))
                {
                    //death.Play();

                    //Thread.Sleep(2000);

                    //initLevel();

                    //gameTimer.Enabled = false;
                }
            }

            // check collisions with pellets
            foreach (Pellet p in pellets)
            {
                // check collision
                if (player.Collision(p))
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

            // check for collision with each wall
            foreach (Wall wall in walls)
            {
                if (player.Collision(wall))
                {
                    player.setPosition(tempX, tempY);
                    collided = true;

                    // end loop
                    break;
                }
                else
                {
                    collided = false;                                
                }
            }

            // reset pac-man's positon when collided
            if (collided)
            {
                player.setPosition(tempX, tempY);
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

            switch (player.lives)
            {
                case 3:
                    e.Graphics.FillPie(sb, 50, 560, 32, 32, 30, 300);
                    e.Graphics.FillPie(sb, 100, 560, 32, 32, 30, 300);
                    e.Graphics.FillPie(sb, 150, 560, 32, 32, 30, 300);
                    break;
                case 2:
                    e.Graphics.FillPie(sb, 50, 560, 32, 32, 30, 300);
                    e.Graphics.FillPie(sb, 100, 560, 32, 32, 30, 300);
                    break;

                case 1:
                    e.Graphics.FillPie(sb, 50, 560, 32, 32, 30, 300);
                    break;
            }

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
            e.Graphics.DrawString("Score: " + score, textFont, sb, new Point(500, Height - 40));

            // Draw lives
            //e.Graphics.DrawString("Lives: " + player.lives, textFont, sb, new Point(10, Height - 40));
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
                case Keys.C:
                    Form1.ChangeScreen(this, "NameScreen");
                    gameTimer.Enabled = false;
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
