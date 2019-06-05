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
        public static int score = 0;

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
            // reset score
            score = 0;

            // set the temp x and y of pacman
            tmpXSpeed = player.getXSpeed();
            tmpYSpeed = player.getYSpeed();

            // create pellets
            for (int i = 1; i < 7; i++)
            {
                Pellet p = new Pellet(12 + (i * 20), 46, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 10; i++)
            {
                Pellet p = new Pellet(32, 46 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 6; i++)
            {
                Pellet p = new Pellet(32 + (i * 20), 226, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 9; i++)
            {
                Pellet p = new Pellet(132, 46 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 16; i++)
            {
                Pellet p = new Pellet(132, 206 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 16; i++)
            {
                Pellet p = new Pellet(132, 206 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 6; i++)
            {
                Pellet p = new Pellet(10 + (i * 20), 330, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 5; i++)
            {
                Pellet p = new Pellet(30, 330 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 7; i++)
            {
                Pellet p = new Pellet(55, 385 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 36; i++)
            {
                Pellet p = new Pellet(55 + (i * 20), 505, 10, 10, Color.Yellow);
                pellets.Add(p);
            }

            // create ghosts
            Ghost g = new Ghost(100, 250, 32, GHOST_SPEED, 0, 200, "ambush", Color.Red);

            ghosts.Clear();
            ghosts.Add(g);

            // create walls

            //outer shell
            Wall w = new Wall(0, 14, 800, 16, Color.Blue);
            Wall w2 = new Wall(0, 530, 800, 16, Color.Blue);
            Wall w3 = new Wall(0, 30, 16, 214, Color.Blue);
            Wall w4 = new Wall(784, 30, 16, 214, Color.Blue);
            Wall w5 = new Wall(0, 244, 112, 16, Color.Blue);
            Wall w6 = new Wall(688, 244, 112, 16, Color.Blue);
            Wall w7 = new Wall(0, 300, 112, 16, Color.Blue);
            Wall w8 = new Wall(688, 300, 112, 16, Color.Blue);
            Wall w9 = new Wall(0, 316, 16, 214, Color.Blue);
            Wall w10 = new Wall(784, 316, 16, 214, Color.Blue);

            //lower half
            Wall w11 = new Wall(16, 426, 28, 104, Color.Blue);
            Wall w12 = new Wall(756, 426, 28, 104, Color.Blue);
            Wall w13 = new Wall(56, 354, 28, 32, Color.Blue);
            Wall w14 = new Wall(718, 354, 28, 32, Color.Blue);
            Wall w15 = new Wall(80, 354, 32, 136, Color.Blue);
            Wall w16 = new Wall(688, 354, 32, 136, Color.Blue);
            Wall w17 = new Wall(152, 300, 32, 86, Color.Blue);
            Wall w18 = new Wall(618, 300, 32, 86, Color.Blue);
            Wall w19 = new Wall(152, 426, 32, 64, Color.Blue);
            Wall w20 = new Wall(618, 426, 32, 64, Color.Blue);
            Wall w21 = new Wall(184, 465, 98, 25, Color.Blue);
            Wall w22 = new Wall(520, 465, 98, 25, Color.Blue);
            Wall w23 = new Wall(222, 300, 60, 124, Color.Blue);
            Wall w24 = new Wall(520, 300, 60, 124, Color.Blue);
            Wall w25 = new Wall(320, 372, 60, 52, Color.Blue);
            Wall w26 = new Wall(420, 372, 60, 52, Color.Blue);
            Wall w27 = new Wall(320, 465, 160, 25, Color.Blue);

            //ghost box
            Wall w28 = new Wall(320, 232, 16, 100, Color.Blue);
            Wall w29 = new Wall(464, 232, 16, 100, Color.Blue);
            Wall w30 = new Wall(336, 316, 128, 16, Color.Blue);
            Wall w31 = new Wall(336, 232, 40, 16, Color.Blue);
            Wall w32 = new Wall(424, 232, 40, 16, Color.Blue);
            Wall w33 = new Wall(376, 236, 48, 10, Color.White);

            //upper half
            Wall w34 = new Wall(56, 68, 56, 138, Color.White);
            Wall w35 = new Wall(688, 68, 56, 138, Color.White);
            Wall w36 = new Wall(152, 30, 32, 62, Color.White);
            Wall w37 = new Wall(618, 30, 32, 62, Color.White);
            Wall w38 = new Wall(152, 204, 32, 56, Color.White);
            Wall w39 = new Wall(618, 204, 32, 56, Color.White);
            Wall w40 = new Wall(150, 132, 132, 32, Color.White);
            Wall w41 = new Wall(520, 132, 132, 32, Color.White);
            Wall w42 = new Wall(222, 164, 60, 96, Color.White);
            Wall w43 = new Wall(520, 164, 60, 96, Color.White);
            Wall w44 = new Wall(222, 70, 158, 22, Color.White);
            Wall w45 = new Wall(420, 70, 158, 22, Color.White);
            Wall w46 = new Wall(320, 132, 160, 60, Color.White);

            walls.Add(w);
            walls.Add(w2);
            walls.Add(w3);
            walls.Add(w4);
            walls.Add(w5);
            walls.Add(w6);
            walls.Add(w7);
            walls.Add(w8);
            walls.Add(w9);
            walls.Add(w10);

            walls.Add(w11);
            walls.Add(w12);
            walls.Add(w13);
            walls.Add(w14);
            walls.Add(w15);
            walls.Add(w16);
            walls.Add(w17);
            walls.Add(w18);
            walls.Add(w19);
            walls.Add(w20);
            walls.Add(w21);
            walls.Add(w22);
            walls.Add(w23);
            walls.Add(w24);
            walls.Add(w25);
            walls.Add(w26);
            walls.Add(w27);

            walls.Add(w28);
            walls.Add(w29);
            walls.Add(w30);
            walls.Add(w31);
            walls.Add(w32);
            walls.Add(w33);

            walls.Add(w34);
            walls.Add(w35);
            walls.Add(w36);
            walls.Add(w37);
            walls.Add(w38);
            walls.Add(w39);
            walls.Add(w40);
            walls.Add(w41);
            walls.Add(w42);
            walls.Add(w43);
            walls.Add(w44);
            walls.Add(w45);
            walls.Add(w46);

        }

        public void GameOver()
        {

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
                    death.Play();

                    Thread.Sleep(2000);

                    player.lives--;

                    gameTimer.Enabled = false;

                    if(player.lives == 0)
                    {
                        Form1.ChangeScreen(this, "NameScreen");
                    }
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
            // set yello for drawing pac-man
            sb.Color = Color.Yellow;

            // draw lives
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
