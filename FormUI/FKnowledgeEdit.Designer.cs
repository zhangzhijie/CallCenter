namespace FormUI
{
    partial class FKnowledgeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKnowledgeEdit));
            this.lblError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnChoiceFile = new System.Windows.Forms.Button();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblKeyWords = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(78, 250);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(270, 51);
            this.lblError.TabIndex = 17;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(351, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(354, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "*";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(165, 322);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnChoiceFile
            // 
            this.btnChoiceFile.Location = new System.Drawing.Point(353, 204);
            this.btnChoiceFile.Name = "btnChoiceFile";
            this.btnChoiceFile.Size = new System.Drawing.Size(40, 23);
            this.btnChoiceFile.TabIndex = 13;
            this.btnChoiceFile.Text = "...";
            this.btnChoiceFile.UseVisualStyleBackColor = true;
            this.btnChoiceFile.Click += new System.EventHandler(this.btnChoiceFile_Click);
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(80, 98);
            this.txtKeyWords.MaxLength = 100;
            this.txtKeyWords.Multiline = true;
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(268, 57);
            this.txtKeyWords.TabIndex = 12;
            // 
            // lblFilePath
            // 
            this.lblFilePath.Location = new System.Drawing.Point(-3, 204);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(68, 23);
            this.lblFilePath.TabIndex = 7;
            this.lblFilePath.Text = "文件路径";
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKeyWords
            // 
            this.lblKeyWords.Location = new System.Drawing.Point(-3, 98);
            this.lblKeyWords.Name = "lblKeyWords";
            this.lblKeyWords.Size = new System.Drawing.Size(68, 23);
            this.lblKeyWords.TabIndex = 8;
            this.lblKeyWords.Text = "关键字";
            this.lblKeyWords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(80, 204);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(268, 21);
            this.txtFilePath.TabIndex = 10;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(80, 39);
            this.txtTitle.MaxLength = 100;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(268, 21);
            this.txtTitle.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(-5, 41);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 23);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "标题";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FKnowledgeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 414);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnChoiceFile);
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblKeyWords);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(424, 441);
            this.MinimumSize = new System.Drawing.Size(424, 441);
            this.Name = "FKnowledgeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改知识条目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnChoiceFile;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblKeyWords;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
    }
}