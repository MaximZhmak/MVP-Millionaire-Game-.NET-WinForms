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
    public partial class Delete : Form
    {
        public event EventHandler<EventArgs> OnAction;
        public event EventHandler<EventArgs> OnLoad;

   
        public Delete()
        {
            InitializeComponent();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnAction!=null)
            {
                OnAction(this, EventArgs.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        

        private void Delete_Load(object sender, EventArgs e)
        {
            if (OnLoad != null)
            {
                OnLoad(this, EventArgs.Empty);
            }
        }
    }
}
