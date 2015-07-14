using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ad.Model.DbModel;
using Ad.Fw;

namespace FormUI
{
    public partial class FDepartmentEdit : Form
    {
        private Y_Department DepartmentEntity;
        public FDepartmentEdit()
        {
            InitializeComponent();
        }

        public bool SelectDepartmen(string deptId)
        {
            this.DepartmentEntity = BllDepartment.SelectByDeptID(deptId);
            if (this.DepartmentEntity != null)
            {
                this.txtDeptName.Text = this.DepartmentEntity.DepartName;
                return true;
            }
            return false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtDeptName.Text))
            {
                this.lblError.Text = "部门名称必须输入";
                return;
            }
            var result = BllDepartment.Update(this.DepartmentEntity.Code, this.txtDeptName.Text.Trim());
            if (result.IsOK)
            {
                ((FMain)(this.Owner)).RefreshTreeViewAndDataGridView();
                this.Dispose();
            }
            else
            {
                this.lblError.Text = result.Msg;
            }
        }
    }
}
