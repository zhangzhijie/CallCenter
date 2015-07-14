namespace FormUI
{
    partial class FDeptPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDeptPosition));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDeptPosition = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.DeptPost_PostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptPost_PostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptPost_DistPermission = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bdsDeptPosition = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 665);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSelectAll);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 40);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDeptPosition);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(488, 625);
            this.panel3.TabIndex = 1;
            // 
            // dgvDeptPosition
            // 
            this.dgvDeptPosition.AllowUserToAddRows = false;
            this.dgvDeptPosition.AllowUserToDeleteRows = false;
            this.dgvDeptPosition.AutoGenerateColumns = false;
            this.dgvDeptPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptPosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptPost_PostId,
            this.DeptPost_PostName,
            this.DeptPost_DistPermission});
            this.dgvDeptPosition.DataSource = this.bdsDeptPosition;
            this.dgvDeptPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeptPosition.Location = new System.Drawing.Point(0, 0);
            this.dgvDeptPosition.Name = "dgvDeptPosition";
            this.dgvDeptPosition.ReadOnly = true;
            this.dgvDeptPosition.RowTemplate.Height = 23;
            this.dgvDeptPosition.Size = new System.Drawing.Size(488, 625);
            this.dgvDeptPosition.TabIndex = 2;
            this.dgvDeptPosition.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeptPosition_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(177, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(11, 8);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(70, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(94, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "撤销";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DeptPost_PostId
            // 
            this.DeptPost_PostId.DataPropertyName = "PostId";
            this.DeptPost_PostId.HeaderText = "ID";
            this.DeptPost_PostId.Name = "DeptPost_PostId";
            this.DeptPost_PostId.ReadOnly = true;
            this.DeptPost_PostId.Visible = false;
            // 
            // DeptPost_PostName
            // 
            this.DeptPost_PostName.DataPropertyName = "PostName";
            this.DeptPost_PostName.HeaderText = "职位名称";
            this.DeptPost_PostName.Name = "DeptPost_PostName";
            this.DeptPost_PostName.ReadOnly = true;
            // 
            // DeptPost_DistPermission
            // 
            this.DeptPost_DistPermission.DataPropertyName = "IsChoice";
            this.DeptPost_DistPermission.HeaderText = "选择";
            this.DeptPost_DistPermission.Name = "DeptPost_DistPermission";
            this.DeptPost_DistPermission.ReadOnly = true;
            this.DeptPost_DistPermission.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FDeptPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 665);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FDeptPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分配职位";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDeptPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvDeptPosition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptPost_PostId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptPost_PostName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DeptPost_DistPermission;
        private System.Windows.Forms.BindingSource bdsDeptPosition;
    }
}