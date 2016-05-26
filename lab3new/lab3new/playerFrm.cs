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
    public partial class playerFrm : Form
    {
        public playerFrm()
        {
            InitializeComponent();
            player_tblBindingSource.DataSource = MainFrm.database.player_tbls;
        }

        private void player_tblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            player_tblBindingSource.EndEdit();
            MainFrm.database.SubmitChanges();
        }
    }
}
