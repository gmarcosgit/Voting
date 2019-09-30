namespace WindowsVoting
{
    partial class frmAuditTrail
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
            this.dgvAuditTral = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPosition = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTral)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAuditTral
            // 
            this.dgvAuditTral.AllowUserToAddRows = false;
            this.dgvAuditTral.AllowUserToDeleteRows = false;
            this.dgvAuditTral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditTral.Location = new System.Drawing.Point(57, 105);
            this.dgvAuditTral.Name = "dgvAuditTral";
            this.dgvAuditTral.ReadOnly = true;
            this.dgvAuditTral.RowTemplate.Height = 28;
            this.dgvAuditTral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditTral.Size = new System.Drawing.Size(1274, 610);
            this.dgvAuditTral.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Position:";
            // 
            // cbxPosition
            // 
            this.cbxPosition.FormattingEnabled = true;
            this.cbxPosition.Location = new System.Drawing.Point(145, 50);
            this.cbxPosition.Name = "cbxPosition";
            this.cbxPosition.Size = new System.Drawing.Size(272, 28);
            this.cbxPosition.TabIndex = 5;
            // 
            // frmAuditTrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 768);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxPosition);
            this.Controls.Add(this.dgvAuditTral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAuditTrail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuditTrail";
            this.Load += new System.EventHandler(this.frmAuditTrail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditTral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuditTral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxPosition;
    }
}