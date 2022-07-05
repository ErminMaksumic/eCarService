using System.Windows.Forms;

namespace eProdajaService.WinUI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.offersStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.myOffersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewOfferItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.myOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customServiceRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brandsStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.partsStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.myPartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratingsStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfileStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AllUsersStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lastYearRevenueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestSellingOfferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCreateService = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.offersStripMenu,
            this.ordersStripMenu,
            this.brandsStripMenu,
            this.partsStripMenu,
            this.ratingsStripMenu,
            this.myProfileStripMenu,
            this.AllUsersStripMenu,
            this.administrationStripMenu,
            this.reportsStripMenu,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // offersStripMenu
            // 
            this.offersStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myOffersItem,
            this.addNewOfferItem});
            this.offersStripMenu.Name = "offersStripMenu";
            this.offersStripMenu.Size = new System.Drawing.Size(51, 20);
            this.offersStripMenu.Text = "Offers";
            // 
            // myOffersItem
            // 
            this.myOffersItem.Name = "myOffersItem";
            this.myOffersItem.Size = new System.Drawing.Size(149, 22);
            this.myOffersItem.Text = "My offers";
            this.myOffersItem.Click += new System.EventHandler(this.myOffersItem_Click);
            // 
            // addNewOfferItem
            // 
            this.addNewOfferItem.Name = "addNewOfferItem";
            this.addNewOfferItem.Size = new System.Drawing.Size(149, 22);
            this.addNewOfferItem.Text = "Add new offer";
            this.addNewOfferItem.Click += new System.EventHandler(this.addNewOfferItem_Click);
            // 
            // ordersStripMenu
            // 
            this.ordersStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myOrdersToolStripMenuItem,
            this.customServiceRequestsToolStripMenuItem});
            this.ordersStripMenu.Name = "ordersStripMenu";
            this.ordersStripMenu.Size = new System.Drawing.Size(54, 20);
            this.ordersStripMenu.Text = "Orders";
            // 
            // myOrdersToolStripMenuItem
            // 
            this.myOrdersToolStripMenuItem.Name = "myOrdersToolStripMenuItem";
            this.myOrdersToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.myOrdersToolStripMenuItem.Text = "My orders";
            this.myOrdersToolStripMenuItem.Click += new System.EventHandler(this.myOrdersToolStripMenuItem_Click);
            // 
            // customServiceRequestsToolStripMenuItem
            // 
            this.customServiceRequestsToolStripMenuItem.Name = "customServiceRequestsToolStripMenuItem";
            this.customServiceRequestsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.customServiceRequestsToolStripMenuItem.Text = "Custom service requests";
            this.customServiceRequestsToolStripMenuItem.Click += new System.EventHandler(this.customServiceRequestsToolStripMenuItem_Click);
            // 
            // brandsStripMenu
            // 
            this.brandsStripMenu.Name = "brandsStripMenu";
            this.brandsStripMenu.Size = new System.Drawing.Size(55, 20);
            this.brandsStripMenu.Text = "Brands";
            this.brandsStripMenu.Click += new System.EventHandler(this.brandsToolStripMenuItem_Click);
            // 
            // partsStripMenu
            // 
            this.partsStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myPartsToolStripMenuItem,
            this.addNewPartToolStripMenuItem});
            this.partsStripMenu.Name = "partsStripMenu";
            this.partsStripMenu.Size = new System.Drawing.Size(45, 20);
            this.partsStripMenu.Text = "Parts";
            // 
            // myPartsToolStripMenuItem
            // 
            this.myPartsToolStripMenuItem.Name = "myPartsToolStripMenuItem";
            this.myPartsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.myPartsToolStripMenuItem.Text = "My parts";
            this.myPartsToolStripMenuItem.Click += new System.EventHandler(this.myPartsToolStripMenuItem_Click);
            // 
            // addNewPartToolStripMenuItem
            // 
            this.addNewPartToolStripMenuItem.Name = "addNewPartToolStripMenuItem";
            this.addNewPartToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.addNewPartToolStripMenuItem.Text = "Add new part";
            this.addNewPartToolStripMenuItem.Click += new System.EventHandler(this.addNewPartToolStripMenuItem_Click);
            // 
            // ratingsStripMenu
            // 
            this.ratingsStripMenu.Name = "ratingsStripMenu";
            this.ratingsStripMenu.Size = new System.Drawing.Size(58, 20);
            this.ratingsStripMenu.Text = "Ratings";
            this.ratingsStripMenu.Click += new System.EventHandler(this.ratingsItem_Click);
            // 
            // myProfileStripMenu
            // 
            this.myProfileStripMenu.Name = "myProfileStripMenu";
            this.myProfileStripMenu.Size = new System.Drawing.Size(73, 20);
            this.myProfileStripMenu.Text = "My profile";
            this.myProfileStripMenu.Click += new System.EventHandler(this.mProfileItem_Click);
            // 
            // AllUsersStripMenu
            // 
            this.AllUsersStripMenu.Name = "AllUsersStripMenu";
            this.AllUsersStripMenu.Size = new System.Drawing.Size(63, 20);
            this.AllUsersStripMenu.Text = "All users";
            this.AllUsersStripMenu.Click += new System.EventHandler(this.allUsersToolStripMenuItem_Click);
            // 
            // administrationStripMenu
            // 
            this.administrationStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.servicesItem,
            this.ratingsToolStripMenuItem1,
            this.additionalServicesToolStripMenuItem});
            this.administrationStripMenu.Name = "administrationStripMenu";
            this.administrationStripMenu.Size = new System.Drawing.Size(98, 20);
            this.administrationStripMenu.Text = "Administration";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // servicesItem
            // 
            this.servicesItem.Name = "servicesItem";
            this.servicesItem.Size = new System.Drawing.Size(174, 22);
            this.servicesItem.Text = "Services";
            this.servicesItem.Click += new System.EventHandler(this.servicesItem_Click);
            // 
            // ratingsToolStripMenuItem1
            // 
            this.ratingsToolStripMenuItem1.Name = "ratingsToolStripMenuItem1";
            this.ratingsToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.ratingsToolStripMenuItem1.Text = "Ratings";
            this.ratingsToolStripMenuItem1.Click += new System.EventHandler(this.ratingsToolStripMenuItem1_Click);
            // 
            // additionalServicesToolStripMenuItem
            // 
            this.additionalServicesToolStripMenuItem.Name = "additionalServicesToolStripMenuItem";
            this.additionalServicesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.additionalServicesToolStripMenuItem.Text = "Additional Services";
            this.additionalServicesToolStripMenuItem.Click += new System.EventHandler(this.additionalServicesToolStripMenuItem_Click);
            // 
            // reportsStripMenu
            // 
            this.reportsStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastYearRevenueToolStripMenuItem,
            this.bestSellingOfferToolStripMenuItem});
            this.reportsStripMenu.Name = "reportsStripMenu";
            this.reportsStripMenu.Size = new System.Drawing.Size(59, 20);
            this.reportsStripMenu.Text = "Reports";
            // 
            // lastYearRevenueToolStripMenuItem
            // 
            this.lastYearRevenueToolStripMenuItem.Name = "lastYearRevenueToolStripMenuItem";
            this.lastYearRevenueToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.lastYearRevenueToolStripMenuItem.Text = "Last year revenue";
            this.lastYearRevenueToolStripMenuItem.Click += new System.EventHandler(this.lastYearRevenueToolStripMenuItem_Click);
            // 
            // bestSellingOfferToolStripMenuItem
            // 
            this.bestSellingOfferToolStripMenuItem.Name = "bestSellingOfferToolStripMenuItem";
            this.bestSellingOfferToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bestSellingOfferToolStripMenuItem.Text = "Best selling offer";
            this.bestSellingOfferToolStripMenuItem.Click += new System.EventHandler(this.bestSellingOfferToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // administrationToolStripMenuItem1
            // 
            this.administrationToolStripMenuItem1.Enabled = false;
            this.administrationToolStripMenuItem1.Name = "administrationToolStripMenuItem1";
            this.administrationToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.administrationToolStripMenuItem1.Text = "Administration";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::eCarService.DesktopApp.Properties.Resources.modern_car_repair_station_with_large_number_lifts_specialized_equipment_diagnostics_service_repair_car_283617_3976;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnCreateService
            // 
            this.btnCreateService.BackColor = System.Drawing.Color.IndianRed;
            this.btnCreateService.Location = new System.Drawing.Point(181, 204);
            this.btnCreateService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateService.Name = "btnCreateService";
            this.btnCreateService.Size = new System.Drawing.Size(255, 80);
            this.btnCreateService.TabIndex = 7;
            this.btnCreateService.Text = "Create your CAR SERVICE to access your panel!";
            this.btnCreateService.UseVisualStyleBackColor = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblUserName.Location = new System.Drawing.Point(340, 117);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 37);
            this.lblUserName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label1.Location = new System.Drawing.Point(153, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "Welcome back: ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 293);
            this.Controls.Add(this.btnCreateService);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem offersStripMenu;
        private ToolStripMenuItem myOffersItem;
        private ToolStripMenuItem addNewOfferItem;
        private ToolStripMenuItem ordersStripMenu;
        private ToolStripMenuItem ratingsStripMenu;
        private ToolStripMenuItem myProfileStripMenu;
        private ToolStripMenuItem reportsStripMenu;
        private ToolStripMenuItem administrationStripMenu;
        private ToolStripMenuItem administrationToolStripMenuItem1;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem servicesItem;
        private ToolStripMenuItem ratingsToolStripMenuItem1;
        private ToolStripMenuItem lastYearRevenueToolStripMenuItem;
        private ToolStripMenuItem bestSellingOfferToolStripMenuItem;
        private ToolStripMenuItem partsStripMenu;
        private ToolStripMenuItem myPartsToolStripMenuItem;
        private ToolStripMenuItem addNewPartToolStripMenuItem;
        private ToolStripMenuItem brandsStripMenu;
        private ToolStripMenuItem AllUsersStripMenu;
        private ToolStripMenuItem additionalServicesToolStripMenuItem;
        private ToolStripMenuItem myOrdersToolStripMenuItem;
        private ToolStripMenuItem customServiceRequestsToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private PictureBox pictureBox1;
        private Button btnCreateService;
        private Label lblUserName;
        private Label label1;
    }
}