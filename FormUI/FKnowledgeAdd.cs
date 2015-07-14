using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ad.Model.VModel;
using Ad.Model.DbModel;
using Ad.Fw;
using Ad.Util;


namespace FormUI
{
    public partial class FKnowledgeAdd : Form
    {
        public FKnowledgeAdd()
        {
            InitializeComponent();
        }

        // 选择文件
        private void btnChoiceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xls|Word|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
                {
                    try
                    {
                        this.txtTitle.Text = ofd.SafeFileName.Substring(0, ofd.SafeFileName.LastIndexOf('.'));
                    }catch(Exception){

                    }
                }
                this.txtFilePath.Text = ofd.FileName;
            }
        }

        // 保存数据
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtTitle.Text))
            {
                this.lblError.Text = "标题不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtKeyWords.Text))
            {
                this.lblError.Text = "关键字不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtFilePath.Text))
            {
                this.lblError.Text = "文件路径不能为空";
                return;
            }
            if (!File.Exists(this.txtFilePath.Text))
            {
                this.lblError.Text = "指定的文件不存在";
                return;
            }
            VM_KnowledgeBase vEntity = new VM_KnowledgeBase();
            vEntity.Title = this.txtTitle.Text.Trim();
            vEntity.KeyWords = this.txtKeyWords.Text.Trim();
            vEntity.FilePath = this.txtFilePath.Text;
            ResultU result = BllKnowledgeBase.Insert(vEntity);
            if (result.IsOK)
            {
                ((FMain)this.Owner).BindKnowledgeBaseData();
                this.Dispose();
            }
            else
            {
                this.lblError.Text = result.Msg;
            }
        }
    }
}
