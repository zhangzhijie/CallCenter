namespace FormUI.Plug
{
    partial class TelephoneControl
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnl01 = new System.Windows.Forms.Panel();
            this.lblSeat = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.picTele = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnl01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTele)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnl01);
            this.pnlLeft.Controls.Add(this.picTele);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(120, 150);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnl01
            // 
            this.pnl01.Controls.Add(this.lblUserName);
            this.pnl01.Controls.Add(this.lblState);
            this.pnl01.Controls.Add(this.lblSeat);
            this.pnl01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl01.Location = new System.Drawing.Point(0, 60);
            this.pnl01.Name = "pnl01";
            this.pnl01.Size = new System.Drawing.Size(120, 90);
            this.pnl01.TabIndex = 1;
            // 
            // lblSeat
            // 
            this.lblSeat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSeat.ForeColor = System.Drawing.Color.Green;
            this.lblSeat.Location = new System.Drawing.Point(0, 56);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(120, 34);
            this.lblSeat.TabIndex = 1;
            this.lblSeat.Text = "01";
            this.lblSeat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSeat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // lblState
            // 
            this.lblState.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(120, 34);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "空闲";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblState.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // picTele
            // 
            this.picTele.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTele.ErrorImage = global::FormUI.Properties.Resources.standby88;
            this.picTele.Image = global::FormUI.Properties.Resources.standby88;
            this.picTele.Location = new System.Drawing.Point(0, 0);
            this.picTele.Name = "picTele";
            this.picTele.Size = new System.Drawing.Size(120, 60);
            this.picTele.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTele.TabIndex = 0;
            this.picTele.TabStop = false;
            this.picTele.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // lblUserName
            // 
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserName.Location = new System.Drawing.Point(0, 34);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(120, 22);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "小明";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TelephoneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLeft);
            this.Name = "TelephoneControl";
            this.Size = new System.Drawing.Size(120, 150);
            this.pnlLeft.ResumeLayout(false);
            this.pnl01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTele)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picTele;
        private System.Windows.Forms.Panel pnl01;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblUserName;

    }
}
