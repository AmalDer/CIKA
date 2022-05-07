using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNAKE_GAME
{
    public partial class SnakeGame : Form
    {
        PictureBox[] snakeParts;
        public static int finalScore;
        public static bool isitover;
        int snakeSize = 5;
        Point location = new Point(120, 120);
        string direction = "Right";
        bool changingDirection = false;
        PictureBox food = new PictureBox();
        Point foodLocation = new Point(0, 0);

        public SnakeGame()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            isitover = true;
            gamePanel.Controls.Clear();
            timer1.Interval = 55;
            snakeParts = null;
            score.Text = "00";
            snakeSize = 5;
            direction = "Right";
            location = new Point(120, 120);
            drawSnake();
            drawFood();
            timer1.Start();
            StartGame.Enabled = false;
            GiveUp.Enabled = true;


        }
        private void drawSnake()
        {
            snakeParts = new PictureBox[snakeSize];
            for(int i=0;i<snakeSize;i++)
            {
                snakeParts[i] = new PictureBox();
                snakeParts[i].Size = new Size(15, 15);
                snakeParts[i].BackColor = Color.Green;
                snakeParts[i].BorderStyle = BorderStyle.FixedSingle;
                snakeParts[i].Location = new Point(location.X - (15*i), location.Y);
                gamePanel.Controls.Add(snakeParts[i]);
            }
        }
        private void drawFood()
        {
            Random rnd = new Random(); 
            int Xrand = rnd.Next(38) * 15;
            int Yrand = rnd.Next(30) * 15;
            bool isOnSnake = true;
            while(isOnSnake)
            {
                for (int i = 0; i < snakeSize; i++)
                {
                    if(snakeParts[i].Location==new Point(Xrand, Yrand))
                    {
                        Xrand = rnd.Next(38) * 15;
                        Yrand = rnd.Next(30) * 15;

                    }
                    else
                    {
                        isOnSnake = false;
                    }
                }
            }
            if (isOnSnake == false)
            {
                foodLocation = new Point(Xrand, Yrand);
                food.Size = new Size(15, 15);
                food.BackColor = Color.Red;
                food.BorderStyle = BorderStyle.FixedSingle;
                food.Location = foodLocation;
                gamePanel.Controls.Add(food);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move();
        }

        private void move()
        {
            Point point = new Point(0, 0);
            for (int i = 0; i < snakeSize; i++)
            {
                if(i==0)
                {
                    point = snakeParts[i].Location;
                    if (direction=="Left")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X - 15, snakeParts[i].Location.Y);
                    }
                    if (direction == "Right")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X + 15, snakeParts[i].Location.Y);
                    }
                    if (direction == "Top")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X, snakeParts[i].Location.Y - 15);
                    }
                    if (direction == "Down")
                    {
                        snakeParts[i].Location = new Point(snakeParts[i].Location.X, snakeParts[i].Location.Y + 15);
                    }
                }
                else
                {
                    Point newPoint = snakeParts[i].Location;
                    snakeParts[i].Location = point;
                    point = newPoint;
                }

            }
            if(snakeParts[0].Location== foodLocation)
            {
                eatFood();
                drawFood();
            }
            if (snakeParts[0].Location.X <= 0 || snakeParts[0].Location.X >= 940 || snakeParts[0].Location.Y <= 0 || snakeParts[0].Location.Y >= 500 )
            {
                stopGame();
            }
            for (int i = 3; i< snakeSize;i++)
            {
                if(snakeParts[0].Location==snakeParts[i].Location)
                {
                    stopGame();
                }
            }



            changingDirection = false;

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Up) && direction != "Down" && changingDirection !=true)
            {
                direction = "Top";
                changingDirection = true;
            }
            if (keyData == (Keys.Down) && direction != "Top" && changingDirection != true)
            {
                direction = "Down";
                changingDirection = true;
            }
            if (keyData == (Keys.Left) && direction != "Right" && changingDirection != true)
            {
                direction = "Left";
                changingDirection = true;
            }
            if (keyData == (Keys.Right) && direction != "Left" && changingDirection != true)
            {
                direction = "Right";
                changingDirection = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void eatFood()
        {
            snakeSize++;
            PictureBox[] oldSnake = snakeParts;
            gamePanel.Controls.Clear();
            snakeParts = new PictureBox[snakeSize];
            for (int i = 0; i < snakeSize; i++)
            {
                snakeParts[i] = new PictureBox();
                snakeParts[i].Size = new Size(15, 15);
                snakeParts[i].BackColor = Color.Green;
                snakeParts[i].BorderStyle = BorderStyle.FixedSingle;
                if(i==0)
                {
                    snakeParts[i].Location = foodLocation;
                }
                else
                {
                    snakeParts[i].Location = oldSnake[i-1].Location;
                }
                gamePanel.Controls.Add(snakeParts[i]);

            }
            int currentScores = Int32.Parse(score.Text);
            int newScore = currentScores + 10;
            finalScore = newScore;
            score.Text = newScore + "";

        }

        public void stopGame()
        {
            isitover = true;
            timer1.Stop();
            StartGame.Enabled = true;
            GiveUp.Enabled = false;
            this.Close();



        }

        private void GiveUp_Click(object sender, EventArgs e)
        {
            stopGame();
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SnakeGame_Load(object sender, EventArgs e)
        {

        }
    }
}
