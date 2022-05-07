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
    public partial class Egg : Form
    {
        bool goleft; // this boolean will be used to check if the player can move left
        bool goright; // this boolean will be used to check if the player can move right
        int speed = 8; // speed for the Eggs dropping
        int score = 0; //score value
        int missed = 0; //miss value
        Random rndY = new Random(); //random Y location
        Random rndX = new Random(); //random X location
        PictureBox splash = new PictureBox(); // create a new splash picture box, this will added dynamically
        public static int S = 0; //Stars number
        public static bool isitover=false;

    public Egg()
        {
            InitializeComponent();   
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            label1.Text = "Eggs Caught: " + score; 
            label2.Text = "Eggs Missed: " + missed; 


            if (goleft == true && chicken.Left > 0)
            {
                chicken.Left -= 12;
                chicken.Image = BOARD_GAME.Properties.Resources.chicken_normal2;
            }

            if (goright == true && chicken.Left + chicken.Width < this.ClientSize.Width)
            {
                chicken.Left += 12;
                chicken.Image = BOARD_GAME.Properties.Resources.chicken_normal;
            }


            foreach (Control X in this.Controls)
            {
                if (X is PictureBox && (string)X.Tag == "Eggs")

                {
                    // then move X towards the bottom
                    X.Top += speed;

                    // if the EGGS [X] reaches bottom of the screen
                    if (X.Top + X.Height > this.ClientSize.Height)
                    {
                        // if the egg hit the floor then we show the splash image
                        splash.Image = BOARD_GAME.Properties.Resources.splash; 
                        splash.Location = X.Location; 
                        splash.Height = 59; 
                        splash.Width = 60; 
                        splash.BackColor = System.Drawing.Color.Transparent; 

                        this.Controls.Add(splash); // add the splash picture to the form

                        X.Top = rndY.Next(80, 300) * -1; // position the eggs to a random Y location
                        X.Left = rndX.Next(5, this.ClientSize.Width - X.Width); // position the eggs to a random X location
                        missed++; 
                        chicken.Image = BOARD_GAME.Properties.Resources.chicken_hurt; 
                    }


                    if (X.Bounds.IntersectsWith(chicken.Bounds))
                    {
                        X.Top = rndY.Next(100, 300) * -1; 
                        X.Left = rndX.Next(5, this.ClientSize.Width - X.Width); 
                        score++; 
                    }

                    
                    if (score >= 20)
                    {
                        speed = 16; 
                    }

                    if (missed > 5)
                    {
                        S = score / 5;
                        GameTimer.Stop(); // stop the game timer
                        // show the message box to say game is over. 
                        MessageBox.Show("Game Over!! We lost good Eggs" + "\r\n" + "You earned "+S+" STARS ");
                        isitover = true;
                        this.Close();
                        
                    }

                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                // if the left key is pressed change the go left to true
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                // if the right key is pressed change the go right to true
                goright = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                // if the left key is up then change the go left to false
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                // if the right key is up then change the go right to false
                goright = false;
            }
        }

        private void Egg_Load(object sender, EventArgs e)
        {

        }
    }
}
