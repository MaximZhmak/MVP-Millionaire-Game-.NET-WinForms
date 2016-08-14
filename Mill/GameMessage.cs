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
    public partial class GameMessage : Form
    {
        public System.Media.SoundPlayer soundplayer;
        public GameMessage(string money)
        {
            InitializeComponent();
            label1.Text =money;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
