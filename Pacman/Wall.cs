using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    public class Wall
    {
        public Rectangle rect;
        public Color colour;

        public Wall(int _x, int _y, int _width, int _height, Color _colour)
        {
            rect.X = _x;
            rect.Y = _y;
            rect.Width = _width;
            rect.Height = _height;
            colour = _colour;
        }
    }
}
