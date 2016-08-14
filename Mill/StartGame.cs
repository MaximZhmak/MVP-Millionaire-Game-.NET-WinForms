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
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }
        private void start_game_Click(object sender, EventArgs e)
        {
            this.Hide();
            View game = new View();
            Presenter presenter = new Presenter(game);
            game.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите покинуть игру?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private void settings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }
        private void StartGame_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer soundplayer = new System.Media.SoundPlayer("../../resourses/sounds/begin.wav");
            soundplayer.Play();
        }       
    }
}

