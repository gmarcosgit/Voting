namespace WindowsVoting
{
    partial class frmMainHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainHome));
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnCandidates = new System.Windows.Forms.Button();
            this.btnAuditTrail = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStudents
            // 
            this.btnStudents.Location = new System.Drawing.Point(276, 239);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(188, 97);
            this.btnStudents.TabIndex = 0;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.frmStudents_Click);
            // 
            // btnCandidates
            // 
            this.btnCandidates.Location = new System.Drawing.Point(276, 428);
            this.btnCandidates.Name = "btnCandidates";
            this.btnCandidates.Size = new System.Drawing.Size(188, 97);
            this.btnCandidates.TabIndex = 1;
            this.btnCandidates.Text = "Candidates";
            this.btnCandidates.UseVisualStyleBackColor = true;
            this.btnCandidates.Click += new System.EventHandler(this.btnCandidates_Click);
            // 
            // btnAuditTrail
            // 
            this.btnAuditTrail.Location = new System.Drawing.Point(833, 438);
            this.btnAuditTrail.Name = "btnAuditTrail";
            this.btnAuditTrail.Size = new System.Drawing.Size(188, 97);
            this.btnAuditTrail.TabIndex = 2;
            this.btnAuditTrail.Text = "Audit Trail";
            this.btnAuditTrail.UseVisualStyleBackColor = true;
            this.btnAuditTrail.Click += new System.EventHandler(this.btnAuditTrail_Click);
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(833, 239);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(188, 97);
            this.btnResults.TabIndex = 3;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // frmMainHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1299, 686);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnAuditTrail);
            this.Controls.Add(this.btnCandidates);
            this.Controls.Add(this.btnStudents);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainHome";
            this.Load += new System.EventHandler(this.frmMainHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnCandidates;
        private System.Windows.Forms.Button btnAuditTrail;
        private System.Windows.Forms.Button btnResults;
    }
}