namespace FormUI
{
    partial class FPosiFuncOper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPosiFuncOper));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trvFunction = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvOperationForFunc = new System.Windows.Forms.DataGridView();
            this.lblFuncName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.bdsOperation = new System.Windows.Forms.BindingSource(this.components);
            this.OperationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oper_Choice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationForFunc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOperation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 672);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trvFunction);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(147, 672);
            this.panel2.TabIndex = 0;
            // 
            // trvFunction
            // 
            this.trvFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFunction.Location = new System.Drawing.Point(0, 0);
            this.trvFunction.Name = "trvFunction";
            this.trvFunction.Size = new System.Drawing.Size(147, 672);
            this.trvFunction.TabIndex = 1;
            this.trvFunction.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFunction_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(147, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(485, 672);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTip);
            this.panel4.Controls.Add(this.btnSelectAll);
            this.panel4.Controls.Add(this.btnClearAll);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.lblFuncName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(485, 34);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvOperationForFunc);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(485, 638);
            this.panel5.TabIndex = 1;
            // 
            // dgvOperationForFunc
            // 
            this.dgvOperationForFunc.AllowUserToAddRows = false;
            this.dgvOperationForFunc.AllowUserToDeleteRows = false;
            this.dgvOperationForFunc.AutoGenerateColumns = false;
            this.dgvOperationForFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperationForFunc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OperationId,
            this.OperationName,
            this.Oper_Choice});
            this.dgvOperationForFunc.DataSource = this.bdsOperation;
            this.dgvOperationForFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperationForFunc.Location = new System.Drawing.Point(0, 0);
            this.dgvOperationForFunc.Name = "dgvOperationForFunc";
            this.dgvOperationForFunc.RowTemplate.Height = 23;
            this.dgvOperationForFunc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperationForFunc.Size = new System.Drawing.Size(485, 638);
            this.dgvOperationForFunc.TabIndex = 0;
            this.dgvOperationForFunc.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOperationForFunc_CellMouseClick);
            // 
            // lblFuncName
            // 
            this.lblFuncName.AutoSize = true;
            this.lblFuncName.Location = new System.Drawing.Point(15, 9);
            this.lblFuncName.Name = "lblFuncName";
            this.lblFuncName.Size = new System.Drawing.Size(0, 12);
            this.lblFuncName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(426, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OperationId
            // 
            this.OperationId.DataPropertyName = "OperationId";
            this.OperationId.HeaderText = "操作ID";
            this.OperationId.Name = "OperationId";
            this.OperationId.ReadOnly = true;
            this.OperationId.Visible = false;
            // 
            // OperationName
            // 
            this.OperationName.DataPropertyName = "OperationName";
            this.OperationName.HeaderText = "操作名称";
            this.OperationName.Name = "OperationName";
            this.OperationName.ReadOnly = true;
            // 
            // Oper_Choice
            // 
            this.Oper_Choice.DataPropertyName = "IsChoiced";
            this.Oper_Choice.HeaderText = "选择";
            this.Oper_Choice.Name = "Oper_Choice";
            this.Oper_Choice.ReadOnly = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(373, 6);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(47, 23);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "清除";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(318, 6);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(47, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.Lime;
            this.lblTip.Location = new System.Drawing.Point(127, 11);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 12);
            this.lblTip.TabIndex = 2;
            // 
            // FPosiFuncOper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 672);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FPosiFuncOper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "功能操作";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationForFunc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOperation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView trvFunction;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvOperationForFunc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblFuncName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource bdsOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Oper_Choice;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label lblTip;
    }
}