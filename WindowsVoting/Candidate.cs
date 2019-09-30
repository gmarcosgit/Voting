using BusinessObjects;
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
    public partial class frmCandidate : Form
    {
        public frmCandidate()
        {
            InitializeComponent();
        }

        public static string pic;
        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            new frmListStudentsAddCandidate().Show();
        }

        private void frmCandidate_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        public void RefreshData()
        {
            var candidates = new StudentDAO().GetAllCandidates();
            dgvCandidates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCandidates.DataSource = candidates;
            dgvCandidates.Update();
            dgvCandidates.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            new StudentDAO().RemoveCandidate(new Candidates{ StudentNumber = Convert.ToInt32(dgvCandidates.SelectedCells[0].Value)});
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dialog.Title = "Select your picture";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pic = dialog.FileName.ToString();
                picBoxCandidate.ImageLocation = pic;
                picBoxCandidate.BorderStyle = BorderStyle.Fixed3D;
                picBoxCandidate.SizeMode = PictureBoxSizeMode.StretchImage;
                 
               // new StudentDAO().ChangePic(pic, new Candidates { StudentNumber = Convert.ToInt32(dgvCandidates.SelectedCells[0].Value) });
            }
            else
            {
                picBoxCandidate.Image = null;
            }
        }

        private void btnClearPhoto_Click(object sender, EventArgs e)
        {
            picBoxCandidate.Image = null;
            //var ss = new UserDAO().Null(new User());
        }
    }
}
