using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using SNAKE_GAME;
using WMPLib;




namespace BOARD_GAME
{
    
    
    public partial class THE_BOARD : Form
    {




        WindowsMediaPlayer player = new WindowsMediaPlayer();
        int compteur = 0, stars = 0;
        
        Random r2 = new Random();
        int[] locations_x = { 33, 33, 33, 33, 33, 33, 33, 108, 183, 285, 333, 408, 483, 558, 633, 708, 708, 708, 708, 708, 708, 633, 558, 483, 408, 333, 333, 333, 333, 408};
        int[] locations_y = { 539, 458, 377, 296, 215, 135, 54, 54, 54, 54, 54, 54, 54, 54, 54, 54, 135, 216, 297, 378, 459, 459, 459, 459, 459, 459, 378, 297, 216, 216 };
        public THE_BOARD()
        {
            
            InitializeComponent();
            player.URL = "soundtrack.mp3";
        }
        private void Treasure(int x, int y)
        {
            if (x == locations_x[4] && y == locations_y[4] || y == locations_y[10] && x == locations_x[10] || y == locations_y[12] && x == locations_x[12] || y == locations_y[16] && x == locations_x[16] || y == locations_y[18] && x == locations_x[18])
            {
                int treasure = r2.Next(0, 8);
                if (treasure == 0)
                {
                    MessageBox.Show("Nice! You are going to move forwards by 3 spaces", "Treasure");

                    x = locations_x[compteur + 3];
                    y = locations_y[compteur + 3];
                    pictureBox1.Location = new Point(x, y);
                    compteur += 3;

                }
                if (treasure == 1)
                {
                    MessageBox.Show("Nice! You are going to move forwards by 2 space", "Treasure");

                    x = locations_x[compteur + 2];
                    y = locations_y[compteur + 2];
                    pictureBox1.Location = new Point(x, y);
                    compteur += 2;

                }
                if (treasure == 2)
                {
                    MessageBox.Show("Nice! You are going to move forwards by 1 space", "Treasure");

                    x = locations_x[compteur + 1];
                    y = locations_y[compteur + 1];
                    pictureBox1.Location = new Point(x, y);
                    compteur += 1;

                }
                if (treasure == 3)
                {
                    MessageBox.Show("Nice! You gain 5 stars.", "Treasure");
                    stars += 5;
                    label1.Text = stars + " Stars.";

                }
                if (treasure == 4)
                {
                    MessageBox.Show("Nice! You gain 4 stars.", "Treasure");
                    stars += 4;
                    label1.Text = stars + " Stars.";

                }
                if (treasure == 5)
                {
                    MessageBox.Show("Nice! You gain 3 stars.", "Treasure");
                    stars += 3;
                    label1.Text = stars + " Stars.";

                }
                if (treasure == 6)
                {
                    MessageBox.Show("Nice! You gain 2 stars.", "Treasure");
                    stars += 2;
                    label1.Text = stars + " Stars.";

                }
                if (treasure == 7)
                {
                    MessageBox.Show("Nice! You gain 1 star.", "Treasure");
                    stars += 1;
                    label1.Text = stars + " Stars.";

                }


            }
        }

        private void MiniGames(int x, int y)
        {
            if (x == 408 && y == 54)
            {
                Pacmann g3 = new Pacmann();
                g3.ShowDialog();
                if (Pacmann.isGameOver)
                {
                    stars += Pacmann.scorefinal;
                    MessageBox.Show("You have gained " + Pacmann.scorefinal + " stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == 708 && y == 54)
            {
                Puzzle g4 = new Puzzle();
                g4.ShowDialog();
                if (Puzzle.isitover)
                {
                    stars += Puzzle.S;
                    MessageBox.Show("You have gained  " + Puzzle.S + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == 708 && y == 459)
            {
                Flappy g5 = new Flappy();
                g5.ShowDialog();
                if (Flappy.isitover)
                {
                    stars += Flappy.S;
                    MessageBox.Show("You have gained  " + Flappy.S + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == locations_x[5] && y == locations_y[5])
            {
                Quiz1 q1 = new Quiz1();
                q1.ShowDialog();
                if (Quiz1.isitover)
                {
                    stars += ((Quiz1.percentage) * 2) / 100;
                    MessageBox.Show("You have gained  " + ((Quiz1.percentage) * 2) / 100 + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == locations_x[9] && y == locations_y[9])
            {
                Quiz2 q2 = new Quiz2();
                q2.ShowDialog();
                if (Quiz2.isitover)
                {
                    stars += ((Quiz2.percentage) * 2) / 100;
                    MessageBox.Show("You have gained  " + ((Quiz2.percentage) * 2) / 100 + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == locations_x[17] && y == locations_y[17])
            {
                Quiz3 q3 = new Quiz3();
                q3.ShowDialog();
                if (Quiz3.isitover)
                {
                    stars += ((Quiz3.percentage) * 2) / 100;
                    MessageBox.Show("You have gained  " + ((Quiz3.percentage) * 2) / 100 + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == locations_x[19] && y == locations_y[19])
            {
                Quiz4 q4 = new Quiz4();
                q4.ShowDialog();
                if (Quiz4.isitover)
                {
                    stars += ((Quiz4.percentage) * 2) / 100;
                    MessageBox.Show("You have gained  " + ((Quiz4.percentage) * 2) / 100 + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == 558 && y == 459)
            {
                Egg g6 = new Egg();
                g6.ShowDialog();
                if (Egg.isitover)
                {
                    stars += Egg.S;
                    MessageBox.Show("You have gained  " + Egg.S + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == locations_x[24] && y == locations_y[24])
            {
                Shooter g7 = new Shooter();
                g7.ShowDialog();
                if (Shooter.isitover)
                {
                    stars += (Shooter.score) / 2;
                    MessageBox.Show("You have gained  " + (Shooter.score) / 2 + "  stars");
                    label1.Text = stars + " Stars.";
                }

            }
            if (x == 33 && y == 296)
            {
                SnakeGame g1 = new SnakeGame();
                g1.ShowDialog();
                if (SnakeGame.isitover)
                {
                    stars += (SnakeGame.finalScore) / 50;
                    MessageBox.Show("You have gained  " + (SnakeGame.finalScore) / 50 + "  stars");
                    label1.Text = stars + " Stars.";
                }
            }
        }
        private void SafetyZone(int x, int y)
        {
            if (x == locations_x[1] && y == locations_y[1] || y == locations_y[7] && x == locations_x[7] || y == locations_y[13] && x == locations_x[13] || y == locations_y[21] && x == locations_x[21] || y == locations_y[23] && x == locations_x[23])
            {
                MessageBox.Show("Congratulations, you are safe for this round.", "Safety Zone");


            }
        }

        private void DangerZone(int x, int y)
        {
            if (y == locations_y[8] && x == locations_x[8] || y == locations_y[14] && x == locations_x[14] || y == locations_y[25] && x == locations_x[25] || y == locations_y[26] && x == locations_x[26] || y == locations_y[27] && x == locations_x[27])
            {
                int danger1 = r2.Next(0, 8);
                if (danger1 == 0)
                {
                    MessageBox.Show("Uh-oh! You must move backwards by 3 spaces", "Danger Zone");
                    x = locations_x[compteur - 3];
                    y = locations_y[compteur - 3];
                    pictureBox1.Location = new Point(x, y);
                    compteur -= 3;

                }
                if (danger1 == 1)
                {
                    MessageBox.Show("Uh-oh! You must move backwards by 2 spaces", "Danger Zone");

                    x = locations_x[compteur - 2];
                    y = locations_y[compteur - 2];
                    pictureBox1.Location = new Point(x, y);
                    compteur -= 2;

                }
                if (danger1 == 2)
                {
                    MessageBox.Show("Uh-oh! You must move backwards by 1 space", "Danger Zone");

                    x = locations_x[compteur - 1];
                    y = locations_y[compteur - 1];
                    pictureBox1.Location = new Point(x, y);
                    compteur -= 1;

                }
                if (danger1 == 3)
                {
                    MessageBox.Show("Uh-oh! You lose 5 stars.", "Danger Zone");
                    stars -= 5;
                    label1.Text = stars + " Stars.";

                }
                if (danger1 == 4)
                {
                    MessageBox.Show("Uh-oh! You lose 4 stars.", "Danger Zone");
                    stars -= 4;
                    label1.Text = stars + " Stars.";

                }
                if (danger1 == 5)
                {
                    MessageBox.Show("Uh-oh! You lose 3 stars.", "Danger Zone");
                    stars -= 3;
                    label1.Text = stars + " Stars.";

                }
                if (danger1 == 6)
                {
                    MessageBox.Show("Uh-oh! You lose 2 stars.", "Danger Zone");
                    stars -= 2;
                    label1.Text = stars + " Stars.";

                }
                if (danger1 == 7)
                {
                    MessageBox.Show("Uh-oh! You lose 1 star.", "Danger Zone");
                    stars -= 1;
                    label1.Text = stars + " Stars.";

                }




            }

            if (x == 33 && y == 377)
            {
                int danger2 = r2.Next(0, 7);
                if (danger2 == 0)
                {
                    MessageBox.Show("Uh-oh! You must move backwards by 2 spaces", "Danger Zone");

                    x = locations_x[compteur - 2];
                    y = locations_y[compteur - 2];
                    pictureBox1.Location = new Point(x, y);
                    compteur -= 2;

                }
                if (danger2 == 1)
                {
                    MessageBox.Show("Uh-oh! You must move backwards by 1 space", "Danger Zone");

                    x = locations_x[compteur - 1];
                    y = locations_y[compteur - 1];
                    pictureBox1.Location = new Point(x, y);
                    compteur -= 1;

                }
                if (danger2 == 2)
                {
                    MessageBox.Show("Uh-oh! You lose 5 stars.", "Danger Zone");
                    stars -= 5;
                    label1.Text = stars + " Stars.";

                }
                if (danger2 == 3)
                {
                    MessageBox.Show("Uh-oh! You lose 4 stars.", "Danger Zone");
                    stars -= 4;
                    label1.Text = stars + " Stars.";

                }
                if (danger2 == 4)
                {
                    MessageBox.Show("Uh-oh! You lose 3 stars.", "Danger Zone");
                    stars -= 3;
                    label1.Text = stars + " Stars.";

                }
                if (danger2 == 5)
                {
                    MessageBox.Show("Uh-oh! You lose 2 stars.", "Danger Zone");
                    stars -= 2;
                    label1.Text = stars + " Stars.";

                }
                if (danger2 == 6)
                {
                    MessageBox.Show("Uh-oh! You lose 1 star.", "Danger Zone");
                    stars -= 1;
                    label1.Text = stars + " Stars.";

                }


            }
        }
        private void Clown(int x, int y)
        {
            if (x == 333 && y == 216)
            {
                MessageBox.Show("HAHAHAHAHAHAHAHAHAHAHA. You are a clown!");
                x = locations_x[0];
                y = locations_y[0];
                pictureBox1.Location = new Point(x, y);
                compteur = 0;



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stars = 0;
            compteur = 0;
            pictureBox1.Location = new Point(33, 539);
            label1.Text = stars + " Stars.";
        }

        private void THE_BOARD_Load(object sender, EventArgs e)
        {
            player.controls.play();
        }

        private void CmdStart_Click(object sender, EventArgs e)
        {
            Random r1 = new Random();
            int x = pictureBox1.Location.X, y = pictureBox1.Location.Y;


            int dice = r1.Next(1, 6);
            if (dice == 1)
            {
                pictureBox38.Image = Properties.Resources.dice1;
                compteur += 1;
                if (compteur < 29)
                {
                    x = locations_x[compteur];
                    y = locations_y[compteur];
                    pictureBox1.Location = new Point(x, y);

                }
                else
                {
                    x = 408;
                    y = 219;
                    pictureBox1.Location = new Point(x, y);
                    MessageBox.Show("Congratulations, you won!", "WINNER");
                }
            }
            else if (dice == 2)
            {
                pictureBox38.Image = Properties.Resources.dice2;
                compteur += 2;
                if (compteur < 29)
                {
                    x = locations_x[compteur];
                    y = locations_y[compteur];
                    pictureBox1.Location = new Point(x, y);

                }
                else
                {
                    x = 408;
                    y = 219;
                    pictureBox1.Location = new Point(x, y);
                    MessageBox.Show("Congratulations, you won!", "WINNER");
                }
            }

            else if (dice == 3)
            {
                pictureBox38.Image = Properties.Resources.dice3;
                compteur += 3;
                if (compteur < 29)
                {
                    x = locations_x[compteur];
                    y = locations_y[compteur];
                    pictureBox1.Location = new Point(x, y);

                }
                else
                {
                    x = 408;
                    y = 219;
                    pictureBox1.Location = new Point(x, y);
                    MessageBox.Show("Congratulations, you won!", "WINNER");
                }
            }

            else if (dice == 4)
            {
                pictureBox38.Image = Properties.Resources.dice4;
                compteur += 4;
                if (compteur < 29)
                {
                    x = locations_x[compteur];
                    y = locations_y[compteur];
                    pictureBox1.Location = new Point(x, y);

                }
                else
                {
                    x = 408;
                    y = 219;
                    pictureBox1.Location = new Point(x, y);
                    MessageBox.Show("Congratulations, you won!", "WINNER");
                }
            }

            else if (dice == 5)
            {
                pictureBox38.Image = Properties.Resources.dice5;
                compteur += 5;
                if (compteur < 29)
                {
                    x = locations_x[compteur];
                    y = locations_y[compteur];
                    pictureBox1.Location = new Point(x, y);

                }
                else
                {
                    x = 408;
                    y = 219;
                    pictureBox1.Location = new Point(x, y);
                    MessageBox.Show("Congratulations, you won!", "WINNER");
                }



            }
            Clown(x, y);
            Treasure(x, y);
            DangerZone(x, y);
            SafetyZone(x, y);
            MiniGames(x, y);

        }








    }
}
