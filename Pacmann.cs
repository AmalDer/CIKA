using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOARD_GAME
{
    public partial class Pacmann : Form
    {

        bool goup, godown, goleft, goright;
        public static bool isGameOver;
        

        int playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;
        public static int score, scorefinal = score;

        private void Pacmann_Load(object sender, EventArgs e)
        {

        }

        public Pacmann()
        {
            InitializeComponent();

            resetGame();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode==Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if(e.KeyCode==Keys.Enter && isGameOver==true)
            {
                resetGame();
            }
        }

        private void maingameTimer(object sender, EventArgs e)
        {

            txtScore.Text = "Score: " + score;

            if(goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = BOARD_GAME.Properties.Resources.leftr;
            }
            if (goright== true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = BOARD_GAME.Properties.Resources.rightr;
            }
            if (godown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = BOARD_GAME.Properties.Resources.downr;
            }
            if (goup == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = BOARD_GAME.Properties.Resources.upr;
            }

            if(pacman.Left < -10)
            {
                pacman.Left = 816;
            }
            if (pacman.Left > 816)
            {
                pacman.Left = -5;
            }

            if (pacman.Top < -10)
            {
                pacman.Top = 489;
            }
            if (pacman.Top > 489)
            {
                pacman.Top = 0;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag=="coin" && x.Visible==true)
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }

                    if((string)x.Tag=="wall")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            scorefinal = 0;
                            gameOver("Oups! Vous avez échoué!");
                            
                        }

                        if(pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }


                    }

                    if((string)x.Tag=="ghost")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            scorefinal = 0;
                            gameOver("Oups! Vous avez échoué!");
                        }
                    }
                }
            }

            redGhost.Left += redGhostSpeed;

            if(redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowGhost.Left -= yellowGhostSpeed;

            if (yellowGhost.Bounds.IntersectsWith(pictureBox2.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;

            if(pinkGhost.Top<0 || pinkGhost.Top>489)
            {
                pinkGhostY = -pinkGhostY;
            }
            if (pinkGhost.Left < 0 || pinkGhost.Top > 816)
            {
                pinkGhostX = -pinkGhostX;
            }



            if (score==46) //46 le nombre de coin que j'ai
            {
                scorefinal = 1;
                gameOver("Vous avez gagné!");
                
            }
        }

        private void resetGame()
        {

            txtScore.Text = "Score: 0";
            score = 0;

            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 10;

            isGameOver = false;

            pacman.Left = 10;
            pacman.Top = 33;

            redGhost.Left = 222;
            redGhost.Top = 43;

            yellowGhost.Left = 522;
            yellowGhost.Top = 347;

            pinkGhost.Left =566;
            pinkGhost.Top =175;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gameTimer.Start();
        }

        private void gameOver(string message)
        {

            isGameOver = true;

            gameTimer.Stop();

            txtScore.Text += "Score: " + score + Environment.NewLine + message;
            this.Close();


        }
    }
}
