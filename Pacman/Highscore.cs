using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Highscore
    {
        public string name;
        public int score;

        public Highscore(string _name, int _score)
        {
            name = _name;
            score = _score;
        }
    }
}
