using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIllionaire
{
    public partial class View : Form, Interface_Game
    {
        public int Result;
        public event EventHandler FiftyFiftyClickEvent;
        public event EventHandler PeopleClickEvent;
        public event EventHandler CallClickEvent;
        public event EventHandler AnswerClickEvent;



        public System.Media.SoundPlayer soundplayer;
        public string[] Money = new string[] { "100", "200", "300", "500", "1 000", "2 000", "4 000", "8 000", "16 000", "32 000", "64 000", "125 000", "250 000", "500 000", "1 000 000" };
        public View()
        {
            InitializeComponent();
            InitialSetting();
        }


        public void InitialSetting()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button1.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/black_button1.jpg");
            button2.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/black_button1.jpg");
            button3.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/black_button1.jpg");
            button4.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/black_button1.jpg");
        }
        private void exit(object sender, EventArgs e)
        {
            if ((MessageBox.Show("При выходе весь игровой процесс будет потерян! Продолжить?", "Уйти?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
            {
                soundplayer.Stop();
                Dispose();
                Program.StartScreen.Show();
            }

        }
        //подсказки
        private void button50(object sender, EventArgs e)
        {
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/gong.wav");
            soundplayer.Play();
            FiftyFiftyClickEvent(this, EventArgs.Empty);
            this.button50x50.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/50x50_used.jpg");
            button50x50.Enabled = false;
        }
        private void zall(object sender, EventArgs e)
        {
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/zal.wav");
            soundplayer.Play();

            PeopleClickEvent(this, EventArgs.Empty);
            this.zal.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/zal_used.png");
            zal.Enabled = false;
        }
        private void call(object sender, EventArgs e)
        {
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/zvonok.wav");
            soundplayer.Play();
            CallClickEvent(this, EventArgs.Empty);
            this.zvonok.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/call_used.png");
            zvonok.Enabled = false;
        }

        //варианты ответа
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/yellow_button.jpg");
            button1.Refresh();
            Result = 1;
            System.Threading.Thread.Sleep(1500);
            AnswerClickEvent(this, EventArgs.Empty);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/yellow_button.jpg");
            button2.Refresh();
            Result = 2;
            System.Threading.Thread.Sleep(1500);
            AnswerClickEvent(this, EventArgs.Empty);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/yellow_button.jpg");
            button3.Refresh();
            Result = 3;
            System.Threading.Thread.Sleep(1500);
            AnswerClickEvent(this, EventArgs.Empty);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.BackgroundImage = System.Drawing.Image.FromFile("../../resourses/images/yellow_button.jpg");
            button4.Refresh();
            Result = 4;
            System.Threading.Thread.Sleep(1500);
            AnswerClickEvent(this, EventArgs.Empty);
        }
        //загрузка формы
        private void Game_Load(object sender, EventArgs e)
        {
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/GAME.wav");
            soundplayer.PlayLooping();
        }
        public int result
        {
            get
            {
                return Result;
            }
        }

        public string QuestionText
        {
            set
            {
                label1.Text = value;
            }
        }
        public string AnswerOne
        {
            set
            {
                if (value == "")
                    button1.Enabled = false;
                button1.Text = String.Format("       A   " + value);
            }
        }
        public string AnswerTwo
        {
            set
            {
                if (value == "")
                    button2.Enabled = false;
                button2.Text = String.Format("       B   " + value);
            }
        }
        public string AnswerThree
        {
            set
            {
                if (value == "")
                    button3.Enabled = false;
                button3.Text = String.Format("       C   " + value);
            }
        }
        public string AnswerFour
        {
            set
            {
                if (value == "")
                    button4.Enabled = false;
                button4.Text = String.Format("       D   " + value);
            }
        }
        public string LevelText
        {

            set
            {
                label3.Text = value;
            }
        }
        public string MoneyText
        {
            set
            {
                label2.Text = value;
            }
        }
        public new void ShowDialog()
        {
            //команда от презентера - запуск формы
            this.Show();
        }
        public void FormDispose()
        {
            soundplayer.Dispose();
            this.Dispose();
            Program.StartScreen.Show();
        }
        public void ShowCorrectAnswer(int answer)
        {
            Image green = System.Drawing.Image.FromFile("../../resourses/images/green_button.jpg");
            switch (answer)
            {
                case 1:
                    button1.BackgroundImage = green;
                    break;
                case 2:
                    button2.BackgroundImage = green;
                    break;
                case 3:
                    button3.BackgroundImage = green;
                    break;
                case 4:
                    button4.BackgroundImage = green;
                    break;
            }
            Refresh();
        }
        public void CorrectAnswer()
        {
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/true.wav");
            soundplayer.Play();
            System.Threading.Thread.Sleep(3800);
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/GAME.wav");
            soundplayer.PlayLooping();
        }
        public void WrongAnswer(string message)
        {
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/false.wav");
            soundplayer.Play();
            new GameMessage("Вы проиграли!").Show();
            new GameMessage(message).Show();
            System.Threading.Thread.Sleep(3800);
            FormDispose();
            Program.StartScreen.Show();
        }
        public void WinMillion()
        {
            new GameMessage("Вы выиграли миллион!").Show();
            soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/begin.wav");
            soundplayer.Play();        
            System.Threading.Thread.Sleep(3800);
            FormDispose();
            Program.StartScreen.Show();
        }
        public void LoadQuestion(string question, string var1, string var2, string var3, string var4, int level)
        {
            QuestionText = question;
            AnswerOne = var1;
            AnswerTwo = var2;
            AnswerThree = var3;
            AnswerFour = var4;
            LevelText = String.Format("Уровень: " + level.ToString());
            MoneyText = String.Format(Money[level - 1].ToString() + "$");
        }
        public void ZalAnswers(int[] proportion)
        {
            new GameMessage(String.Format(
                "A: " + proportion[0].ToString() + "%             " +
                  "B: " + proportion[1].ToString() + "%             " +
                    "C: " + proportion[2].ToString() + "%             " +
                      "D: " + proportion[3].ToString() + "%             ")).Show();
        }
        public void FriendAnswers(int answer)
        {
            System.Threading.Thread.Sleep(1000);
            new GameMessage(String.Format("Друг считает, что это  -  " + answer.ToString())).Show();
        }
        public void FiftyFiftyAnswer(int[] vars)
        {
            if (vars[0] == 1 || vars[1] == 1)
            {
                button1.Enabled = false;
                AnswerOne = "";
            }
            if (vars[0] == 2 || vars[1] == 2)
            {
                button2.Enabled = false;
                AnswerTwo = "";
            }
            if (vars[0] == 3 || vars[1] == 3)
            {
                button3.Enabled = false;
                AnswerThree = "";
            }
            if (vars[0] == 4 || vars[1] == 4)
            {
                button4.Enabled = false;
                AnswerFour = "";
            }
        }
    }
}
