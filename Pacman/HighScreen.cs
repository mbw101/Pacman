using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Pacman
{
    public partial class HighScreen : UserControl
    {
        public static List<Highscore> highscores = new List<Highscore>();
        public static List<int> scores = new List<int>();
        public static List<string> initials = new List<string>();

        public HighScreen()
        {
            InitializeComponent();

            displayHighscores();
        }

        public void loadHighscores()
        {
            XmlReader reader = XmlReader.Create("Resources/highscores.xml");

            while (reader.Read())
            {
                string name;
                string score;

                reader.ReadToFollowing("name");
                name = reader.ReadString();
                reader.ReadToFollowing("score");
                score = reader.ReadString();

                if (score != "")
                {
                    int scoreInt = Convert.ToInt32(score);

                    scores.Add(scoreInt);
                    initials.Add(name);

                    scores.Sort();

                    Highscore hs = new Highscore(name, scoreInt);

                    highscores.Add(hs);
                }
            }

            highscores = highscores.OrderByDescending(x => x.score).ThenBy(x => x.name).ToList();

            reader.Close();
        }

        public void saveHighscores()
        {
            // TODO: Save highscores
        }

        public void displayHighscores()
        {
            loadHighscores();

            for (int i = 0; i < highscores.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                        score1Label.Text = highscores[i].score.ToString();
                        initial1Label.Text = highscores[i].name;
                        break;
                    case 1:
                        score2Label.Text = highscores[i].score.ToString();
                        initial2Label.Text = highscores[i].name;
                        break;
                    case 2:
                        score3Label.Text = highscores[i].score.ToString();
                        initial3Label.Text = highscores[i].name;
                        break;
                    case 3:
                        score4Label.Text = highscores[i].score.ToString();
                        initial4Label.Text = highscores[i].name;
                        break;
                    case 4:
                        score5Label.Text = highscores[i].score.ToString();
                        initial5Label.Text = highscores[i].name;
                        break;
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, "MenuScreen");
        }

        private void backButton_Leave(object sender, EventArgs e)
        {
            backButton.BackColor = Color.Black;
        }

        private void backButton_Enter(object sender, EventArgs e)
        {
            backButton.BackColor = Color.DimGray;
        }
    }
}
