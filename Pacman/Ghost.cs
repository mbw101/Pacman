using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    public class Ghost
    {
        public Rectangle rect;
        private int xSpeed, ySpeed;
        public int score;
        public Color colour;
        private string behavior;
        public bool edible = false;
        Random randGen = new Random();

        public Ghost(int _x, int _y, int _size, int _xSpeed, int _ySpeed, int _score, string _behavior, Color _colour)
        {
            rect.X = _x;
            rect.Y = _y;
            rect.Width = _size;
            rect.Height = _size;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            behavior = _behavior;
            colour = _colour;
            score = _score;
        }

        public void move()
        {
            rect.X += xSpeed;
            rect.Y += ySpeed;
        }

        public void setSpeed(int _xSpeed, int _ySpeed)
        {
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public void setPosition(int _x, int _y)
        {
            rect.X = _x;
            rect.Y = _y;
        }

        // this method changes the direction of the ghost when he collides with a wall
        // the direction that is choosen is based on the behavior
        public void changeDirection(PacMan player, int tempX, int tempY)
        {
            if (behavior == "aggressive")
            {
                // the player is below 
                if (player.rect.Y > rect.Y)
                {
                    if (randGen.Next(0, 10) > 5)
                    {
                        xSpeed = GameScreen.GHOST_SPEED;
                        ySpeed = 0;


                        // set position back to when the ghost isn't colliding
                        setPosition(tempX, tempY);
                    }
                    else
                    {
                        if (ySpeed == 0)
                        {
                            // change direction
                            xSpeed = 0;
                            ySpeed = GameScreen.GHOST_SPEED;
                        }
                        else
                        {
                            ySpeed = -ySpeed;
                        }

                        // set position back to when the ghost isn't colliding
                        setPosition(tempX, tempY);
                    }
                }
                // the player is above the ghost
                else if (player.rect.Y <= rect.Y)
                {
                    if (randGen.Next(0, 10) > 5)
                    {
                        ySpeed = -ySpeed;
                        xSpeed = 0;

                        // set position back to when the ghost isn't colliding
                        setPosition(tempX, tempY);
                    }
                    else if (randGen.Next(0, 10) > 8)
                    {
                        xSpeed = -xSpeed;
                        ySpeed = 0;
                        // set position back to when the ghost isn't colliding
                        setPosition(tempX, tempY);
                    }
                    else
                    {
                        // pac-man is to the left
                        if (player.rect.X < rect.X)
                        {
                            ySpeed = 0;
                            xSpeed = -GameScreen.GHOST_SPEED;
                        }
                        else
                        {
                            ySpeed = 0;
                            xSpeed = GameScreen.GHOST_SPEED;
                        }

                        // set position back to when the ghost isn't colliding
                        setPosition(tempX, tempY);
                    }
                }
            }
            else if (behavior == "sneaky")
            {

            }
            if (behavior == "patrol")
            {
                xSpeed = GameScreen.GHOST_SPEED;
                ySpeed = 0;
            }
            else
            {
                xSpeed = -xSpeed;
            }
        }

        // In game loop when ghost collides with wall,
        // change the direction of the ghost, so that it is always moving
        public bool collision(Wall wall)
        {
            if (rect.IntersectsWith(wall.rect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
