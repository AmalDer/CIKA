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
    public partial class Shooter : Form
    {
        public Shooter()
        {
            InitializeComponent();
        }

        bool right, left, space;
        public static int score;
        public static bool isitover = false;



        void game_result()
        {
            foreach(Control j in this.Controls)
            {
                foreach(Control i in this.Controls)
                    {
                        if(j is PictureBox && j.Tag=="bullet")
                    {
                        if ( i is PictureBox && i.Tag=="enemy")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                i.Top =- 100;
                                ((PictureBox)j).Image = Properties.Resources.explosion;
                                score++;
                                lbl_score.Text = "Score = " + score;
                            }
                        }
                    }
                }

            }

            if(player.Bounds.IntersectsWith(ship.Bounds)||player.Bounds.IntersectsWith(alien.Bounds))
            {
                timer1.Stop();
                lbl_over.Show();
                lbl_over.BringToFront();
                isitover = true;
                this.Close();
            }

        }
       



        


        void star()
        {
            foreach(Control j in this.Controls)
            {
                if(j is PictureBox && j.Tag=="stars")
                {
                    j.Top += 10;
                    if (400<j.Top)
                    { j.Top = 0; }
                }
            }
        }


        void add_bullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.SizeMode = PictureBoxSizeMode.AutoSize;
            bullet.Image = Properties.Resources.bullet_img;
            bullet.BackColor = System.Drawing.Color.Transparent;
            bullet.Tag = "bullet";
            bullet.Left = player.Left + 15;
            bullet.Top = player.Top - 30;
            this.Controls.Add(bullet);
            bullet.BringToFront();


        }


        void bullet_movement()
        {

            foreach(Control x in this.Controls)
            {   
                if(x is PictureBox && x.Tag=="bullet")
                {
                    x.Top -=10;
                    if(x.Top<100)
                    {
                        this.Controls.Remove(x);
                    }

                }


            }
                   
        }






        void enemy_movement()
        {
            Random rnd = new Random();
            int x, y;

             if (500<=alien.Top)
            {
                x = rnd.Next(0, 300);
                alien.Location = new Point(x, 0);
            }

             if(500<=ship.Top)

            {
                y = rnd.Next(0, 300);
                ship.Location = new Point(y, 0);
            }
             else
            {
                alien.Top += 15;
                ship.Top += 15;

            }


        }




        void arrow_key_movement()

        {
            if(right==true)
            {
                if (player.Left<425)
                {
                    player.Left += 25;
                }



            }

            if(left==true)
            {
                if (10<player.Left)
                {
                    player.Left -= 20;
                }


            }





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_over.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            arrow_key_movement();
            enemy_movement();
            bullet_movement();
            star();
            game_result();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 50;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Interval = 15;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                right = true;

            }

            if(e.KeyCode==Keys.Left)
            {
                left = true;
            }

            if(e.KeyCode==Keys.Space)
            {
                space = true;
                add_bullet();
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;

            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                space = false;
            }
        }
    }
}
