using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ad.Fw;

namespace FormUI
{
    public partial class FDepartmentAdd : Form
    {
        private string ParentCode;
        //public FDepartmentAdd()
        //{
        //    InitializeComponent();
        //}

        public FDepartmentAdd(string parentCode)
        {
            this.ParentCode = parentCode;
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.ParentCode))
            {
                this.lblError.Text = "父级部门编号为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtDeptName.Text))
            {
                this.lblError.Text = "部门名称必须输入";
                return;
            }
            var result = BllDepartment.Insert(this.ParentCode, this.txtDeptName.Text.Trim());
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
