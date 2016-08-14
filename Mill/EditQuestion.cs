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
    public partial class EditQuestion : Form
    {
        public EditQuestion()
        {
            InitializeComponent();
        }


        public event EventHandler<EventArgs> OnLoading;
        public event EventHandler<EventArgs> Action;
        public event EventHandler<EventArgs> SelectionChanged;
        
        private void Save_Click(object sender, EventArgs e)
        {
            if (Action!=null)
            {
                Action(this, EventArgs.Empty);
            }
        }

        private void EditQuestion_Load(object sender, EventArgs e)
        {
            if (OnLoading != null)
            {
                OnLoading(this, EventArgs.Empty);
            }
        }

        private void Choise(object sender, EventArgs e)
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
