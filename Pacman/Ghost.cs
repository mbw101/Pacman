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

        public void move(PacMan player)
        {
            if (behavior == "patrol")
            {
                // move the green ghost
                // up when he reaches (662, 500)
                if ((rect.X >= 655) && (rect.Y >= 490))
                {
                    xSpeed = 0;
                    ySpeed = -GameScreen.GHOST_SPEED;
                }
                else if ((rect.X >= 655) && (rect.Y <= 95))
                {
                    xSpeed = -GameScreen.GHOST_SPEED;
                    ySpeed = 0;
                }
            }
            else if (behavior == "aggressive")
            {
                if ((rect.X >= 100) && (rect.Y >= 495))
                {
                    xSpeed = GameScreen.GHOST_SPEED;
                    ySpeed = 0;
                }
                if ((rect.X >= 485) && (rect.Y >= 495))
                {
                    xSpeed = 0;
                    ySpeed = -GameScreen.GHOST_SPEED;
                }
                if ((rect.X >= 485) && (rect.Y <= 200))
                {
                    xSpeed = -GameScreen.GHOST_SPEED; 
                    ySpeed = 0;
                }
            }

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
            // for the red ghost
            if (behavior == "aggressive")
            {
                if (xSpeed == -GameScreen.GHOST_SPEED)
                {
                    xSpeed = 0;
                    ySpeed = GameScreen.GHOST_SPEED;                  
                }
                else if (ySpeed == -GameScreen.GHOST_SPEED)
                {
                    xSpeed = -GameScreen.GHOST_SPEED;
                    ySpeed = 0;
                }
                else if (ySpeed == GameScreen.GHOST_SPEED)
                {
                    xSpeed = -GameScreen.GHOST_SPEED;
                    ySpeed = 0;
                }
                else if (xSpeed == GameScreen.GHOST_SPEED)
                {
                    xSpeed = -GameScreen.GHOST_SPEED;
                    ySpeed = 0; 
                }

                // set position of ghost to temp position
                setPosition(tempX, tempY);
            }
            // for the green ghost
            else if (behavior == "patrol")
            {
                if (xSpeed == GameScreen.GHOST_SPEED)
                {
                    xSpeed = 0;
                    ySpeed = -GameScreen.GHOST_SPEED;
                }
                else if (ySpeed == -GameScreen.GHOST_SPEED)
                {
                    xSpeed = -GameScreen.GHOST_SPEED;
                    ySpeed = 0;
                }
                else if (xSpeed == -GameScreen.GHOST_SPEED)
                {
                    xSpeed = 0;
                    ySpeed = GameScreen.GHOST_SPEED;
                }
                else if (ySpeed == GameScreen.GHOST_SPEED)
                {
                    xSpeed = GameScreen.GHOST_SPEED;
                    ySpeed = 0;
                }

                // set position back to when the ghost isn't colliding
                setPosition(tempX, tempY);
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
