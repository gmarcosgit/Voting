using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsVoting
{
    public partial class frmAuditTrail : Form
    {
        public frmAuditTrail()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cbxPosition.DataSource = DataConstants.Position;
        }

        private void frmAuditTrail_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var votedata = new VoteDAO().GetAllVoteData(cbxPosition.SelectedItem.ToString());
            dgvAuditTral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAuditTral.DataSource = votedata;
        }
    }
}
