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
    public partial class Quiz2 : Form
    {
        int correctAnswer;
        int questionNumber = 1;
        int score;
        public static int percentage;
        public static bool isitover=false;
        int totalQuestions;

        public Quiz2()
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

            if(questionNumber==totalQuestions)
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
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.fortnite;

                    lblQuestion.Text = "Quel est le nom du jeu?";

                    button1.Text = "PUBG";
                    button5.Text = "Valorant";
                    button6.Text = "Fortnite";
                    button7.Text = "Fall guys";

                    correctAnswer = 3;

                    break;

                case 2:
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.fallguys;

                    lblQuestion.Text = "Quel est le nom du jeu?";

                    button1.Text = "Deceit";
                    button5.Text = "Valorant";
                    button6.Text = "Fortnite";
                    button7.Text = "Fall guys";

                    correctAnswer = 4;

                    break;

                case 3:
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.gettingoverit;

                    lblQuestion.Text = "Quel est le nom du jeu?";

                    button1.Text = "Getting Over It";
                    button5.Text = "Valorant";
                    button6.Text = "Fortnite";
                    button7.Text = "Fall guys";

                    correctAnswer = 1;

                    break;

                case 4:
                    pictureBox1.Image = BOARD_GAME.Properties.Resources.valorant;

                    lblQuestion.Text = "Quel est le nom du jeu?";

                    button1.Text = "PUBG";
                    button5.Text = "Valorant";
                    button6.Text = "Fortnite";
                    button7.Text = "Free Fire";

                    correctAnswer = 2;

                    break;

            }
        }

        private void Quiz2_Load(object sender, EventArgs e)
        {

        }
    }
}
