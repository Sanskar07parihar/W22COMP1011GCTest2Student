namespace InventoryManagement.UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlDisplayControl = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.flowPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenuHome = new System.Windows.Forms.Button();
            this.btnMenuInventory = new System.Windows.Forms.Button();
            this.btnMenuUsers = new System.Windows.Forms.Button();
            this.btnMenuSettings = new System.Windows.Forms.Button();
            this.lblBorder = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.flowPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDisplayControl
            // 
            this.pnlDisplayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayControl.Location = new System.Drawing.Point(131, 0);
            this.pnlDisplayControl.Name = "pnlDisplayControl";
            this.pnlDisplayControl.Size = new System.Drawing.Size(948, 740);
            this.pnlDisplayControl.TabIndex = 1;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.lblBorder);
            this.pnlMenu.Controls.Add(this.flowPanelMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(131, 740);
            this.pnlMenu.TabIndex = 0;
            // 
            // flowPanelMenu
            // 
            this.flowPanelMenu.Controls.Add(this.btnMenuHome);
            this.flowPanelMenu.Controls.Add(this.btnMenuInventory);
            this.flowPanelMenu.Controls.Add(this.btnMenuUsers);
            this.flowPanelMenu.Controls.Add(this.btnMenuSettings);
            this.flowPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.flowPanelMenu.Name = "flowPanelMenu";
            this.flowPanelMenu.Size = new System.Drawing.Size(131, 740);
            this.flowPanelMenu.TabIndex = 0;
            // 
            // btnMenuHome
            // 
            this.btnMenuHome.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMenuHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHome.Location = new System.Drawing.Point(3, 3);
            this.btnMenuHome.Name = "btnMenuHome";
            this.btnMenuHome.Size = new System.Drawing.Size(114, 45);
            this.btnMenuHome.TabIndex = 0;
            this.btnMenuHome.Tag = "1";
            this.btnMenuHome.Text = "Home";
            this.btnMenuHome.UseVisualStyleBackColor = false;
            this.btnMenuHome.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMenuInventory
            // 
            this.btnMenuInventory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMenuInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuInventory.Location = new System.Drawing.Point(3, 54);
            this.btnMenuInventory.Name = "btnMenuInventory";
            this.btnMenuInventory.Size = new System.Drawing.Size(114, 45);
            this.btnMenuInventory.TabIndex = 1;
            this.btnMenuInventory.Tag = "2";
            this.btnMenuInventory.Text = "Inventory";
            this.btnMenuInventory.UseVisualStyleBackColor = false;
            this.btnMenuInventory.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMenuUsers
            // 
            this.btnMenuUsers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMenuUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuUsers.Location = new System.Drawing.Point(3, 105);
            this.btnMenuUsers.Name = "btnMenuUsers";
            this.btnMenuUsers.Size = new System.Drawing.Size(114, 45);
            this.btnMenuUsers.TabIndex = 2;
            this.btnMenuUsers.Tag = "3";
            this.btnMenuUsers.Text = "Users";
            this.btnMenuUsers.UseVisualStyleBackColor = false;
            this.btnMenuUsers.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMenuSettings
            // 
            this.btnMenuSettings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMenuSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSettings.Location = new System.Drawing.Point(3, 156);
            this.btnMenuSettings.Name = "btnMenuSettings";
            this.btnMenuSettings.Size = new System.Drawing.Size(114, 45);
            this.btnMenuSettings.TabIndex = 3;
            this.btnMenuSettings.Tag = "4";
            this.btnMenuSettings.Text = "Settings";
            this.btnMenuSettings.UseVisualStyleBackColor = false;
            this.btnMenuSettings.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lblBorder
            // 
            this.lblBorder.BackColor = System.Drawing.SystemColors.Info;
            this.lblBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBorder.Location = new System.Drawing.Point(126, 0);
            this.lblBorder.Name = "lblBorder";
            this.lblBorder.Size = new System.Drawing.Size(5, 740);
            this.lblBorder.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 740);
            this.Controls.Add(this.pnlDisplayControl);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMenu.ResumeLayout(false);
            this.flowPanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDisplayControl;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel flowPanelMenu;
        private System.Windows.Forms.Button btnMenuHome;
        private System.Windows.Forms.Button btnMenuInventory;
        private System.Windows.Forms.Button btnMenuUsers;
        private System.Windows.Forms.Button btnMenuSettings;
        private System.Windows.Forms.Label lblBorder;
    }
}

