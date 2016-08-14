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
    public partial class NewQuestion : Form
    {
        public event EventHandler<EventArgs> Action;
        public NewQuestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Action != null)
                Action(this, EventArgs.Empty);                      
        }

        private void Cansel(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
