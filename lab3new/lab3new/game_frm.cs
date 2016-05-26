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
    public partial class game_frm : Form
    {
        public game_frm()
        {
            InitializeComponent();
            game_tblBindingSource.DataSource = MainFrm.database.game_tbls;
        }

        private void game_tblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            game_tblBindingSource.EndEdit();
            MainFrm.database.SubmitChanges();
        }
    }
}
