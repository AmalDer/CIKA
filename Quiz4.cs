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
    public partial class Quiz4 : Form
    {
        int correctAnswer;
        int questionNumber = 1;
        int score;
        public static int percentage;
        public static bool isitover = false;
        int totalQuestions;

        public Quiz4()
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = 4;
        }

        private void checkAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (buttonTag == correctAnswer)
            {
                score++;
            }

            if (questionNumber == totalQuestions)
            {

                percentage = (int)Math.Round((double)(score * 100) / totalQuestions);

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

            switch (qnum)
            {

                case 1:
                    pictureBox1.Image = Properties.Resources.albaniadrap;

                    lblQuestion.Text = "Quel pays a ce drapeau?";

                    button1.Text = "Albania";
                    button2.Text = "Bulgaria";
                    button3.Text = "Greece";
                    button4.Text = "Serbia";

                    correctAnswer = 1;

                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.argentinedrap;

                    lblQuestion.Text = "Quel pays a ce drapeau?";

                    button1.Text = "Chili";
                    button2.Text = "Argentine";
                    button3.Text = "Brésil";
                    button4.Text = "Mexique";

                    correctAnswer = 2;

                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.benindrap;

                    lblQuestion.Text = "Quel pays a ce drapeau?";

                    button1.Text = "Nigeria";
                    button2.Text = "Cameroun";
                    button3.Text = "Benin";
                    button4.Text = "Ghana";

                    correctAnswer = 3;

                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.russiedrap;

                    lblQuestion.Text = "Quel pays a ce drapeau?";

                    button1.Text = "Russie";
                    button2.Text = "France";
                    button3.Text = "Costa Rica";
                    button4.Text = "Nederlands";

                    correctAnswer = 1;

                    break;

            }
        }

        private void Quiz4_Load(object sender, EventArgs e)
        {

        }
    }
}
