namespace InventoryManagement.UI.Controls
{
    partial class ucSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgCategory = new System.Windows.Forms.DataGridView();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtUnitOfMeasurement = new System.Windows.Forms.TextBox();
            this.dtgUnitOfMeasurement = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteUnit = new System.Windows.Forms.Button();
            this.btnAddNewUnit = new System.Windows.Forms.Button();
            this.btnSaveUnit = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnAddNewCategory = new System.Windows.Forms.Button();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.clmCategoryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnitOfMeasurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCategory)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUnitOfMeasurement)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(114, 396);
            this.txtCategory.MaxLength = 50;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(219, 22);
            this.txtCategory.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category";
            // 
            // dtgCategory
            // 
            this.dtgCategory.AllowUserToAddRows = false;
            this.dtgCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCategoryNo,
            this.clmCategoryName});
            this.dtgCategory.Location = new System.Drawing.Point(3, 6);
            this.dtgCategory.MultiSelect = false;
            this.dtgCategory.Name = "dtgCategory";
            this.dtgCategory.ReadOnly = true;
            this.dtgCategory.RowHeadersVisible = false;
            this.dtgCategory.RowHeadersWidth = 51;
            this.dtgCategory.RowTemplate.Height = 24;
            this.dtgCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCategory.Size = new System.Drawing.Size(389, 369);
            this.dtgCategory.TabIndex = 1;
            this.dtgCategory.SelectionChanged += new System.EventHandler(this.dtgCategory_SelectionChanged);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.txtUnitOfMeasurement);
            this.pnlBody.Controls.Add(this.dtgUnitOfMeasurement);
            this.pnlBody.Controls.Add(this.txtCategory);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.dtgCategory);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 64);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1144, 616);
            this.pnlBody.TabIndex = 6;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnDeleteCategory);
            this.pnlFooter.Controls.Add(this.btnDeleteUnit);
            this.pnlFooter.Controls.Add(this.btnAddNewCategory);
            this.pnlFooter.Controls.Add(this.btnAddNewUnit);
            this.pnlFooter.Controls.Add(this.btnSaveCategory);
            this.pnlFooter.Controls.Add(this.btnSaveUnit);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 680);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1144, 70);
            this.pnlFooter.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1142, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1144, 64);
            this.pnlHeader.TabIndex = 4;
            // 
            // txtUnitOfMeasurement
            // 
            this.txtUnitOfMeasurement.Location = new System.Drawing.Point(863, 396);
            this.txtUnitOfMeasurement.MaxLength = 50;
            this.txtUnitOfMeasurement.Name = "txtUnitOfMeasurement";
            this.txtUnitOfMeasurement.Size = new System.Drawing.Size(219, 22);
            this.txtUnitOfMeasurement.TabIndex = 5;
            // 
            // dtgUnitOfMeasurement
            // 
            this.dtgUnitOfMeasurement.AllowUserToAddRows = false;
            this.dtgUnitOfMeasurement.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgUnitOfMeasurement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgUnitOfMeasurement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUnitOfMeasurement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmUnitOfMeasurement});
            this.dtgUnitOfMeasurement.Location = new System.Drawing.Point(752, 6);
            this.dtgUnitOfMeasurement.MultiSelect = false;
            this.dtgUnitOfMeasurement.Name = "dtgUnitOfMeasurement";
            this.dtgUnitOfMeasurement.ReadOnly = true;
            this.dtgUnitOfMeasurement.RowHeadersVisible = false;
            this.dtgUnitOfMeasurement.RowHeadersWidth = 51;
            this.dtgUnitOfMeasurement.RowTemplate.Height = 24;
            this.dtgUnitOfMeasurement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUnitOfMeasurement.Size = new System.Drawing.Size(389, 369);
            this.dtgUnitOfMeasurement.TabIndex = 4;
            this.dtgUnitOfMeasurement.SelectionChanged += new System.EventHandler(this.dtgUnitOfMeasurement_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(812, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Unit";
            // 
            // btnDeleteUnit
            // 
            this.btnDeleteUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteUnit.Location = new System.Drawing.Point(734, 12);
            this.btnDeleteUnit.Name = "btnDeleteUnit";
            this.btnDeleteUnit.Size = new System.Drawing.Size(131, 44);
            this.btnDeleteUnit.TabIndex = 5;
            this.btnDeleteUnit.Text = "Delete";
            this.btnDeleteUnit.UseVisualStyleBackColor = true;
            this.btnDeleteUnit.Click += new System.EventHandler(this.btnDeleteUnit_Click);
            // 
            // btnAddNewUnit
            // 
            this.btnAddNewUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewUnit.Location = new System.Drawing.Point(1004, 12);
            this.btnAddNewUnit.Name = "btnAddNewUnit";
            this.btnAddNewUnit.Size = new System.Drawing.Size(131, 44);
            this.btnAddNewUnit.TabIndex = 4;
            this.btnAddNewUnit.Text = "Add New";
            this.btnAddNewUnit.UseVisualStyleBackColor = true;
            this.btnAddNewUnit.Click += new System.EventHandler(this.btnAddNewUnit_Click);
            // 
            // btnSaveUnit
            // 
            this.btnSaveUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUnit.Location = new System.Drawing.Point(871, 12);
            this.btnSaveUnit.Name = "btnSaveUnit";
            this.btnSaveUnit.Size = new System.Drawing.Size(131, 44);
            this.btnSaveUnit.TabIndex = 3;
            this.btnSaveUnit.Text = "Save";
            this.btnSaveUnit.UseVisualStyleBackColor = true;
            this.btnSaveUnit.Click += new System.EventHandler(this.btnSaveUnit_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(7, 12);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(131, 44);
            this.btnDeleteCategory.TabIndex = 9;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.Location = new System.Drawing.Point(277, 12);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Size = new System.Drawing.Size(131, 44);
            this.btnAddNewCategory.TabIndex = 8;
            this.btnAddNewCategory.Text = "Add New";
            this.btnAddNewCategory.UseVisualStyleBackColor = true;
            this.btnAddNewCategory.Click += new System.EventHandler(this.btnAddNewCategory_Click);
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.Location = new System.Drawing.Point(144, 12);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(131, 44);
            this.btnSaveCategory.TabIndex = 7;
            this.btnSaveCategory.Text = "Save";
            this.btnSaveCategory.UseVisualStyleBackColor = true;
            this.btnSaveCategory.Click += new System.EventHandler(this.btnSaveCategory_Click);
            // 
            // clmCategoryNo
            // 
            this.clmCategoryNo.DataPropertyName = "Id";
            this.clmCategoryNo.HeaderText = "#";
            this.clmCategoryNo.MinimumWidth = 6;
            this.clmCategoryNo.Name = "clmCategoryNo";
            this.clmCategoryNo.ReadOnly = true;
            this.clmCategoryNo.Width = 40;
            // 
            // clmCategoryName
            // 
            this.clmCategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCategoryName.DataPropertyName = "CategoryName";
            this.clmCategoryName.HeaderText = "Category";
            this.clmCategoryName.MinimumWidth = 6;
            this.clmCategoryName.Name = "clmCategoryName";
            this.clmCategoryName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // clmUnitOfMeasurement
            // 
            this.clmUnitOfMeasurement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmUnitOfMeasurement.DataPropertyName = "UnitName";
            this.clmUnitOfMeasurement.HeaderText = "Unit";
            this.clmUnitOfMeasurement.MinimumWidth = 6;
            this.clmUnitOfMeasurement.Name = "clmUnitOfMeasurement";
            this.clmUnitOfMeasurement.ReadOnly = true;
            // 
            // ucSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucSettings";
            this.Size = new System.Drawing.Size(1144, 750);
            this.Load += new System.EventHandler(this.ucSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCategory)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUnitOfMeasurement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgCategory;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnitOfMeasurement;
        private System.Windows.Forms.DataGridView dtgUnitOfMeasurement;
        private System.Windows.Forms.Button btnDeleteUnit;
        private System.Windows.Forms.Button btnAddNewUnit;
        private System.Windows.Forms.Button btnSaveUnit;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnAddNewCategory;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCategoryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnitOfMeasurement;
    }
}
