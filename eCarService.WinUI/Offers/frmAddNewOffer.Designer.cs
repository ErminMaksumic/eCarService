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
            this.components = new System.ComponentModel.Container();
            this.txtOfferName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.clbParts = new System.Windows.Forms.CheckedListBox();
            this.clbBrands = new System.Windows.Forms.CheckedListBox();
            this.label = new System.Windows.Forms.Label();
            this.errorOfferProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorOfferProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOfferName
            // 
            this.txtOfferName.Location = new System.Drawing.Point(417, 33);
            this.txtOfferName.Name = "txtOfferName";
            this.txtOfferName.Size = new System.Drawing.Size(222, 27);
            this.txtOfferName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Offer name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Including parts:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Price:";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(417, 89);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(222, 27);
            this.numPrice.TabIndex = 14;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(991, 395);
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
            this.clbParts.Location = new System.Drawing.Point(12, 83);
            this.clbParts.Name = "clbParts";
            this.clbParts.Size = new System.Drawing.Size(222, 114);
            this.clbParts.TabIndex = 19;
            // 
            // clbBrands
            // 
            this.clbBrands.FormattingEnabled = true;
            this.clbBrands.Location = new System.Drawing.Point(566, 83);
            this.clbBrands.Name = "clbBrands";
            this.clbBrands.Size = new System.Drawing.Size(222, 114);
            this.clbBrands.TabIndex = 21;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(566, 46);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(132, 20);
            this.label.TabIndex = 20;
            this.label.Text = "Offer is for brands:";
            // 
            // errorOfferProvider
            // 
            this.errorOfferProvider.ContainerControl = this;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbImage.Location = new System.Drawing.Point(6, 75);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(296, 197);
            this.pbImage.TabIndex = 22;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Image:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtOfferName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numPrice);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 132);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic informations:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbParts);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Controls.Add(this.clbBrands);
            this.groupBox2.Location = new System.Drawing.Point(27, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(811, 231);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Offers details:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Select the image:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.pbImage);
            this.groupBox4.Location = new System.Drawing.Point(870, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 321);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Offer image:";
            // 
            // frmAddNewOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmit);
            this.Name = "frmAddNewOffer";
            this.Text = "Add new offer";
            this.Load += new System.EventHandler(this.frmAddNewOffer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorOfferProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtOfferName;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numPrice;
        private Button btnSubmit;
        private CheckedListBox clbParts;
        private CheckedListBox clbBrands;
        private Label label;
        private ErrorProvider errorOfferProvider;
        private PictureBox pbImage;
        private OpenFileDialog ofdPicture;
        private Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox4;
        private Label label6;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
    }
}