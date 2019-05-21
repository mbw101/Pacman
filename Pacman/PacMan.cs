using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman
{
    public class PacMan
    {
        public Rectangle rect;
        private int xSpeed, ySpeed;
        public int lives;

        public PacMan(int _x, int _y, int _size, int _xSpeed, int _ySpeed, int _lives)
        {
            rect.X = _x;
            rect.Y = _y;
            rect.Width = _size;
            rect.Height = _size;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            lives = _lives;
        }

        public void move()
        {
            rect.X += xSpeed;
            rect.Y += ySpeed;
        }

        public void move(int _xSpeed, int _ySpeed)
        {
            rect.X += _xSpeed;
            rect.Y += _ySpeed;
        }

        public void setSpeed(int _xSpeed, int _ySpeed)
        {
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
        }

        public int getXSpeed()
        {
            return xSpeed;
        }

        public int getYSpeed()
        {
            return ySpeed;
        }

        public void setPosition(int _x, int _y)
        {
            rect.X = _x;
            rect.Y = _y;
        }

        public bool collision(Pellet p)
        {
            if (rect.IntersectsWith(p.rect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
