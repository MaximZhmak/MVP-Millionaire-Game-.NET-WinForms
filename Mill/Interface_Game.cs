using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIllionaire
{

    interface Interface_Game
    {
        event EventHandler FiftyFiftyClickEvent;
        event EventHandler PeopleClickEvent;
        event EventHandler CallClickEvent;
        event EventHandler AnswerClickEvent;



        int result
        { get; }

        //Prorerties
        string QuestionText
        {
            set;
        }
        string AnswerOne
        {
            set;
        }
        string AnswerTwo
        {
            set;
        }
        string AnswerThree
        {
            set;
        }
        string AnswerFour
        {
            set;
        }
        string LevelText
        {
            set;
        }
        string MoneyText
        {
            set;
        }


        void ShowDialog();
        void FormDispose();
        void ShowCorrectAnswer(int answer);
        //только для музыки
        void CorrectAnswer();
        void WrongAnswer(string message);
        void WinMillion();
        void LoadQuestion(string question, string var1, string var2, string var3, string var4, int level);
        void InitialSetting();
        void ZalAnswers(int[]proportion);
        void FriendAnswers(int answer);
        void FiftyFiftyAnswer(int[]vars);








    }
}
