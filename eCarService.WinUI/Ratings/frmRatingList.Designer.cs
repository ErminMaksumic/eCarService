namespace eProdajaService.WinUI.Ratings
{
    partial class frmRatingList
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRatingList = new System.Windows.Forms.DataGridView();
            this.lblAverageRating = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatingList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRatingList);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 329);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RatingList";
            // 
            // dgvRatingList
            // 
            this.dgvRatingList.AllowUserToAddRows = false;
            this.dgvRatingList.AllowUserToDeleteRows = false;
            this.dgvRatingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRatingList.Location = new System.Drawing.Point(3, 23);
            this.dgvRatingList.Name = "dgvRatingList";
            this.dgvRatingList.ReadOnly = true;
            this.dgvRatingList.RowHeadersWidth = 51;
            this.dgvRatingList.RowTemplate.Height = 29;
            this.dgvRatingList.Size = new System.Drawing.Size(770, 303);
            this.dgvRatingList.TabIndex = 0;
            // 
            // lblAverageRating
            // 
            this.lblAverageRating.AutoSize = true;
            this.lblAverageRating.Location = new System.Drawing.Point(617, 86);
            this.lblAverageRating.Name = "lblAverageRating";
            this.lblAverageRating.Size = new System.Drawing.Size(118, 20);
            this.lblAverageRating.TabIndex = 3;
            this.lblAverageRating.Text = "Average rating : ";
            // 
            // RatingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAverageRating);
            this.Controls.Add(this.groupBox1);
            this.Name = "RatingList";
            this.Text = "RatingList";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvRatingList;
        private Label lblAverageRating;
    }
}