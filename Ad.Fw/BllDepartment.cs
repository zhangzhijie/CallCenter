using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.Model.DbModel;
using Ad.Util;
using Ad.DA;

namespace Ad.Fw
{
    public class BllDepartment
    {
        private static int CodeLength = Const.DeptRootCode.Length;

        public static ResultU InitDeptSelectThreeLevel()
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    try
                    {
                        var selCount = map.SelectCount(string.Format(@"{0}=@{0}", Y_Department_Description.IsDelete), new object[] { 0 }, null, conn, ts);
                        if (selCount == 0)
                        {
                            Y_Department deptEntity = new Y_Department();
                            deptEntity.Code = Const.DeptRootCode;
                            deptEntity.DepartName = Const.DeptRootName;
                            deptEntity.IsDelete = false;
                            if (map.Insert(deptEntity, conn, ts) <= 0)
                            {
                                ts.Rollback();
                                return new ResultU { IsOK = false, Msg = "插入根节点时错误" };
                            }
                        }
                        var selList = map.Select(string.Format(@"{0}=@{0} and LEN({1}) <= @{1}", Y_Department_Description.IsDelete, Y_Department_Description.Code),
                            new object[] { 0, CodeLength * 3 }, false, conn, ts, null);
                        if (selList == null || selList.Count == 0)
                        {
                            return new ResultU { IsOK = false, Msg = "初始化错误，取得条目为空" };
                        }
                        ts.Commit();
                        return new ResultU { IsOK = true, Data = selList };
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = e.Message };
                    }

                }
            }
        }
        public static IList<Y_Department> SelectByParentCodeTwoLevel(string parentCode)
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            string childCode = parentCode + (new string('_', CodeLength));
            return map.Select(string.Format(@"{0}=@{0} and LEN({1}) <= @{1}1 and {1} like @{1}2", Y_Department_Description.IsDelete, Y_Department_Description.Code),
                new object[] { 0, parentCode.Length+CodeLength*2,parentCode+"_%"}, false, null);
        }

        public static Y_Department SelectByDeptID(string deptId)
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            var result = map.Select(string.Format(@"{0}=@{0} and {1}=@{1}", Y_Department_Description.IsDelete, Y_Department_Description.DepartId),
                new object[] { 0, deptId }, false, null);
            if (result != null && result.Count > 0)
            {
                return result.First();
            }
            return null;
        }
        public static ResultU Insert(string parentCode, string deptName)
        {
            if(parentCode.Length>=CodeLength*(Const.DeptMaxLevel-1))
            {
                return new ResultU { IsOK = false, Msg = "目前只支持 " + Const.DeptMaxLevel + " 层结构" };
            }
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            var deptPosiMap = SingletonHelper<ModelDAL<Y_Dept_Position>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    try
                    {
                        string likeCode = parentCode + (new string('_', CodeLength));
                        if(map.SelectCount(string.Format(@"{0}=@{0} and {1}=@{1}",Y_Department_Description.DepartName,
                            Y_Department_Description.IsDelete), new object[] { deptName, 0 }, null, conn, ts) > 0)
                        {
                            return new ResultU { IsOK = false, Msg = "部门名称重复" };
                        }
                        var selectResult = map.Select(string.Format(@"{0} like @{0} order by {1} desc",Y_Department_Description.Code, 
                            Y_Department_Description.DepartId),new object[] {likeCode }, false, null);
                        string codeStr;
                        int code;
                        if (selectResult != null && selectResult.Count > 0)
                        {
                            string firstCode = selectResult.First().Code;
                            codeStr = firstCode.Substring(firstCode.Length - CodeLength);
                        }
                        else
                        {
                            codeStr = new string('0', CodeLength);
                        }
                        if (!Int32.TryParse(codeStr, out code))
                        {
                            return new ResultU { IsOK = false, Msg = "编码错误" };
                        }
                        code += 1;
                        codeStr = code.ToString("0000");
                        if (codeStr.Length>CodeLength)
                        {
                            return new ResultU { IsOK = false, Msg = "编码超过范围" };
                        }
                        string childCode = parentCode + codeStr;
                        if(map.SelectCount(string.Format(@"{0}=@{0}",Y_Department_Description.Code),new object[]{childCode},null,conn,ts)>0)
                        {
                            return new ResultU { IsOK = false, Msg = "部门编码已经存在，不允许插入" };
                        }
                        Y_Department department = new Y_Department();
                        department.Code = childCode;
                        department.DepartName = deptName;
                        department.IsDelete = false;

                        var resultObj = map.InsertReturnIdentity(department, conn, ts);
                        if (resultObj != null)
                        {
                            if (deptPosiMap.SelectCount(string.Format(@"{0}=@{0}", Y_Dept_Position_Description.DepartId),new object[] { resultObj }, null, conn, ts) > 0)
                            {
                                ts.Rollback();
                                return new ResultU { IsOK = false, Msg = "该部门已存在职位不允许再创建子部门" };
                            }
                            ts.Commit();
                            return new ResultU(true);
                        }
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = "插入错误" };
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = e.Message };
                    }
                }
            }
        }

        public static ResultU Update(string childCode, string deptName)
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open) 
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    try
                    {
                        string parentCode = childCode.Substring(0, childCode.Length - CodeLength);
                        //string likeCode = parentCode + (new string('_',CodeLength));
                        if(map.SelectCount(string.Format(@"{0}=@{0} and {1}!=@{1} and {2}=@{2}", Y_Department_Description.IsDelete,
                             Y_Department_Description.Code,Y_Department_Description.DepartName),new object[] { 0,childCode,deptName }, null,conn,ts)>0)
                        {
                            return new ResultU { IsOK = false, Msg = "部门名称有重复" };
                        }
                        Dictionary<string, object> updateDir = new Dictionary<string, object>();
                        updateDir.Add(Y_Department_Description.DepartName, deptName);
                        if (map.Update(updateDir, string.Format(@"{0}=@{0}", Y_Department_Description.Code), new object[] { childCode }, conn, ts) > 0)
                        {
                            ts.Commit();
                            return new ResultU(true);
                        }
                        return new ResultU { IsOK = false, Msg = "更新失败" };

                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = e.Message };
                    }
                }
            }
        }

        public static ResultU Delete(string deptId)
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            var deptPosiMap = SingletonHelper<ModelDAL<Y_Dept_Position>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    try
                    {
                        var selList = map.Select(string.Format(@"{0}=@{0} and {1}=@{1}", Y_Department_Description.IsDelete, Y_Department_Description.DepartId),
                            new object[] { 0, deptId }, false, conn, ts, null);
                        if (selList == null || selList.Count == 0)
                        {
                            return new ResultU { IsOK = false, Msg = "该记录已不存在，请刷新" };
                        }
                        string code = selList.First().Code;
                        if (map.SelectCount(string.Format(@"{0}=@{0} and {1} like @{1}", Y_Department_Description.IsDelete, Y_Department_Description.Code),
                                 new object[] { 0, code + "_%" }, null, conn, ts) > 0)
                        {
                            return new ResultU { IsOK = false, Msg = "存在子部门，不允许删除" };
                        }
                        if (deptPosiMap.SelectCount(string.Format(@"{0}=@{0}", Y_Dept_Position_Description.DepartId), new object[] { deptId }, null, conn, ts) > 0)
                        {
                            return new ResultU { IsOK = false, Msg = "部门已分配职位，不允许删除" };
                        }
                        Dictionary<string, object> delDir = new Dictionary<string, object>();
                        delDir.Add(Y_Department_Description.IsDelete, 1);
                        if (map.Update(delDir, string.Format(@"{0}=@{0}", Y_Department_Description.Code), new object[] { code }, conn, ts) > 0)
                        {
                            ts.Commit();
                            return new ResultU(true);
                        }
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = "删除失败" };
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = e.Message };
                    }
                }
            }
            
        }

        #region 目前没用到
        public static ResultU InitDeptSelectAll()
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    try
                    {
                        var selCount = map.SelectCount(string.Format(@"{0}=@{0}", Y_Department_Description.IsDelete), new object[] { 0 }, null, conn, ts);
                        if (selCount == 0)
                        {
                            Y_Department deptEntity = new Y_Department();
                            deptEntity.Code = Const.DeptRootCode;
                            deptEntity.DepartName = Const.DeptRootName;
                            deptEntity.IsDelete = false;
                            if (map.Insert(deptEntity, conn, ts) <= 0)
                            {
                                ts.Rollback();
                                return new ResultU { IsOK = false, Msg = "插入根节点时错误" };
                            }
                        }
                        var selList = map.Select(string.Format(@"{0}=@{0}", Y_Department_Description.IsDelete), new object[] { 0 }, false, conn, ts, null);
                        if (selList == null || selList.Count == 0)
                        {
                            return new ResultU { IsOK = false, Msg = "初始化错误，取得条目为空" };
                        }
                        return new ResultU { IsOK = true, Data = selList };
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = e.Message };
                    }

                }
            }
        }
        public static IList<Y_Department> SelectByParentCodeOneLevel(string parentCode)
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            string childCode = parentCode + (new string('_', CodeLength));
            return map.Select(string.Format(@"{0}=@{0} and {1} like @{1}", Y_Department_Description.IsDelete, Y_Department_Description.Code),
                new object[] { 0, childCode }, false, null);
        }
        // 递归查找节点下所有子节点
        public static IList<Y_Department> SelectByParentCode(string parentCode)
        {
            var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
            return map.Select(string.Format(@"{0}=@{0} and {1} like @{1}", Y_Department_Description.IsDelete, Y_Department_Description.Code),
                new object[] { 0, parentCode + "_%" }, false, null);
        }

        // 根据部门赋权判断那些部门可用
        public static IList<Y_Department> SelectEnableDept()
        {
            var deptPosiList = BllDeptPosition.Select(new Y_Dept_Position(), true, new string[] { Y_Dept_Position_Description.DepartId });
            if (deptPosiList != null && deptPosiList.Count > 0)
            {
                StringBuilder departIdSb = new StringBuilder("");
                if (deptPosiList.Count == 1)
                {
                    departIdSb.Append("'" + deptPosiList.First().DepartId.ToString() + "'");
                }
                else
                {

                    for (int i = 0; i < deptPosiList.Count - 1; i++)
                    {
                        departIdSb.Append("'" + deptPosiList[i].DepartId.ToString() + "'" + ",");
                    }
                    departIdSb.Append("'" + deptPosiList.Last().DepartId.ToString() + "'");
                }
                var map = SingletonHelper<ModelDAL<Y_Department>>.Instance.Mapping;
                return map.Select(string.Format(@"{0}=@{0} and {1} in (" + departIdSb.ToString() + ")", Y_Department_Description.IsDelete, Y_Department_Description.DepartId),
                new object[] { 0 }, false, null);
            }
            return null;
        }
        #endregion

    }
}
