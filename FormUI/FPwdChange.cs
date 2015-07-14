using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using FormUI.Tool;
using Ad.Model.VModel;
using Ad.Security;
using Ad.Fw;

namespace FormUI
{
    public partial class FPwdChange : Form
    {
        public FPwdChange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginHelper.IsGodUser)
                return;
             this.lblError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtOriPwd.Text))
            {
                this.lblError.Text = "原始密码不能为空";
            }
            if (string.IsNullOrWhiteSpace(this.txtNewPwd.Text))
            {
                this.lblError.Text = "新密码不能为空";
                return;
            }
            if (!Regex.IsMatch(this.txtNewPwd.Text.Trim(), @"^[A-Za-z0-9]+$"))
            {
                this.lblError.Text = "新密码格式错误(只允许数字和字母)";
                return;
            }
            if (this.txtNewPwd.Text.Trim().Length < 6)
            {
                this.lblError.Text = "新密码长度至少为6位";
                return;
            }
            if (this.txtNewPwd.Text.Trim() != this.txtCofPwd.Text.Trim())
            {
                this.lblError.Text = "密码重复错误";
                return;
            }
            VManagerPwd model = new VManagerPwd();
            model.ManagerId = LoginHelper.GetManagerId();
            model.OriPwd = MD5.Instance.BuildFingerprint(this.txtOriPwd.Text.Trim());
            model.NewPwd = MD5.Instance.BuildFingerprint(this.txtNewPwd.Text.Trim());
            var result = BllManager.ChangePwd(model);
            if (result.IsOK)
            {
                MessageBox.Show("修改成功");
                this.Dispose();
            }
            else
            {
                this.lblError.Text = result.Msg;
            }

        }
    }
}
