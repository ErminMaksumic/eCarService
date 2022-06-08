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
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAverageRating = new System.Windows.Forms.Label();
            this.lblTextRating = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatingList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRatingList);
            this.groupBox1.Location = new System.Drawing.Point(82, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 367);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RatingList";
            // 
            // dgvRatingList
            // 
            this.dgvRatingList.AllowUserToAddRows = false;
            this.dgvRatingList.AllowUserToDeleteRows = false;
            this.dgvRatingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRatingList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rate,
            this.Comment,
            this.User});
            this.dgvRatingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRatingList.Location = new System.Drawing.Point(3, 23);
            this.dgvRatingList.Name = "dgvRatingList";
            this.dgvRatingList.ReadOnly = true;
            this.dgvRatingList.RowHeadersWidth = 51;
            this.dgvRatingList.RowTemplate.Height = 29;
            this.dgvRatingList.Size = new System.Drawing.Size(890, 341);
            this.dgvRatingList.TabIndex = 0;
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Rate";
            this.Rate.HeaderText = "Rate";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            this.Rate.Width = 125;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.MinimumWidth = 6;
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // User
            // 
            this.User.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User.DataPropertyName = "UserName";
            this.User.HeaderText = "User";
            this.User.MinimumWidth = 6;
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // lblAverageRating
            // 
            this.lblAverageRating.AutoSize = true;
            this.lblAverageRating.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAverageRating.Location = new System.Drawing.Point(559, 42);
            this.lblAverageRating.Name = "lblAverageRating";
            this.lblAverageRating.Size = new System.Drawing.Size(38, 46);
            this.lblAverageRating.TabIndex = 3;
            this.lblAverageRating.Text = "0";
            // 
            // lblTextRating
            // 
            this.lblTextRating.AutoSize = true;
            this.lblTextRating.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTextRating.Location = new System.Drawing.Point(370, 42);
            this.lblTextRating.Name = "lblTextRating";
            this.lblTextRating.Size = new System.Drawing.Size(183, 35);
            this.lblTextRating.TabIndex = 4;
            this.lblTextRating.Text = "Average rating:";
            // 
            // frmRatingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 494);
            this.Controls.Add(this.lblTextRating);
            this.Controls.Add(this.lblAverageRating);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRatingList";
            this.Text = "RatingList";
            this.Load += new System.EventHandler(this.frmRatingList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvRatingList;
        private Label lblAverageRating;
        private DataGridViewTextBoxColumn Rate;
        private DataGridViewTextBoxColumn Comment;
        private DataGridViewTextBoxColumn User;
        private Label lblTextRating;
    }
}