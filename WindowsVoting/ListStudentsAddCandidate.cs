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
    public partial class frmListStudentsAddCandidate : Form
    {
        public frmListStudentsAddCandidate()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cbxPosition.DataSource = DataConstants.Position;
        }

        private void frmListStudentsAddCandidate_Load(object sender, EventArgs e)
        {
            var listStudents = new StudentDAO().GetStudents();
            dgvAddCandidateStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAddCandidateStudent.DataSource = listStudents;
            dgvAddCandidateStudent.Columns["FirstName"].Visible = false;
            dgvAddCandidateStudent.Columns["MI"].Visible = false;
            dgvAddCandidateStudent.Columns["LastName"].Visible = false;
            dgvAddCandidateStudent.Columns["DateTimeVoted"].Visible = false;
            dgvAddCandidateStudent.Columns["Voted"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmCandidates = new frmCandidate();
            var candidate = new Candidates
            {
                StudentNumber = Convert.ToInt32(dgvAddCandidateStudent.SelectedCells[0].Value),
                FirstName = dgvAddCandidateStudent.SelectedCells[2].Value.ToString(),
                MI = dgvAddCandidateStudent.SelectedCells[3].Value.ToString(),
                LastName = dgvAddCandidateStudent.SelectedCells[4].Value.ToString(),
                GradeLevel = Convert.ToInt32(dgvAddCandidateStudent.SelectedCells[5].Value),
                Section = dgvAddCandidateStudent.SelectedCells[6].Value.ToString(),
                Gender = dgvAddCandidateStudent.SelectedCells[7].Value.ToString(),
                Position = cbxPosition.SelectedItem.ToString(),
                SchoolYear = "2018-2019",
            };
            var saved = new StudentDAO().InsertCandidateStudent(candidate);
            frmCandidates.RefreshData();
            
        }
    }
}
