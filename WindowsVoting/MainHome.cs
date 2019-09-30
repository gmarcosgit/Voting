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
    public partial class frmMainHome : Form
    {
        public frmMainHome()
        {
            InitializeComponent();
        }

        private void frmStudents_Click(object sender, EventArgs e)
        {
            new frmStudents().Show();
            Hide();
        }

        private void frmMainHome_Load(object sender, EventArgs e)
        {

        }

        private void btnCandidates_Click(object sender, EventArgs e)
        {
            new frmCandidate().Show();
            Hide();
        }

        private void btnResults_Click(object sender, EventArgs e)
        { 
            new frmResults().Show();
            Hide();
        }

        private void btnAuditTrail_Click(object sender, EventArgs e)
        {

        }
    }
}
