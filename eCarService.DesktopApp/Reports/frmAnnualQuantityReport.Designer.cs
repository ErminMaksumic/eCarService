namespace eCarService.DesktopApp.Reports
{
    partial class frmAnnualQuantityReport
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
            this.btnGraphic = new System.Windows.Forms.Button();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnGraphic
            // 
            this.btnGraphic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGraphic.Location = new System.Drawing.Point(776, 18);
            this.btnGraphic.Name = "btnGraphic";
            this.btnGraphic.Size = new System.Drawing.Size(94, 43);
            this.btnGraphic.TabIndex = 21;
            this.btnGraphic.Text = "Graphic view";
            this.btnGraphic.UseVisualStyleBackColor = false;
            this.btnGraphic.Click += new System.EventHandler(this.btnGraphic_Click_1);
            // 
            // dtpYear
            // 
            this.dtpYear.Location = new System.Drawing.Point(438, 41);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(172, 20);
            this.dtpYear.TabIndex = 20;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(627, 43);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(64, 20);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label3.Location = new System.Drawing.Point(277, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 18;
            this.label3.Text = "Select the year:";
            this.label3.UseMnemonic = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eCarService.DesktopApp.Reports.rptQuantityReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(90, 87);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(780, 395);
            this.reportViewer1.TabIndex = 17;
            // 
            // frmAnnualQuantityReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 518);
            this.Controls.Add(this.btnGraphic);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmAnnualQuantityReport";
            this.Text = "Report quantity";
            this.Load += new System.EventHandler(this.frmAnnualQuantityReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGraphic;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}