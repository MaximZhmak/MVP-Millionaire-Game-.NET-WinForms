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
    public partial class Settings : Form
    {
        public Settings()
        {
         
            InitializeComponent();
        }
        
        private void AddNew(object sender, EventArgs e)
        {
            NewQuestion temp = new NewQuestion();
            NewQuestPresenter presenter = new NewQuestPresenter(temp);
            temp.Show();
            if (temp.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Вопрос добавлен!");
            }
        }
        private void Edit(object sender, EventArgs e)
        {
            EditQuestion temp = new EditQuestion();
            EditQuest_Presenter presenter = new EditQuest_Presenter(temp);
            temp.Show();   
            if (temp.DialogResult==DialogResult.OK)
            {
                MessageBox.Show("Вопрос отредактирован!");
            }  
        }

        private void delete_question(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            DeleteQuest_Presenter presenter = new DeleteQuest_Presenter(delete);
            delete.Show();
        }
    }
}
