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
    public partial class Flappy : Form
    {

        int pipeSpeed = 6; // default pipe speed 
        int gravity = 10; // default gravity speed 
        int score = 0; // default score 
        public static int S = 0;
        public static bool isitover = false;


        public Flappy()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity; // link the flappy bird picture box to the gravity
            pipeBottom.Left -= pipeSpeed; 
            pipeTop.Left -= pipeSpeed;
            pipeBottom2.Left -= pipeSpeed;
            pipeTop2.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;
            

            if (pipeBottom.Left < -180)
            {
                // reset
                pipeBottom.Left = 460;
                score++;
            }
            if (pipeTop.Left < -210)
            {
                // reset
                pipeTop.Left = 460;
                score++;
            }

            if (pipeBottom2.Left < -180)
            {
                // reset
                pipeBottom2.Left = 460;
                score++;
            }
            if (pipeTop2.Left < -210)
            {
                // reset
                pipeTop2.Left = 460;
                score++;
            }



            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Bounds.IntersectsWith(pipeBottom2.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop2.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -15)
            {
                endGame();
            }

            if (score > 4)
            {
                pipeSpeed = 10;
            }

            if (score > 10)
            {
                pipeSpeed = 16;
            }

            if (score > 15)
            {
                pipeSpeed = 25;
            }

        }

        private void gameKeyisdown(object sender, KeyEventArgs e)
        {        
            if (e.KeyCode == Keys.Z)
            {
                // if the space key is pressed then the gravity will be set to -15
                gravity = -5;
            }
        }

        private void gameKeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                // if the space key is released then gravity is set back to 15
                gravity = 5 ;
            }
        }
        
        private void endGame()
        {
            gameTimer.Stop();
            S = (score / 4) ;
            MessageBox.Show(" You Got " + S + " STARS ", " Game over!!!");
            isitover = true;
            this.Close();

            
        }

        private void Flappy_Load(object sender, EventArgs e)
        {

        }
    }
}
