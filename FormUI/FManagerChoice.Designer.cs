namespace FormUI
{
    partial class FManagerChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FManagerChoice));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvManagerSelect = new System.Windows.Forms.DataGridView();
            this.ORGMana_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORGMana_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORGMana_Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORGMana_Choice = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bdsManagerSelect = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtManagerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDeptment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsManagerSelect)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 672);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvManagerSelect);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 619);
            this.panel3.TabIndex = 1;
            // 
            // dgvManagerSelect
            // 
            this.dgvManagerSelect.AllowUserToAddRows = false;
            this.dgvManagerSelect.AllowUserToDeleteRows = false;
            this.dgvManagerSelect.AutoGenerateColumns = false;
            this.dgvManagerSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagerSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ORGMana_NAME,
            this.ORGMana_ID,
            this.ORGMana_Dept,
            this.ORGMana_Choice});
            this.dgvManagerSelect.DataSource = this.bdsManagerSelect;
            this.dgvManagerSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvManagerSelect.Location = new System.Drawing.Point(0, 0);
            this.dgvManagerSelect.Name = "dgvManagerSelect";
            this.dgvManagerSelect.ReadOnly = true;
            this.dgvManagerSelect.RowTemplate.Height = 23;
            this.dgvManagerSelect.Size = new System.Drawing.Size(487, 619);
            this.dgvManagerSelect.TabIndex = 0;
            this.dgvManagerSelect.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagerSelect_CellContentClick);
            // 
            // ORGMana_NAME
            // 
            this.ORGMana_NAME.DataPropertyName = "NAME";
            this.ORGMana_NAME.HeaderText = "姓名";
            this.ORGMana_NAME.Name = "ORGMana_NAME";
            this.ORGMana_NAME.ReadOnly = true;
            // 
            // ORGMana_ID
            // 
            this.ORGMana_ID.DataPropertyName = "ID";
            this.ORGMana_ID.HeaderText = "ID";
            this.ORGMana_ID.Name = "ORGMana_ID";
            this.ORGMana_ID.ReadOnly = true;
            this.ORGMana_ID.Visible = false;
            // 
            // ORGMana_Dept
            // 
            this.ORGMana_Dept.DataPropertyName = "DEPARTMENTNAME";
            this.ORGMana_Dept.HeaderText = "部门";
            this.ORGMana_Dept.Name = "ORGMana_Dept";
            this.ORGMana_Dept.ReadOnly = true;
            this.ORGMana_Dept.Width = 150;
            // 
            // ORGMana_Choice
            // 
            this.ORGMana_Choice.HeaderText = "选择";
            this.ORGMana_Choice.Name = "ORGMana_Choice";
            this.ORGMana_Choice.ReadOnly = true;
            this.ORGMana_Choice.Text = "选择";
            this.ORGMana_Choice.UseColumnTextForButtonValue = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtManagerName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbDeptment);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 53);
            this.panel2.TabIndex = 0;
            // 
            // txtManagerName
            // 
            this.txtManagerName.Location = new System.Drawing.Point(243, 15);
            this.txtManagerName.Name = "txtManagerName";
            this.txtManagerName.Size = new System.Drawing.Size(113, 21);
            this.txtManagerName.TabIndex = 1;
            this.txtManagerName.TextChanged += new System.EventHandler(this.txtManagerName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "员工姓名";
            // 
            // cmbDeptment
            // 
            this.cmbDeptment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeptment.FormattingEnabled = true;
            this.cmbDeptment.Location = new System.Drawing.Point(47, 16);
            this.cmbDeptment.Name = "cmbDeptment";
            this.cmbDeptment.Size = new System.Drawing.Size(112, 20);
            this.cmbDeptment.TabIndex = 0;
            this.cmbDeptment.SelectedIndexChanged += new System.EventHandler(this.cmbDeptment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门";
            // 
            // FManagerChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 672);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FManagerChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择员工";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagerSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsManagerSelect)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvManagerSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbDeptment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManagerName;
        private System.Windows.Forms.BindingSource bdsManagerSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORGMana_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORGMana_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORGMana_Dept;
        private System.Windows.Forms.DataGridViewButtonColumn ORGMana_Choice;
    }
}