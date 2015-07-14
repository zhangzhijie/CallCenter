using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ad.Model.VModel;
using Ad.Model.DbModel;
using Ad.Fw;

namespace FormUI
{
    public partial class FManagerChoice : Form
    {
        public FManagerChoice()
        {
            InitializeComponent();
            IntiCtrol();
        }

        public void IntiCtrol()
        {
            var selValueList = BllORG_MEMBER.SearchManagerForAdd(new VManagerSel());
            if (selValueList == null || selValueList.Count == 0)
                return;
            List<Y_V_ORG_MEMBER> departmentList = new List<Y_V_ORG_MEMBER>();
            foreach (var item in selValueList)
            {
                if (departmentList.FindIndex(m => m.ORG_DEPARTMENT_ID == item.ORG_DEPARTMENT_ID) == -1)
                {
                    departmentList.Add(item);
                }
            }
            if (departmentList.Count > 0)
            {
                departmentList.Insert(0,new Y_V_ORG_MEMBER(){DEPARTMENTNAME="请选择",ORG_DEPARTMENT_ID=null});
                this.cmbDeptment.DataSource = departmentList;
                this.cmbDeptment.DisplayMember = "DEPARTMENTNAME";
                this.cmbDeptment.ValueMember = "ORG_DEPARTMENT_ID";
            }

            this.bdsManagerSelect.DataSource = selValueList;
        }

        public void BindData()
        {
            VManagerSel model = new VManagerSel();
            long deptId;
            if (this.cmbDeptment.SelectedValue != null)
            {
                if (long.TryParse(this.cmbDeptment.SelectedValue.ToString(), out deptId))
                {
                    model.DeptId = deptId;
                }
            }
            model.UserName = this.txtManagerName.Text;
            this.bdsManagerSelect.DataSource = BllORG_MEMBER.SearchManagerForAdd(model);
        }

        private void cmbDeptment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void txtManagerName_TextChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void dgvManagerSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            // 当前列名
            string currentColumnName = this.dgvManagerSelect.Columns[e.ColumnIndex].Name;
            string idStr = this.dgvManagerSelect.Rows[e.RowIndex].Cells["ORGMana_ID"].Value.ToString();
            string name = this.dgvManagerSelect.Rows[e.RowIndex].Cells["ORGMana_NAME"].Value.ToString();
            if (currentColumnName == "ORGMana_Choice")
            {
                if (idStr != null)
                {
                    long id;
                    if(long.TryParse(idStr,out id))
                    {
                        ((FManagerAdd)this.Owner).SetManager(name, id);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("员工ID格式错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("员工ID为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
