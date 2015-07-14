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
using Ad.Model.DbModel;
using Ad.Util;
using Ad.Fw;

namespace FormUI
{
    public partial class FManagerAdd : Form
    {
        private long ManagerId = 0;
        public FManagerAdd()
        {
            InitializeComponent();
            InitControl();
        }

        public void SetManager(string managerName, long managerId)
        {
            this.ManagerId = managerId;
            this.txtUser.Text = managerName;
        }
        private void InitControl()
        {
            // 初始密码
            this.txtPwd1.Text = Const.InitPwd;
            this.txtPwd2.Text = Const.InitPwd;


            // 初始化 部门
            var deptList = DeptPosiHelper.GetDepartMent();
            if (deptList == null || deptList.Count == 0)
                return;

            //deptList.Insert(0, new Y_Department() { DepartName = "请选择", DepartId = null });
            this.cmbDept.DataSource = deptList;
            this.cmbDept.DisplayMember = "DepartName";
            this.cmbDept.ValueMember = "DepartId";


            this.cmbPosition.DisplayMember = "PostName";
            this.cmbPosition.ValueMember="PostId";
        }

        // 部门改变
        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDept.SelectedValue == null)
            {
                this.cmbPosition.DataSource = new List<Y_Position>();
                return;
            }

            var deptPosiList = DeptPosiHelper.GetDeptPosition();
            if (deptPosiList == null)
                return;

            var ls = deptPosiList.Where(m => m.DepartId.ToString().Equals(this.cmbDept.SelectedValue.ToString()));
            if (!ls.Any())
                return;

            var positionList = DeptPosiHelper.GetPosition();
            List<Y_Position> toPosiDisplayList = new List<Y_Position>();
            foreach (var item in ls)
            {
                var postIEnum = positionList.Where(m => m.PostId.ToString().Equals(item.PostId.ToString()));
                if (postIEnum.Any())
                {
                    toPosiDisplayList.Add(postIEnum.First());
                }
            }
            if (toPosiDisplayList.Count > 0)
            {
                toPosiDisplayList.Insert(0, new Y_Position() { PostName = "请选择", PostId = null });
            }
            this.cmbPosition.DataSource = toPosiDisplayList;
        }

        // 选择员工
        private void btnAddManager_Click(object sender, EventArgs e)
        {
            FManagerChoice fManagerChoice = new FManagerChoice();
            fManagerChoice.Owner = this;
            fManagerChoice.ShowDialog();
        }

        //提交
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
            if (ManagerId == 0)
            {
                this.lblError.Text = "员工ID不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtUser.Text))
            {
                this.lblError.Text = "员工姓名不能为空";
                return;
            }
            if (this.cmbDept.SelectedValue == null)
            {
                this.lblError.Text = "部门不能为空";
                return;
            }
            if (this.cmbPosition.SelectedValue == null)
            {
                this.lblError.Text = "职位不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtLoginName.Text))
            {
                this.lblError.Text = "登录名不能为空";
                return;
            }
            if (!Regex.IsMatch(this.txtLoginName.Text.Trim(), @"^\w+$"))
            {
                this.lblError.Text = "登录名格式错误(只允许数字，下划线，字母组成)";
                return;
            }
            if (this.txtLoginName.Text.Trim().Length < 6) 
            {
                this.lblError.Text = "登录名长度至少6位";
                return;
            }
            if (this.txtLoginName.Text.Trim().Length < 6)
            {
                this.lblError.Text = "登录名长度至少6位";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtPwd1.Text))
            {
                this.lblError.Text = "密码不能为空";
                return;
            }
            if (!Regex.IsMatch(this.txtPwd1.Text.Trim(), @"^[A-Za-z0-9]+$"))
            {
                this.lblError.Text = "密码格式错误(只允许数字和字母)";
                return;
            }
            if (this.txtPwd1.Text.Trim().Length < 6)
            {
                this.lblError.Text = "密码长度至少为6位";
                return;
            }
            if (this.txtPwd1.Text.Trim() != this.txtPwd2.Text.Trim())
            {
                this.lblError.Text = "密码重复错误";
                return;
            }
            if(string.IsNullOrWhiteSpace(this.txtChannel.Text))
            {
                this.lblError.Text = "通道不能为空";
                return;
            }
            if (!Regex.IsMatch(this.txtChannel.Text.Trim(), @"^[0-9]+[0-9,]*[0-9]+$"))
            {
                this.lblError.Text = "通道格式错误(应该形如601或601,602,603)";
                return;
            }

            var pIEnum = DeptPosiHelper.GetDeptPosition().Where(m => m.DepartId.ToString().Equals(this.cmbDept.SelectedValue.ToString()) &&
                m.PostId.ToString().Equals(this.cmbPosition.SelectedValue.ToString()));
            if (!pIEnum.Any())
            {
                this.lblError.Text = "选择的权限ID为空";
            }


            Y_Manager entity = new Y_Manager();
            entity.ManagerId = this.ManagerId;
            entity.PermissionId = pIEnum.First().PermissionId;
            entity.LoginName = this.txtLoginName.Text.Trim();
            entity.Pwd = Ad.Security.MD5.Instance.BuildFingerprint(this.txtPwd1.Text.Trim());
            entity.IsUse = true;
            entity.Channel = this.txtChannel.Text.Trim();

            var result = BllManager.Insert(entity);
            if (result.IsOK)
            {
                ((FMain)this.Owner).BindManagerData();
                this.Dispose();
            }
            else
            {
                this.lblError.Text = result.Msg;
            }
        }


    }
}
