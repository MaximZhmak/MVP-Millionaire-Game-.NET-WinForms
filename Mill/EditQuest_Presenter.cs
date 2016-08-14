using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIllionaire
{
    public class EditQuest_Presenter
    {
        private EditQuestion _edit_form;
        private Model _model = new Model();

        public EditQuest_Presenter(EditQuestion edit)
        {
            _edit_form = edit;
            _edit_form.Action += new EventHandler<EventArgs>(Edit);
            _edit_form.OnLoading += new EventHandler<EventArgs>(InitializeCombo);
            _edit_form.SelectionChanged += new EventHandler<EventArgs>(SelChanged);
        }

        private void Edit(Object sender, EventArgs e)
        {
            _model.questions.RemoveAt(_edit_form.comboBox1.SelectedIndex);
            _model.questions.Add(new Question(_edit_form.comboBox1.Text,
                _edit_form.textBox1.Text,
                _edit_form.textBox2.Text,
                _edit_form.textBox3.Text,
                _edit_form.textBox4.Text,
                _edit_form.comboBox2.SelectedIndex + 1,
                false));
            _model.Save();
            _edit_form.Dispose();
        }
        private void InitializeCombo(Object sender, EventArgs e)
        {
            for (int i = 0; i < _model.questions.Count; i++)
            {
                _edit_form.comboBox1.Items.Add(_model.questions[i].question);
            }
        }
        private void SelChanged(Object sender, EventArgs e)
        {
            _edit_form.comboBox1.Text = _model.questions[_edit_form.comboBox1.SelectedIndex].question;
            _edit_form.textBox1.Text = _model.questions[_edit_form.comboBox1.SelectedIndex].answer_1;
            _edit_form.textBox2.Text = _model.questions[_edit_form.comboBox1.SelectedIndex].answer_2;
            _edit_form.textBox3.Text = _model.questions[_edit_form.comboBox1.SelectedIndex].answer_3;
            _edit_form.textBox4.Text = _model.questions[_edit_form.comboBox1.SelectedIndex].answer_4;
            _edit_form.comboBox2.SelectedIndex= _model.questions[_edit_form.comboBox1.SelectedIndex].key-1;
        }



    }


}

