﻿using System.Windows.Forms;

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
            this.lblTextRating = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.OfferName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRatingList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRatingList);
            this.groupBox1.Location = new System.Drawing.Point(49, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1179, 427);
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
            this.OfferName,
            this.Rate,
            this.Comment,
            this.User});
            this.dgvRatingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRatingList.Location = new System.Drawing.Point(3, 23);
            this.dgvRatingList.Name = "dgvRatingList";
            this.dgvRatingList.ReadOnly = true;
            this.dgvRatingList.RowHeadersWidth = 51;
            this.dgvRatingList.RowTemplate.Height = 29;
            this.dgvRatingList.Size = new System.Drawing.Size(1173, 401);
            this.dgvRatingList.TabIndex = 0;
            // 
            // lblAverageRating
            // 
            this.lblAverageRating.AutoSize = true;
            this.lblAverageRating.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAverageRating.Location = new System.Drawing.Point(732, 504);
            this.lblAverageRating.Name = "lblAverageRating";
            this.lblAverageRating.Size = new System.Drawing.Size(38, 46);
            this.lblAverageRating.TabIndex = 3;
            this.lblAverageRating.Text = "0";
            // 
            // lblTextRating
            // 
            this.lblTextRating.AutoSize = true;
            this.lblTextRating.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTextRating.Location = new System.Drawing.Point(529, 508);
            this.lblTextRating.Name = "lblTextRating";
            this.lblTextRating.Size = new System.Drawing.Size(183, 35);
            this.lblTextRating.TabIndex = 4;
            this.lblTextRating.Text = "Average rating:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(797, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(161, 29);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search by Offer name";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(429, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 28);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(529, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(249, 27);
            this.txtSearch.TabIndex = 16;
            // 
            // OfferName
            // 
            this.OfferName.DataPropertyName = "OfferName";
            this.OfferName.HeaderText = "Offer name";
            this.OfferName.MinimumWidth = 6;
            this.OfferName.Name = "OfferName";
            this.OfferName.ReadOnly = true;
            this.OfferName.Width = 125;
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
            this.User.DataPropertyName = "UserName";
            this.User.HeaderText = "User";
            this.User.MinimumWidth = 6;
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 435;
            // 
            // frmRatingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 556);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
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
        private Label lblTextRating;
        private Button btnSearch;
        private Label label1;
        private TextBox txtSearch;
        private DataGridViewTextBoxColumn OfferName;
        private DataGridViewTextBoxColumn Rate;
        private DataGridViewTextBoxColumn Comment;
        private DataGridViewTextBoxColumn User;
    }
}