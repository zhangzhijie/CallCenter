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
using FormUI.Tool;


namespace FormUI
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();

            DeleteTempFile();
        }

        private void DeleteTempFile()
        {
            try
            {
                string dir = Path.Combine(Environment.CurrentDirectory, Ad.Util.Const.KnowledgeBaseDir);
                if (Directory.Exists(dir))
                {
                    Directory.Delete(dir, true);
                    Directory.CreateDirectory(dir);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 清空错误信息
            this.lblError.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(this.txtUser.Text))
            {
                this.lblError.Text = "用户不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtPwd.Text))
            {
                this.lblError.Text = "密码不能为空";
                return;
            }
            // 验证登陆
            var result = LoginHelper.ValidateLogin(this.txtUser.Text.Trim(), this.txtPwd.Text.Trim());
            if (result.IsOK)
            {
                //假设验证成功
                StaticStateHelper.IsLogin = true;
                this.Dispose();
            }else
            {
                this.lblError.Text = result.Msg;
            }

            
        }

        private void ptbTitleClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
