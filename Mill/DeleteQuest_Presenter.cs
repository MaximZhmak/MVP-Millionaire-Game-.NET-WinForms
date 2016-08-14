using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIllionaire
{
    public class DeleteQuest_Presenter
    {
        private Delete _delete_form;
        private Model _model = new Model();

        public DeleteQuest_Presenter(Delete delete)
        {
            _delete_form = delete;
            _delete_form.OnAction += new EventHandler<EventArgs>(DeleteQuestion);
            _delete_form.OnLoad += new EventHandler<EventArgs>(DeleteOnLoad);

        }
        private void DeleteQuestion(Object sender, EventArgs e)
        {
            _model.questions.RemoveAt(_delete_form.comboBox1.SelectedIndex);
            _model.Save();
            _delete_form.Dispose();
        }
        private void DeleteOnLoad(Object sender, EventArgs e)
        {
            for (int i = 0; i < _model.questions.Count; i++)
            {
                _delete_form.comboBox1.Items.Add(_model.questions[i].question);
            }
        }
    }
}
