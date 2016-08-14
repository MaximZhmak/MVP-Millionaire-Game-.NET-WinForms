using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIllionaire
{
    class NewQuestPresenter
    {
      private  Model _model = new Model();
      private  NewQuestion _newQuest;
       public NewQuestPresenter(NewQuestion NewQuest)
        {
            _newQuest = NewQuest;
            _newQuest.Action += new EventHandler<EventArgs>(Add);
        }
        private void Add(Object sender, EventArgs e)
        {            
            string question = _newQuest.textBox7.Text;
            string answer1 = _newQuest.textBox8.Text;
            string answer2 = _newQuest.textBox9.Text;
            string answer3 = _newQuest.textBox10.Text;
            string answer4 = _newQuest.textBox11.Text;
            int key = _newQuest.comboBox2.SelectedIndex + 1;
            _model.questions.Add(new Question(question, answer1, answer2, answer3, answer4, key, false));
            _model.Save();
            _newQuest.Dispose();
        }
    }
}
