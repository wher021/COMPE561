using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3new
{
    public partial class MainFrm : Form
    {
        public static myLeagueDataContext database = new myLeagueDataContext();
        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerFrm pf = new playerFrm();
            pf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player_stats_frm psf = new player_stats_frm();
            psf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            teamFrm tf = new teamFrm();
            tf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            game_frm gf = new game_frm();
            gf.Show();
        }
    }
}
