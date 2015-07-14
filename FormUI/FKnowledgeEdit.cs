using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ad.Fw;
using Ad.Model.DbModel;
using Ad.Model.VModel;

namespace FormUI
{
    public partial class FKnowledgeEdit : Form
    {
        private string knowledgeCode;
        public FKnowledgeEdit()
        {
            InitializeComponent();
        }

        // 绑定初始数据
        public bool BindData(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }
            this.knowledgeCode = code;
            var knowledgeBaseList = BllKnowledgeBase.Select(new string[] {Y_KnowledgeBase_Description.Title, Y_KnowledgeBase_Description.KeyWords },
                string.Format(@"{0}=@{0}", Y_KnowledgeBase_Description.KnowledgeCode), new object[] { code }, false);
            if (knowledgeBaseList == null && knowledgeBaseList.Count == 0)
            {
                return false;
            }
            Y_KnowledgeBase entity = knowledgeBaseList.First();
            this.txtTitle.Text = entity.Title;
            this.txtKeyWords.Text = entity.KeyWords;
            return true;
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
                    }
                    catch (Exception)
                    {

                    }
                }
                this.txtFilePath.Text = ofd.FileName;
            }
        }

        // 提交
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
            if (!string.IsNullOrWhiteSpace(this.txtFilePath.Text) && !File.Exists(this.txtFilePath.Text))
            {
                this.lblError.Text = "指定的文件不存在";
                return;
            }
            VM_KnowledgeBase vEntity = new VM_KnowledgeBase();
            try
            {
                vEntity.KnowledgeCode = Convert.ToInt64(this.knowledgeCode);
            }
            catch (Exception)
            {
                this.lblError.Text = "资料Id转换失败";
                return;
            }
            vEntity.Title = this.txtTitle.Text.Trim();
            vEntity.KeyWords = this.txtKeyWords.Text.Trim();
            vEntity.FilePath = this.txtFilePath.Text;
            Ad.Util.ResultU result = BllKnowledgeBase.Update(vEntity);
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
