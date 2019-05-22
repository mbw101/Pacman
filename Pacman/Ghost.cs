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
        public Color colour;
        private string behavior;

        public Ghost(int _x, int _y, int _size, int _xSpeed, int _ySpeed, string _behavior, Color _colour)
        {
            rect.X = _x;
            rect.Y = _y;
            rect.Width = _size;
            rect.Height = _size;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            behavior = _behavior;
            colour = _colour;
        }

        public void move(PacMan player)
        {
            rect.X += player.getYSpeed();
            rect.Y += player.getXSpeed();
        }

        public void setSpeed(int _xSpeed, int _ySpeed)
        {
            xSpeed += _xSpeed;
            ySpeed += _ySpeed;
        }

        public void setPosition(int _x, int _y)
        {
            rect.X = _x;
            rect.Y = _y;
        }

        // TODO: In game loop when ghost collides with wall,
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
