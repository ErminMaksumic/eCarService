namespace eCarService.DesktopApp.Reports
{
    partial class frmRevenueReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGraphic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eCarService.DesktopApp.Reports.rptYearRevenue.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(186, 64);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(780, 395);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtpYear
            // 
            this.dtpYear.Location = new System.Drawing.Point(538, 27);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(172, 20);
            this.dtpYear.TabIndex = 15;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(727, 29);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(64, 20);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label3.Location = new System.Drawing.Point(377, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 13;
            this.label3.Text = "Select the year:";
            this.label3.UseMnemonic = false;
            // 
            // btnGraphic
            // 
            this.btnGraphic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGraphic.Location = new System.Drawing.Point(872, 12);
            this.btnGraphic.Name = "btnGraphic";
            this.btnGraphic.Size = new System.Drawing.Size(94, 43);
            this.btnGraphic.TabIndex = 16;
            this.btnGraphic.Text = "Graphic view";
            this.btnGraphic.UseVisualStyleBackColor = false;
            this.btnGraphic.Click += new System.EventHandler(this.btnGraphic_Click);
            // 
            // frmRevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 483);
            this.Controls.Add(this.btnGraphic);
            this.Controls.Add(this.dtpYear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRevenueReport";
            this.Text = "frmRevenueReport";
            this.Load += new System.EventHandler(this.frmRevenueReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGraphic;
    }
}