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
    public partial class frmStudents : Form
    {
        public frmStudents()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cbxGrade.DataSource = DataConstants.GradeLevel;
            cbxSection.DataSource = DataConstants.Grade7Section;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            var listStudents = new StudentDAO().GetStudents();
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStudents.DataSource = listStudents;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string getGender;
            if (rbtnFemale.Checked)
                getGender = rbtnFemale.Text;
            else
                getGender = rbtnMale.Text;
            var student = new Students
            {
                StudentNumber = Convert.ToInt32(txtBoxStudentID.Text),
                FirstName = txtBoxFirstName.Text,
                MI = txtBoxMI.Text,
                LastName = txtBoxLastName.Text,
                GradeLevel = (int)cbxGrade.SelectedItem,
                Section = cbxSection.SelectedItem.ToString(),
                Gender = getGender,
                Password = (txtBoxLastName.Text+txtBoxStudentID.Text.Substring(txtBoxStudentID.TextLength - 4)),
            };

            var saved = new StudentDAO().InsertStudent(student);
            RefreshData();
        }

        public void RefreshData()
        {
            var listStudents = new StudentDAO().GetStudents();
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStudents.DataSource = listStudents;
        }
    }
}
