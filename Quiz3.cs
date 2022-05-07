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
    public partial class Quiz3 : Form
    {
        int correctAnswer;
        int questionNumber = 1;
        int score;
        public static int percentage;
        public static bool isitover = false;
        int totalQuestions;

        public Quiz3()
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
            switch(qnum)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.turquie;

                    lblQuestion.Text = "Quel est la capitale de la Turquie?";

                    button1.Text = "Bursa";
                    button2.Text = "Ankara";
                    button3.Text = "Istanbul";
                    button4.Text = "Antalya";

                    correctAnswer = 2;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.australie;

                    lblQuestion.Text = "Quel est la capitale de l'Australie?";

                    button1.Text = "Sydney";
                    button2.Text = "Canberra";
                    button3.Text = "Gold Coast";
                    button4.Text = "Newcastle";

                    correctAnswer = 2;
                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.chine;

                    lblQuestion.Text = "Quel est la capitale de la Chine?";

                    button1.Text = "Shanghai";
                    button2.Text = "Pekin";
                    button3.Text = "Hong Kong";
                    button4.Text = "Wuhan";

                    correctAnswer = 2;
                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.bresil;

                    lblQuestion.Text = "Quel est la capitale du Brésil?";

                    button1.Text = "Sao Paulo";
                    button2.Text = "Rio De Janeiro";
                    button3.Text = "Brasilia";
                    button4.Text = "Recife";

                    correctAnswer = 3;
                    break;
                    


            }


        }

        private void Quiz3_Load(object sender, EventArgs e)
        {

        }
    }
}
