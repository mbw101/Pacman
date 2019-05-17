using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pacman
{
    public class Pellet
    {
        private Rectangle rect;
        private int score;
        public Color colour;

        public Pellet(int _x, int _y, int _size, int _score, Color _colour)
        {
            rect.X = _x;
            rect.Y = _y;
            rect.Width = _size;
            rect.Height = _size;
            score = _score;
            colour = _colour;
        }
    }
}
