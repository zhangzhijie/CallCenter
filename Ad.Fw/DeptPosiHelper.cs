using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.Model.DbModel;
using Ad.DA;
using Ad.Util;

namespace Ad.Fw
{
    public static class DeptPosiHelper
    {
        private static int RootCodeLen = Const.DeptRootCode.Length;

        private static IList<Y_Department> DepartmentList;

        private static IList<Y_Position> PositionList;

        private static IList<Y_Dept_Position> DeptPositionList;
        static DeptPosiHelper()
        {
            DeptPosiHelper.DeptPositionList = BllDeptPosition.Select(new Y_Dept_Position());
            if (DeptPositionList == null || DeptPositionList.Count == 0)
                return;

            var allDeptList = BllDepartment.SelectByParentCode(Const.DeptRootCode);
            if (allDeptList == null || allDeptList.Count == 0)
                return;

            List<string> deptIdList = new List<string>();
            List<string> posiIdList = new List<string>();
            foreach (var deptPosiEntity in DeptPositionList)
            {
                if (deptIdList.FindIndex(s => s == deptPosiEntity.DepartId.ToString()) == -1)
                {
                    deptIdList.Add(deptPosiEntity.DepartId.ToString());
                }
                if (posiIdList.FindIndex(s => s == deptPosiEntity.PostId.ToString()) == -1)
                {
                    posiIdList.Add(deptPosiEntity.PostId.ToString());
                }
            }
            if (deptIdList.Count == 0)
                return;

            StringBuilder deptIdSb = new StringBuilder("");
            for( int i=deptIdList.Count-1;i>0;i--)
            {
                deptIdSb.Append("'" + deptIdList[i] + "',");
            }
            deptIdSb.Append("'" + deptIdList[0] +"'");

            StringBuilder posiIdSb = new StringBuilder("");
            for (int i = posiIdList.Count - 1; i > 0; i--)
            {
                posiIdSb.Append("'" + posiIdList[i] +"',");
            }
            posiIdSb.Append("'" + posiIdList[0] +"'");

            #region 部门
            var deptMap = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            DeptPosiHelper.DepartmentList = deptMap.Select(string.Format(@"{0}=@{0} and {1} in (" + deptIdSb.ToString() + ")", Y_Department_Description.IsDelete, Y_Department_Description.DepartId),
                new object[] { 0 }, false, null);
            if (DeptPosiHelper.DepartmentList == null || DeptPosiHelper.DepartmentList.Count == 0)
                return;
            #endregion

            #region 职位
            var posiMap = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
            DeptPosiHelper.PositionList = posiMap.Select(string.Format(@"{0}=@{0} and {1} in (" + posiIdSb.ToString() + ")", Y_Position_Description.IsDelete, Y_Position_Description.PostId),
                new object[] { 0 }, false, null);
            #endregion
        }

        public static IList<Y_Department> GetDepartMent()
        {
            return DeptPosiHelper.DepartmentList;
        }

        public static IList<Y_Position> GetPosition()
        {
            return DeptPosiHelper.PositionList;
        }

        public static IList<Y_Dept_Position> GetDeptPosition()
        {
            return DeptPosiHelper.DeptPositionList;
        }
    }
}




