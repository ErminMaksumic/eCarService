namespace eProdajaService.WinUI.Offers
{
    partial class frmAddNewOffer
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
            this.txtOfferName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.richBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.clbParts = new System.Windows.Forms.CheckedListBox();
            this.clbBrands = new System.Windows.Forms.CheckedListBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOfferName
            // 
            this.txtOfferName.Location = new System.Drawing.Point(166, 23);
            this.txtOfferName.Name = "txtOfferName";
            this.txtOfferName.Size = new System.Drawing.Size(222, 27);
            this.txtOfferName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Offer name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Including parts:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Price:";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(174, 81);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(86, 27);
            this.numPrice.TabIndex = 14;
            // 
            // richBoxDescription
            // 
            this.richBoxDescription.Location = new System.Drawing.Point(154, 172);
            this.richBoxDescription.Name = "richBoxDescription";
            this.richBoxDescription.Size = new System.Drawing.Size(271, 129);
            this.richBoxDescription.TabIndex = 15;
            this.richBoxDescription.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Description:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(706, 503);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 29);
            this.btnSubmit.TabIndex = 17;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // clbParts
            // 
            this.clbParts.FormattingEnabled = true;
            this.clbParts.Location = new System.Drawing.Point(578, 23);
            this.clbParts.Name = "clbParts";
            this.clbParts.Size = new System.Drawing.Size(222, 180);
            this.clbParts.TabIndex = 19;
            // 
            // clbBrands
            // 
            this.clbBrands.FormattingEnabled = true;
            this.clbBrands.Location = new System.Drawing.Point(578, 228);
            this.clbBrands.Name = "clbBrands";
            this.clbBrands.Size = new System.Drawing.Size(222, 180);
            this.clbBrands.TabIndex = 21;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(500, 228);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(57, 20);
            this.label.TabIndex = 20;
            this.label.Text = "Brands:";
            // 
            // frmAddNewOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 544);
            this.Controls.Add(this.clbBrands);
            this.Controls.Add(this.label);
            this.Controls.Add(this.clbParts);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richBoxDescription);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOfferName);
            this.Name = "frmAddNewOffer";
            this.Text = "AddNewOffer";
            this.Load += new System.EventHandler(this.frmAddNewOffer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtOfferName;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numPrice;
        private RichTextBox richBoxDescription;
        private Label label4;
        private Button btnSubmit;
        private CheckedListBox clbParts;
        private CheckedListBox clbBrands;
        private Label label;
    }
}