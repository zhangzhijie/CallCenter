namespace FormUI
{
    partial class SplitPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.labPageInfo2 = new System.Windows.Forms.Label();
            this.labPageInfo = new System.Windows.Forms.Label();
            this.txtCurrentPage = new System.Windows.Forms.TextBox();
            this.labPage = new System.Windows.Forms.Label();
            this.labNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.Location = new System.Drawing.Point(212, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(38, 24);
            this.btnGo.TabIndex = 109;
            this.btnGo.TabStop = false;
            this.btnGo.Text = "跳转";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLast.Location = new System.Drawing.Point(93, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(24, 24);
            this.btnLast.TabIndex = 108;
            this.btnLast.TabStop = false;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(63, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 107;
            this.btnNext.TabStop = false;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.Location = new System.Drawing.Point(33, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(24, 24);
            this.btnPrev.TabIndex = 106;
            this.btnPrev.TabStop = false;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirst.Location = new System.Drawing.Point(3, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(24, 24);
            this.btnFirst.TabIndex = 105;
            this.btnFirst.TabStop = false;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // labPageInfo2
            // 
            this.labPageInfo2.AutoSize = true;
            this.labPageInfo2.Location = new System.Drawing.Point(47, 38);
            this.labPageInfo2.Name = "labPageInfo2";
            this.labPageInfo2.Size = new System.Drawing.Size(155, 12);
            this.labPageInfo2.TabIndex = 104;
            this.labPageInfo2.Text = "每页n条记录 共n页 n条记录";
            // 
            // labPageInfo
            // 
            this.labPageInfo.AutoSize = true;
            this.labPageInfo.Location = new System.Drawing.Point(255, 10);
            this.labPageInfo.Name = "labPageInfo";
            this.labPageInfo.Size = new System.Drawing.Size(155, 12);
            this.labPageInfo.TabIndex = 103;
            this.labPageInfo.Text = "每页n条记录 共n页 n条记录";
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.Location = new System.Drawing.Point(143, 5);
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(45, 21);
            this.txtCurrentPage.TabIndex = 102;
            this.txtCurrentPage.Text = "1";
            // 
            // labPage
            // 
            this.labPage.AutoSize = true;
            this.labPage.Location = new System.Drawing.Point(189, 10);
            this.labPage.Name = "labPage";
            this.labPage.Size = new System.Drawing.Size(17, 12);
            this.labPage.TabIndex = 101;
            this.labPage.Text = "页";
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Location = new System.Drawing.Point(125, 10);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(17, 12);
            this.labNum.TabIndex = 100;
            this.labNum.Text = "第";
            // 
            // SplitPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.labPageInfo2);
            this.Controls.Add(this.labPageInfo);
            this.Controls.Add(this.txtCurrentPage);
            this.Controls.Add(this.labPage);
            this.Controls.Add(this.labNum);
            this.Name = "SplitPage";
            this.Size = new System.Drawing.Size(606, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label labPageInfo2;
        private System.Windows.Forms.Label labPageInfo;
        private System.Windows.Forms.TextBox txtCurrentPage;
        private System.Windows.Forms.Label labPage;
        private System.Windows.Forms.Label labNum;
    }
}
