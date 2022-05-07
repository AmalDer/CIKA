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
    public partial class Quiz1 : Form
    {
        int correctAnswer;
        int questionNumber = 1;
        int score;
        public static int percentage;
        public static bool isitover=false;
        int totalQuestions;



        public Quiz1()
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = 4;


        }

        private void checkAnswerEvent(object sender, EventArgs e)
        {

            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if(buttonTag==correctAnswer)
            {
                score++;
            }

            if(questionNumber == totalQuestions)
            {

                percentage = (int)Math.Round((double)(score * 100)/totalQuestions);

                MessageBox.Show(
                    
                    "Le quiz est fini!" + Environment.NewLine + 
                    "Vous avez répondu correctement à " + score + " questions." + Environment.NewLine + 
                    "Votre total en pourcentage est " + percentage + "%" + Environment.NewLine
                    );
                isitover = true;
                this.Close();


            }



            questionNumber++;
            askQuestion(questionNumber);



        }



        private void askQuestion(int qnum)
        {

            switch(qnum)
            {

                case 1:
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.babboujloud;

                    lblQuestion.Text = "De quoi s'agit il?";

                    button1.Text = "Bab Boujloud";
                    button2.Text = "Jamaa El Fena";
                    button3.Text = "El Menara";
                    button4.Text = "Chellah";

                    correctAnswer = 1;

                    break;
                case 2:
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.chellah;

                    lblQuestion.Text = "De quoi s'agit il?";

                    button1.Text = "Bab Boujloud";
                    button2.Text = "Jamaa El Fena";
                    button3.Text = "El Menara";
                    button4.Text = "Chellah";

                    correctAnswer = 4;

                    break;
                case 3:
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.koutoubia;

                    lblQuestion.Text = "De quoi s'agit il?";

                    button1.Text = "Koutoubia";
                    button2.Text = "Jamaa El Fena";
                    button3.Text = "El Menara";
                    button4.Text = "Chellah";

                    correctAnswer = 1;

                    break;
                case 4:
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.menara;

                    lblQuestion.Text = "De quoi s'agit il?";

                    button1.Text = "Bab Boujloud";
                    button2.Text = "Jamaa El Fena";
                    button3.Text = "El Menara";
                    button4.Text = "Chellah";

                    correctAnswer = 3;

                    break;




            }



        }

        private void Quiz1_Load(object sender, EventArgs e)
        {

        }
    }
}
