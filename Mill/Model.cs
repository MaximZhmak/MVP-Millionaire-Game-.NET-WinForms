using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MIllionaire
{
    public class Question
    {
        public string question;
        public string answer_1;
        public string answer_2;
        public string answer_3;
        public string answer_4;
        public int key; //правильный вариант
        public bool used; // использовался вопрос или нет

        public Question(string q, string a1, string a2, string a3, string a4, int key, bool used)
        {
            question = q;
            answer_1 = a1;
            answer_2 = a2;
            answer_3 = a3;
            answer_4 = a4;
            this.key = key;
            this.used = used;
        }
    }

    public class Model
    {
        public List<Question> questions; //список вопросов
        public bool Fifty;
        public bool Help;
        public bool Friend;

        public Question current_question;
        public int level;
        public GameMessage gameMessage;

        public Model()
        {
            level = 1;
            Load();
        }
        public void Save()
        {
            StreamWriter saver = new StreamWriter("../../resourses/question.txt", false);
            saver.WriteLine(questions.Count);
            for (int i = 0; i < questions.Count; i++)
            {
                saver.WriteLine(questions[i].question);
                saver.WriteLine(questions[i].answer_1);
                saver.WriteLine(questions[i].answer_2);
                saver.WriteLine(questions[i].answer_3);
                saver.WriteLine(questions[i].answer_4);
                saver.WriteLine(questions[i].key);
            }
            saver.Close();

        }
        public void Load()
        {
            StreamReader loader = new StreamReader("../../resourses/question.txt");
            int Count = Convert.ToInt32(loader.ReadLine());
            List<Question> temp = new List<Question>(Count);
            for (int i = 0; i < temp.Capacity; i++)
            {
                string question = loader.ReadLine();
                string answer1 = loader.ReadLine();
                string answer2 = loader.ReadLine();
                string answer3 = loader.ReadLine();
                string answer4 = loader.ReadLine();
                int key = Convert.ToInt32(loader.ReadLine());

                temp.Add(new Question(question, answer1, answer2, answer3, answer4, key, false));

            }
            loader.Close();
            questions = temp;
            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].used = false;
            }

        }

        //случайный выбор вопроса из списка
        public Question RandomQuestion()
        {
            Random rnd = new Random();
            int number = rnd.Next(questions.Count);

            if (!questions[number].used)
            {
                current_question = questions[number];
                questions[number].used = true;
            }
            else if (level < 14)
            {
                RandomQuestion();
            }
            return current_question;
        }
        //подсказки
        public int Call()
        {
            Random rnd = new Random();      
            return rnd.Next(1, 5);
        }
        public int[] Zal()
        {
            int[] prop = new int[4];
            Random rnd = new Random();
            prop[0] = rnd.Next(0, 101);
            prop[1] = rnd.Next(0, 100 - prop[0]);
            prop[2] = rnd.Next(0, 100 - prop[0] - prop[1]);
            prop[3] = (100 - prop[0] - prop[1] - prop[2]) > 0 ? (100 - prop[0] - prop[1] - prop[2]) : 0;
            System.Threading.Thread.Sleep(1000);
            return prop;
        }
        public int[] _50x50()
        {
            int[] vars = new int[2];
            Random random = new Random();
            switch (current_question.key)
            {
                case 1:
                    {
                        vars[0] = 2;
                        int index = random.Next(3, 5);
                        if (index == 3)
                        {
                            vars[1] = 3;
                        }
                        else
                        {
                            vars[1] = 4;
                        }
                    }
                    break;
                case 2:
                    {
                        vars[0] = 1;
                        int index = random.Next(3, 5);
                        if (index == 3)
                        {
                            vars[1] = 3;
                        }
                        else
                        {
                            vars[1] = 4;
                        }
                    }
                    break;
                case 3:
                    {
                        vars[0] = 4;
                        int index = random.Next(1, 3);
                        if (index == 1)
                        {
                            vars[1] = 1;
                        }
                        else
                        {
                            vars[1] = 2;
                        }
                    }
                    break;
                case 4:
                    {
                        vars[0] = 3;
                        int index = random.Next(1, 3);
                        if (index == 1)
                        {
                            vars[1] = 1;
                        }
                        else
                        {
                            vars[1] = 2;
                        }
                    }
                    break;
            }
            return vars;
        }
    }
}
