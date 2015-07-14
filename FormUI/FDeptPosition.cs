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
    public partial class FDeptPosition : Form
    {
        private long DeptmentId;

        private IList<Y_Position> postList;
        public FDeptPosition(long deptmentId)
        {
            this.DeptmentId = deptmentId;
            InitializeComponent();
            this.dgvDeptPosition.DataSource = this.bdsDeptPosition;
            SearchData();
        }

        private void SearchData()
        {
            Y_Position posiEntity = new Y_Position() { IsDistribution = true };
            postList = BllPosition.Select(posiEntity);

            if (postList == null || postList.Count == 0)
            {
                return;
            }

            Y_Dept_Position deptPosiEntity = new Y_Dept_Position() { DepartId = this.DeptmentId };
            var deptPosiList = BllDeptPosition.Select(deptPosiEntity);

            if (deptPosiList != null && deptPosiList.Count > 0)
            {
                foreach (var item in postList)
                {
                    item.IsChoice = false;
                    var pDeptPosiIEnum = deptPosiList.Where(m => m.PostId == item.PostId);
                    if (pDeptPosiIEnum.Any())
                    {
                        item.IsChoice = true;
                        item.PermissionId = pDeptPosiIEnum.First().PermissionId;
                    }
                }
            }
             this.bdsDeptPosition.DataSource = postList;
        }

        private void dgvDeptPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            string currentName = this.dgvDeptPosition.Columns[e.ColumnIndex].Name;

            if (currentName != "DeptPost_DistPermission")
                return;
            var currentCell = this.dgvDeptPosition.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string posiId = this.dgvDeptPosition.Rows[e.RowIndex].Cells["DeptPost_PostId"].Value.ToString();
            if (currentCell.Value == null)
            {
                currentCell.Value = false;
            }
            if ((bool)currentCell.Value)
            {
                currentCell.Value = false;
            }
            else
            {
                currentCell.Value = true;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (postList != null && postList.Count>0)
            {
                foreach (var item in postList)
                {
                    item.IsChoice = true;
                }
                this.bdsDeptPosition.DataSource = postList;
                this.dgvDeptPosition.Refresh();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (postList != null && postList.Count > 0)
            {
                foreach (var item in postList)
                {
                    item.IsChoice = false;
                }
                this.bdsDeptPosition.DataSource = postList;
                this.dgvDeptPosition.Refresh();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Y_Dept_Position> deptPostList = new List<Y_Dept_Position>();
            foreach (var item in postList)
            {
                if (item.IsChoice.GetValueOrDefault())
                {
                    Y_Dept_Position entity = new Y_Dept_Position() { DepartId = this.DeptmentId, PostId = item.PostId };
                    deptPostList.Add(entity);
                }
            }
            var result = BllDeptPosition.Update(deptPostList, this.DeptmentId);
            if (result.IsOK)
            {
                this.Dispose();
            }
            else
            {
                if (result.Data != null)
                {
                    MessageBox.Show(this, string.Format(result.Msg,result.Data), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, result.Msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
