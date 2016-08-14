using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIllionaire
{
    class Presenter
    {
        private Model _model = new Model();
        private Interface_Game game;
        public Presenter(Interface_Game view)
        {
            game = view;
            game.AnswerClickEvent += new EventHandler(Checking); //подписка на событие - пользоватекль щелкнул вариант ответа
            game.FiftyFiftyClickEvent += new EventHandler(Lifeline50x50); //50x50
            game.PeopleClickEvent += new EventHandler(LifelineAudience); //Помощь зала
            game.CallClickEvent += new EventHandler(LifelineCall); //Звонок Другу
            LoadQuestion();
        }
        public void Checking(object sender, EventArgs e)
        {
            game.ShowCorrectAnswer(_model.current_question.key);

            if (game.result == _model.current_question.key)
            {
                _model.level++;
                game.CorrectAnswer();               
                if (_model.level == 16)
                {
                    game.WinMillion();
                    return;
                }
                game.InitialSetting();
                LoadQuestion();          
            }
            else
            {
                string message = null;
                if (_model.level < 5)
                    message = "Вы выиграли 0";
                else if (_model.level >= 5 && _model.level < 10)
                    message = "Вы выиграли 1000";
                else
                    message = "Вы выиграли 32000";
                game.WrongAnswer(message);
            }
        }
        public void Lifeline50x50(object sender, EventArgs e)
        {
            game.FiftyFiftyAnswer(_model._50x50());
        }
        public void LifelineCall(object sender, EventArgs e)
        {
            game.FriendAnswers(_model.Call());
        }
        public void LifelineAudience(object sender, EventArgs e)
        {
            game.ZalAnswers(_model.Zal());
        }
        private void LoadQuestion()
        {
            _model.RandomQuestion();
            game.LoadQuestion(_model.current_question.question,
                     _model.current_question.answer_1,
                     _model.current_question.answer_2,
                     _model.current_question.answer_3,
                     _model.current_question.answer_4,
                     _model.level);
        }
    }
}

