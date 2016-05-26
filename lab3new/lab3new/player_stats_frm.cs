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
    public partial class player_stats_frm : Form
    {
        public player_stats_frm()
        {
            InitializeComponent();
            player_stats_tblBindingSource.DataSource = MainFrm.database.player_stats_tbls;
        }

        private void player_stats_tblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            player_stats_tblBindingSource.EndEdit();
            MainFrm.database.SubmitChanges();
        }
    }
}
