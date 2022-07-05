using System.Windows.Forms;

namespace eProdajaService.WinUI.MyProfile
{
    partial class myProfile
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
            this.pbProfileImage = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.errorProfileProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtConfirmationPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ofdChangeImage = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfileImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProfileProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProfileImage
            // 
            this.pbProfileImage.Location = new System.Drawing.Point(79, 12);
            this.pbProfileImage.Name = "pbProfileImage";
            this.pbProfileImage.Size = new System.Drawing.Size(332, 178);
            this.pbProfileImage.TabIndex = 0;
            this.pbProfileImage.TabStop = false;
            this.pbProfileImage.Click += new System.EventHandler(this.pbProfileImage_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(212, 217);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(230, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(212, 264);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(230, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(335, 366);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(107, 29);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Save changes";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // errorProfileProvider
            // 
            this.errorProfileProvider.ContainerControl = this;
            // 
            // txtConfirmationPassword
            // 
            this.txtConfirmationPassword.Location = new System.Drawing.Point(212, 308);
            this.txtConfirmationPassword.Name = "txtConfirmationPassword";
            this.txtConfirmationPassword.PasswordChar = '*';
            this.txtConfirmationPassword.Size = new System.Drawing.Size(230, 27);
            this.txtConfirmationPassword.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Confirm new password:";
            // 
            // ofdChangeImage
            // 
            this.ofdChangeImage.FileName = "openFileDialog1";
            // 
            // myProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmationPassword);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pbProfileImage);
            this.Name = "myProfile";
            this.Text = "My profile";
            this.Load += new System.EventHandler(this.myProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfileImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProfileProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbProfileImage;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Button btnSubmit;
        private ErrorProvider errorProfileProvider;
        private Label label3;
        private TextBox txtConfirmationPassword;
        private OpenFileDialog ofdChangeImage;
    }
}