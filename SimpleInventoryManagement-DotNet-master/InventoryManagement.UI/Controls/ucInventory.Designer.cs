namespace InventoryManagement.UI.Controls
{
    partial class ucInventory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnInventoryStatus = new System.Windows.Forms.Button();
            this.dtgInventory = new System.Windows.Forms.DataGridView();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnInventoryIn = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnInventoryOut = new System.Windows.Forms.Button();
            this.btnInventoryOutRecord = new System.Windows.Forms.Button();
            this.btnInventoryInRecord = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventory)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInventoryStatus
            // 
            this.btnInventoryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventoryStatus.Location = new System.Drawing.Point(785, 10);
            this.btnInventoryStatus.Name = "btnInventoryStatus";
            this.btnInventoryStatus.Size = new System.Drawing.Size(131, 44);
            this.btnInventoryStatus.TabIndex = 2;
            this.btnInventoryStatus.Text = "Inventory";
            this.btnInventoryStatus.UseVisualStyleBackColor = true;
            this.btnInventoryStatus.Click += new System.EventHandler(this.btnInventoryStatus_Click);
            // 
            // dtgInventory
            // 
            this.dtgInventory.AllowUserToAddRows = false;
            this.dtgInventory.AllowUserToDeleteRows = false;
            this.dtgInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInventory.Location = new System.Drawing.Point(3, 6);
            this.dtgInventory.MultiSelect = false;
            this.dtgInventory.Name = "dtgInventory";
            this.dtgInventory.ReadOnly = true;
            this.dtgInventory.RowHeadersVisible = false;
            this.dtgInventory.RowHeadersWidth = 51;
            this.dtgInventory.RowTemplate.Height = 24;
            this.dtgInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInventory.Size = new System.Drawing.Size(1188, 641);
            this.dtgInventory.TabIndex = 1;
            this.dtgInventory.SelectionChanged += new System.EventHandler(this.dtgInventory_SelectionChanged);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.dtgInventory);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 64);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1197, 653);
            this.pnlBody.TabIndex = 6;
            // 
            // btnInventoryIn
            // 
            this.btnInventoryIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventoryIn.Location = new System.Drawing.Point(1059, 10);
            this.btnInventoryIn.Name = "btnInventoryIn";
            this.btnInventoryIn.Size = new System.Drawing.Size(131, 44);
            this.btnInventoryIn.TabIndex = 4;
            this.btnInventoryIn.Text = "In";
            this.btnInventoryIn.UseVisualStyleBackColor = true;
            this.btnInventoryIn.Click += new System.EventHandler(this.btnInventoryIn_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnInventoryOut);
            this.pnlFooter.Controls.Add(this.btnInventoryOutRecord);
            this.pnlFooter.Controls.Add(this.btnInventoryInRecord);
            this.pnlFooter.Controls.Add(this.btnInventoryStatus);
            this.pnlFooter.Controls.Add(this.btnInventoryIn);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 717);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1197, 70);
            this.pnlFooter.TabIndex = 5;
            // 
            // btnInventoryOut
            // 
            this.btnInventoryOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventoryOut.Location = new System.Drawing.Point(922, 10);
            this.btnInventoryOut.Name = "btnInventoryOut";
            this.btnInventoryOut.Size = new System.Drawing.Size(131, 44);
            this.btnInventoryOut.TabIndex = 3;
            this.btnInventoryOut.Text = "Out";
            this.btnInventoryOut.UseVisualStyleBackColor = true;
            this.btnInventoryOut.Click += new System.EventHandler(this.btnInventoryOut_Click);
            // 
            // btnInventoryOutRecord
            // 
            this.btnInventoryOutRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventoryOutRecord.Location = new System.Drawing.Point(511, 10);
            this.btnInventoryOutRecord.Name = "btnInventoryOutRecord";
            this.btnInventoryOutRecord.Size = new System.Drawing.Size(131, 44);
            this.btnInventoryOutRecord.TabIndex = 0;
            this.btnInventoryOutRecord.Text = "Inventory Out Record";
            this.btnInventoryOutRecord.UseVisualStyleBackColor = true;
            this.btnInventoryOutRecord.Click += new System.EventHandler(this.btnInventoryOutRecord_Click);
            // 
            // btnInventoryInRecord
            // 
            this.btnInventoryInRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventoryInRecord.Location = new System.Drawing.Point(648, 10);
            this.btnInventoryInRecord.Name = "btnInventoryInRecord";
            this.btnInventoryInRecord.Size = new System.Drawing.Size(131, 44);
            this.btnInventoryInRecord.TabIndex = 1;
            this.btnInventoryInRecord.Text = "Inventory In Record";
            this.btnInventoryInRecord.UseVisualStyleBackColor = true;
            this.btnInventoryInRecord.Click += new System.EventHandler(this.btnInventoryInRecord_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1195, 62);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Inventory";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1197, 64);
            this.pnlHeader.TabIndex = 4;
            // 
            // ucInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucInventory";
            this.Size = new System.Drawing.Size(1197, 787);
            this.Load += new System.EventHandler(this.ucInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventory)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInventoryStatus;
        private System.Windows.Forms.DataGridView dtgInventory;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnInventoryIn;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnInventoryInRecord;
        private System.Windows.Forms.Button btnInventoryOutRecord;
        private System.Windows.Forms.Button btnInventoryOut;
    }
}
