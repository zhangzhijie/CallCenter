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
using Ad.Fw;

namespace FormUI
{
    public partial class FManagerEdit : Form
    {
        private Y_Manager CurrentManagerEntity = new Y_Manager();

        private string UserName;

        private long DeptId;

        private long PostId;

        private bool IsInitPost = true;
        public FManagerEdit(Y_V_Manager entity)
        {
            this.CurrentManagerEntity.ManagerId = entity.ManagerId;
            this.CurrentManagerEntity.Channel = entity.Channel;
            this.CurrentManagerEntity.IsUse = entity.IsUse;
            this.CurrentManagerEntity.LoginName = entity.LoginName;
            this.CurrentManagerEntity.PermissionId = entity.PermissionId;
            //this.CurrentManagerEntity.Pwd = entity.Pwd;
            this.DeptId = entity.DepartId.Value;
            this.PostId = entity.PostId.Value;
            this.UserName = entity.NAME;

            this.InitializeComponent();

            this.InitControl();
        }

        private void InitControl()
        {
            this.txtUser.Text = this.UserName;
            this.txtLoginName.Text = this.CurrentManagerEntity.LoginName;
            this.txtChannel.Text = this.CurrentManagerEntity.Channel;

            // 初始化 部门
            var deptList = DeptPosiHelper.GetDepartMent();
            if (deptList == null || deptList.Count == 0)
                return;

            this.cmbDept.DataSource = deptList;
            this.cmbDept.DisplayMember = "DepartName";
            this.cmbDept.ValueMember = "DepartId";

            this.cmbPosition.DisplayMember = "PostName";
            this.cmbPosition.ValueMember = "PostId";

            this.cmbDept.SelectedValue = this.DeptId;
        }

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
            if (this.cmbDept.SelectedValue.ToString().Equals(this.DeptId.ToString()) && this.IsInitPost)
            {
                try
                {
                    this.cmbPosition.SelectedValue = this.PostId;
                    this.IsInitPost = false;
                }
                catch (Exception)
                {

                }

            } 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
            if (this.CurrentManagerEntity.ManagerId == 0)
            {
                this.lblError.Text = "员工ID不能为空";
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
            if (string.IsNullOrWhiteSpace(this.txtChannel.Text))
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
            this.CurrentManagerEntity.PermissionId = pIEnum.First().PermissionId;
            this.CurrentManagerEntity.LoginName = this.txtLoginName.Text.Trim();
            this.CurrentManagerEntity.Channel = this.txtChannel.Text.Trim();

            var result = BllManager.Update(this.CurrentManagerEntity);
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
