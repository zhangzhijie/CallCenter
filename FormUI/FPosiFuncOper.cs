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
    public partial class FPosiFuncOper : Form
    {
        private IList<Y_Function> functionList;

        private IList<Y_Operation> operationList;

        private bool isInitOper = false;

        private long postId;

        private int? currentFuncId;

        private TreeNode selectedTreeNode;
        public FPosiFuncOper()
        {
            InitializeComponent();
        }

        public Ad.Util.ResultU InitCrol(string pPostId)
        {
            if (!Int64.TryParse(pPostId, out this.postId))
            {
                return new Ad.Util.ResultU { IsOK = false, Msg = "职位ID错误" };
            }
            functionList = BllFunction.Select();
            if (functionList == null || functionList.Count == 0)
            {
                return new Ad.Util.ResultU { IsOK = false, Msg = "功能列表为空，请先录入功能" };
            }

            operationList = BllOperation.Select();
            if (operationList == null || operationList.Count == 0)
            {
                return new Ad.Util.ResultU { IsOK = false, Msg = "操作列表为空，请先录入操作" };
            }
            // 绑定功能列表
            BindFunction();

            return new Ad.Util.ResultU(true);
        }

        private void BindFunction()
        {
            TreeNode root = new TreeNode("功能列表");
            root.Tag = null;
            foreach (var item in functionList)
            {
                TreeNode node = new TreeNode();
                node.Text = item.FunctionName;
                node.Tag = item;
                root.Nodes.Add(node);
            }
            this.trvFunction.Nodes.Add(root);
            this.trvFunction.ExpandAll();
        }


        private void trvFunction_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView treeView = (TreeView)sender;
            TreeNode treeNode = treeView.SelectedNode;
            if (treeNode.Tag != null)
            {
                treeNode.BackColor = Color.Blue;
                if (this.selectedTreeNode != null) 
                {
                    this.selectedTreeNode.BackColor = SystemColors.Window;
                }
                
                this.selectedTreeNode = treeNode;
                if (!this.isInitOper)
                {
                    this.bdsOperation.DataSource = this.operationList;
                    this.isInitOper = true;
                }
                foreach (var item in this.operationList)
                {
                    item.IsChoiced = false;
                }
                Y_Function fuctionNode = (Y_Function)treeNode.Tag;
                this.lblFuncName.Text = fuctionNode.FunctionName;
                this.currentFuncId = fuctionNode.FunctionId;
                Y_Post_Privilege pentity = new Y_Post_Privilege();
                pentity.PostId = this.postId;
                pentity.FunctionId = fuctionNode.FunctionId;
                pentity.OperationId = null;
                var searchList = BllPositionPrivilege.Select(pentity);
                if (searchList != null && searchList.Count > 0)
                {
                    foreach (var item in searchList)
                    {
                        var result = this.operationList.Where(m => m.OperationId == item.OperationId);
                        if (result != null && result.Count() > 0)
                        {
                            result.First().IsChoiced = true;
                        }
                    }
                }
                this.bdsOperation.DataSource = this.operationList;
                this.dgvOperationForFunc.Refresh();
            }
        }


        private void dgvOperationForFunc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView datagridview = (DataGridView)sender;
            if (e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)datagridview.Rows[e.RowIndex].Cells["Oper_Choice"];
                if ((bool)cell.Value)
                {
                    cell.Value = false;
                    
                }
                else
                {
                    cell.Value = true;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (this.operationList != null && this.isInitOper)
            {
                foreach (var item in this.operationList)
                {
                    item.IsChoiced = true;
                }
                this.bdsOperation.DataSource = this.operationList;
                this.dgvOperationForFunc.Refresh();
            }
            
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (this.operationList != null && this.isInitOper)
            {
                foreach (var item in this.operationList)
                {
                    item.IsChoiced = false;
                }
                this.bdsOperation.DataSource = this.operationList;
                this.dgvOperationForFunc.Refresh();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.lblTip.Text = string.Empty;
            if (this.currentFuncId == null )
            {
                MessageBox.Show("功能ID取得错误");
                return;
            }
            List<Y_Post_Privilege> uplist = new List<Y_Post_Privilege>();
            if (this.operationList != null)
            {
                foreach(var item in this.operationList)
                {
                    if (item.IsChoiced.GetValueOrDefault())
                    {
                        uplist.Add(new Y_Post_Privilege { PostId = this.postId, FunctionId = this.currentFuncId, OperationId = item.OperationId });
                    }
                }
            }
            var resultU = BllPositionPrivilege.UpdateAll(uplist, this.postId,this.currentFuncId.GetValueOrDefault());
            if (!resultU.IsOK)
            {
                MessageBox.Show(resultU.Msg);
                return;
            }
            this.lblTip.Text = "保存成功";
            ((FMain)this.Owner).BindPositionData();
        }
    }
}
