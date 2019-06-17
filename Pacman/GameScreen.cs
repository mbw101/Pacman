﻿using System;
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
using System.IO;

/*
 * Avery and Malcolm
 * Pac-man
 * June 14th, 2019
 * */

namespace Pacman
{
    public partial class GameScreen : UserControl
    {
        // movement speed
        public const int SPEED = 3;
        public const int GHOST_SPEED = 2;
        public const int GHOST_EAT_SPEED = 1;
        public const int startX = 384; 
        public const int startY = 100; // 336
        public static int score = 0;

        const int ghostX = 380;
        const int ghostY = 196;
        const int ghostBoxX = 370;
        const int ghostBoxY = 265;

        // characters
        PacMan player = new PacMan(startX, startY, 32, -SPEED, 0, 3);
        Font textFont;

        // sounds
        SoundPlayer death = new SoundPlayer(Properties.Resources.pacman_death);
        System.Windows.Media.MediaPlayer munch = new System.Windows.Media.MediaPlayer();

        List<Pellet> pellets = new List<Pellet>();
        List<PowerPellet> powerPellets = new List<PowerPellet>();
        List<Pellet> removePellets = new List<Pellet>();
        List<PowerPellet> removePowerPellets = new List<PowerPellet>();
        List<Wall> walls = new List<Wall>();
        List<Ghost> ghosts = new List<Ghost>();

        int counter = 0;
        int previousCounter = 0;
        bool animate = false, collided = false;
        int tmpXSpeed, tmpYSpeed;
        int edibleCounter = 0;
        int ghostWaitCounter = 0;

        // pens, brushes, graphics
        SolidBrush sb = new SolidBrush(Color.Yellow);

        // player controls
        Boolean WDown, ADown, SDown, DDown;

        public GameScreen()
        {
            InitializeComponent();

            // create text graphics
            textFont = new Font("Verdana", 18, FontStyle.Regular);

            // create munch sound
            munch.Open(new Uri(Application.StartupPath + "/Resources/pacman_chomp.wav"));

            initLevel();
        }

        public void createPellets()
        {
            // create pellets
            #region Pellets
            for (int i = 1; i < 6; i++)
            {
                Pellet p = new Pellet(12 + (i * 20), 46, 10, 10, Color.Yellow);
                pellets.Add(p);
            }

            PowerPellet pp = new PowerPellet(128, 40, 20, 50, Color.Wheat);
            powerPellets.Add(pp);
            PowerPellet pp2 = new PowerPellet(50, 500, 20, 50, Color.Wheat);
            powerPellets.Add(pp2);
            PowerPellet pp3 = new PowerPellet(760, 42, 20, 50, Color.Wheat);
            powerPellets.Add(pp3);
            PowerPellet pp4 = new PowerPellet(758, 372, 20, 50, Color.Wheat);
            powerPellets.Add(pp4);

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
            for (int i = 1; i < 15; i++)
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
            for (int i = 1; i < 6; i++)
            {
                Pellet p = new Pellet(55, 385 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 1; i < 35; i++)
            {
                Pellet p = new Pellet(55 + (i * 20), 505, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 18; i++)
            {
                Pellet p = new Pellet(295, 480 - (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 28; i++)
            {
                Pellet p = new Pellet(150 + (i * 20), 105, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(199, 85 - (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 20; i++)
            {
                Pellet p = new Pellet(215 + (i * 20), 45, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 2; i++)
            {
                Pellet p = new Pellet(592, 68 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 2; i++)
            {
                Pellet p = new Pellet(396, 68 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(155 + (i * 20), 178, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 18; i++)
            {
                Pellet p = new Pellet(497, 132 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 13; i++)
            {
                Pellet p = new Pellet(200, 202 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 2; i++)
            {
                Pellet p = new Pellet(152 + (i * 20), 274, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 2; i++)
            {
                Pellet p = new Pellet(152 + (i * 20), 400, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(222 + (i * 20), 278, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(222 + (i * 20), 441, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 8; i++)
            {
                Pellet p = new Pellet(320 + (i * 20), 212, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 8; i++)
            {
                Pellet p = new Pellet(320 + (i * 20), 345, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 8; i++)
            {
                Pellet p = new Pellet(320 + (i * 20), 439, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 9; i++)
            {
                Pellet p = new Pellet(520 + (i * 20), 272, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(398, 373 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 5; i++)
            {
                Pellet p = new Pellet(592, 179 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 8; i++)
            {
                Pellet p = new Pellet(595, 298 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(520 + (i * 20), 441, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 4; i++)
            {
                Pellet p = new Pellet(694 + (i * 20), 43, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 8; i++)
            {
                Pellet p = new Pellet(762, 68 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 10; i++)
            {
                Pellet p = new Pellet(663, 298 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 7; i++)
            {
                Pellet p = new Pellet(663, 132 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(665, 46 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 2; i++)
            {
                Pellet p = new Pellet(618 + (i * 20), 399, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 2; i++)
            {
                Pellet p = new Pellet(621 + (i * 20), 178, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 4; i++)
            {
                Pellet p = new Pellet(697 + (i * 20), 330, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 4; i++)
            {
                Pellet p = new Pellet(762, 354 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 5; i++)
            {
                Pellet p = new Pellet(735, 410 + (i * 20), 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            for (int i = 0; i < 3; i++)
            {
                Pellet p = new Pellet(695 + (i * 20), 220, 10, 10, Color.Yellow);
                pellets.Add(p);
            }
            #endregion 
        }

            

        public void createWalls()
        {
            // create walls
            #region walls
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
            Wall w40 = new Wall(152, 132, 130, 32, Color.White);
            Wall w41 = new Wall(520, 132, 130, 32, Color.White);
            Wall w42 = new Wall(222, 164, 60, 96, Color.White);
            Wall w43 = new Wall(520, 164, 60, 96, Color.White);
            Wall w44 = new Wall(222, 70, 158, 22, Color.White);
            Wall w45 = new Wall(420, 70, 158, 22, Color.White);
            Wall w46 = new Wall(320, 132, 160, 60, Color.White);

            // add walls to the list
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
            #endregion
        }

        public void initLevel()
        {
            // reset score
            score = 0;

            // set the temp x and y of pacman
            tmpXSpeed = player.getXSpeed();
            tmpYSpeed = player.getYSpeed();

            createPellets();

            // create ghosts
            Ghost g = new Ghost(ghostX, ghostY, 32, -GHOST_SPEED, 0, 200, "aggressive", Color.Red);
            Ghost g2 = new Ghost(ghostBoxX, ghostBoxY, 32, GHOST_SPEED, 0, 200, "patrol", Color.Lime);
            ghosts.Clear();
            ghosts.Add(g);
            ghosts.Add(g2);

            createWalls();
        }

        // does this after all pellets are cleared
        public void resetLevel()
        {
            // set the temp x and y of pacman
            tmpXSpeed = player.getXSpeed();
            tmpYSpeed = player.getYSpeed();

            createPellets();

            // create ghosts
            Ghost g = new Ghost(ghostX, ghostY, 32, GHOST_SPEED, 0, 200, "aggressive", Color.Red);
            Ghost g2 = new Ghost(ghostBoxX, ghostBoxY, 32, GHOST_SPEED, 0, 200, "patrol", Color.Lime);
            ghosts.Clear();
            ghosts.Add(g);
            ghosts.Add(g2);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // create a temporary location of pac-man
            int tempX = player.rect.X;
            int tempY = player.rect.Y;

            // portal code for when he goes
            // through a portal
            if (tempX < -32)
            {
                tempX = 780;
            }
            else if (tempX > 800)
            {
                tempX = 3;
            }

            // set position to temp positions
            player.setPosition(tempX, tempY);

            int tempX2 = ghosts[0].rect.X;
            int tempY2 = ghosts[0].rect.Y;
            int tempX3 = ghosts[1].rect.X;
            int tempY3 = ghosts[1].rect.Y;

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
                // increase counter for the green ghost to enter arena
                ghostWaitCounter++;

                // move the ghost if red or if the green is ready to leave arena
                if ((g == ghosts[1] && ghostWaitCounter > 60 * 5))
                {
                    // move ghost outside of box
                    if ((g.rect.X == ghostBoxX) && (g.rect.Y == ghostBoxY))
                    {
                        g.setPosition(ghostX, ghostY);
                    }

                    g.move(player);
                }
                else if (g == ghosts[0])
                {
                    g.move(player);
                }

                if (player.Collision(g) && !g.edible)
                {
                    // play death sound
                    death.Play();

                    Thread.Sleep(2000);

                    // decrease lives
                    player.lives--;

                    // set position back to original
                    player.setPosition(startX, startY);

                    // reset green ghost timer
                    ghostWaitCounter = 0;

                    // reset ghosts positions
                    ghosts[0].setPosition(ghostX, ghostY);
                    ghosts[0].setSpeed(-GHOST_SPEED, 0);

                    ghosts[1].setPosition(ghostBoxX, ghostBoxY);
                    ghosts[1].setSpeed(GHOST_SPEED, 0);

                    // if there are no more lives
                    // go to namescreen
                    if (player.lives == 0)
                    {
                        // change to the namescreen
                        Form1.ChangeScreen(this, "NameScreen");
                        gameTimer.Enabled = false;
                    }
                }
                else if (player.Collision(g) && g.edible)
                {
                    // when the ghost is eaten,
                    // add the ghosts score and reset everything about that ghost
                    score += g.score;
                    Thread.Sleep(250);

                    // reset counter if green ghost
                    if (g == ghosts[1])
                    {
                        ghostWaitCounter = 0;
                    }

                    // red ghost
                    if (g == ghosts[0])
                    {
                        g.setPosition(ghostX, ghostY);
                        g.setSpeed(-GHOST_SPEED, 0);
                    }
                    // green ghost
                    else
                    {
                        g.setPosition(ghostBoxX, ghostBoxY);
                        g.setSpeed(GHOST_SPEED, 0);
                    }             

                    g.edible = false;
                }

                foreach (Wall wall in walls)
                {
                    if (g.collision(wall))
                    {
                        // run the collision method of the ghost
                        // when it hits a wall
                        if (g == ghosts[0])
                        {
                            g.changeDirection(player, tempX2, tempY2);
                        }
                        else
                        {
                            g.changeDirection(player, tempX3, tempY3);
                        }
                    }
                }

                //edible timer
                if (g.edible == true)
                {
                    edibleCounter++;
                    if (edibleCounter >= 30 * 16)
                    {
                        ghosts[0].edible = ghosts[1].edible = false;
                        edibleCounter = 0;
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

                    munch.Play();
                    
                    score += p.score;
                }
            }

            // If any power pellets are collided
            // then remove it, add score, and make ghosts edible
            foreach (PowerPellet pp in powerPellets)
            {
                // check collision
                if (player.Collision(pp))
                {
                    removePowerPellets.Add(pp);

                    score += pp.score;

                    foreach (Ghost g in ghosts)
                    {
                        g.edible = true;
                   
                    }                   
                }
            }

            // remove all pellets that have to be removed
            foreach (Pellet p in removePellets)
            {
                pellets.Remove(p);
            }

            // remove power pellets
            foreach (PowerPellet pp in removePowerPellets)
            {
                powerPellets.Remove(pp);
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

            // reset level when all pellets are gone
            if (pellets.Count == 0 && powerPellets.Count == 0)
            {
                resetLevel();
            }

            Refresh();
        }

        #region Draw Methods weehaw
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

            // draw power pellets
            foreach (PowerPellet pp in powerPellets)
            {
                sb.Color = pp.colour;

                e.Graphics.FillEllipse(sb, pp.rect);
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
                
                if (g.edible == true)
                {
                    sb.Color = Color.DodgerBlue;
                }

                e.Graphics.FillRectangle(sb, g.rect);
            }

            // draw score
            sb.Color = Color.White;
            e.Graphics.DrawString("Score: " + score, textFont, sb, new Point(500, Height - 40));
        }
        #endregion
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    ADown = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    DDown = true;
                    break;
                case Keys.W:
                case Keys.Up:
                    WDown = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    SDown = true;
                    break;
                case Keys.C:
                    // only load highscores if there aren't any in the list 
                    if (HighScreen.highscores == null)
                    {
                        HighScreen.loadHighscores();
                    }

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
                case Keys.Left:
                    ADown = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    DDown = false;
                    break;
                case Keys.W:
                case Keys.Up:
                    WDown = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    SDown = false;
                    break;
                default:
                    break;
            }
        }
    }
}
