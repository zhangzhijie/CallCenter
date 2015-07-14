using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ad.Model.DbModel;
using Ad.Util;

namespace FormUI.Tool
{
    public class DeptNodeHelper
    {
        private static int RootCodeLenth = Const.DeptRootCode.Length;

        public static TreeNode SelectedTreeNode { get; set; }
        public static bool InitBindNode(TreeView treeView,IList<Y_Department> entityList)
        {
            if (entityList == null || entityList.Count <= 0)
            {
                return false;
            }

            var rootDeptList = entityList.Where(m => m.Code == Const.DeptRootCode);
            if (!rootDeptList.Any())
            {
                return false;
            }

            //根节点
            Y_Department rootDept = rootDeptList.First();
            rootDept.HasChild = true;
            TreeNode rootNode = new TreeNode(rootDept.DepartName);
            rootNode.Tag = rootDept;

            var firstLevelDeptList = entityList.Where(m => m.Code.Length == RootCodeLenth * 2);
            if (firstLevelDeptList.Any())
            {
                foreach (var item in firstLevelDeptList)
                {
                    TreeNode node = new TreeNode(item.DepartName);
                    node.Tag = item;
                    rootNode.Nodes.Add(node);
                    var secodeLevelDeptList = entityList.Where(m => m.Code.StartsWith(item.Code) && m.Code.Length == RootCodeLenth * 3);
                    if (secodeLevelDeptList.Any())
                    {
                        item.HasChild = true;
                        foreach (var item2 in secodeLevelDeptList)
                        {
                            TreeNode node2 = new TreeNode(item2.DepartName);
                            node2.Tag = item;
                            node.Nodes.Add(node2);
                        }
                    }
                }
            }
            rootNode.Expand();
            treeView.Nodes.Add(rootNode);
            treeView.SelectedNode = rootNode;
            return true;
        }

        public static bool BindNode(TreeNode parentNode, IList<Y_Department> entityList)
        {
            if (parentNode == null)
                return false;

            if (parentNode.Nodes.Count > 0)
            {
                for (int i = parentNode.Nodes.Count - 1; i >= 0; i--)
                {
                    parentNode.Nodes.RemoveAt(i);
                }
            }
            Y_Department parentEntity = (Y_Department)parentNode.Tag;
            var firstLevelList = entityList.Where(m => m.Code.Length == parentEntity.Code.Length + RootCodeLenth);
            if (firstLevelList.Any())
            {
                foreach (var item in firstLevelList)
                {
                    TreeNode node = new TreeNode(item.DepartName);
                    node.Tag = item;
                    parentNode.Nodes.Add(node);
                    var secodeLevelList = entityList.Where(m => m.Code.StartsWith(item.Code) && m.Code.Length == item.Code.Length + RootCodeLenth);
                    if (secodeLevelList.Any())
                    {
                        item.HasChild = true;
                        foreach (var item2 in secodeLevelList)
                        {
                            TreeNode node2 = new TreeNode(item2.DepartName);
                            node2.Tag = item2;
                            node.Nodes.Add(node2);
                        }
                    }
                }
            }
            parentNode.Expand();
            return true;
        }

    }
}
