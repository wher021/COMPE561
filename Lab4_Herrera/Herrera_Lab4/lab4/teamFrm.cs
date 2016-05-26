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
    public partial class teamFrm : Form
    {
        public teamFrm()
        {
            InitializeComponent();
            team_tblBindingSource.DataSource = MainFrm.database.team_tbls;
        }

        private void team_tblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            team_tblBindingSource.EndEdit();
            MainFrm.database.SubmitChanges();
        }
    }
}
