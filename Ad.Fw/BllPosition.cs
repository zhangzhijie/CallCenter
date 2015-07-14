using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.DA;
using Ad.Util;
using Ad.Model.DbModel;

namespace Ad.Fw
{
    public class BllPosition
    {
        public static IList<Y_Position> Select(Y_Position entity)
        {
            var map = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
            string whereSql = string.Format(@"{0}=@{0}", Y_Position_Description.IsDelete);
            List<object> ls = new List<object>();
            ls.Add(0);

            if (!string.IsNullOrWhiteSpace(entity.PostName))
            {
                whereSql += string.Format(@" and {0} like @{0}", Y_Position_Description.PostName);
                ls.Add("%" + entity.PostName.Trim() + "%");
            }
            if (entity.IsDistribution != null)
            {
                whereSql += string.Format(@" and {0} = @{0}", Y_Position_Description.IsDistribution);
                ls.Add(entity.IsDistribution.Value);
            }

            return map.Select(whereSql, ls.ToArray(), false, null);
        }

        public static ResultU Insert(Y_Position entity)
        {
            var map = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using(var ts = conn.BeginTransaction())
                {
                    string whereSql = string.Format(@"{0}=@{0} and {1}=@{1}", Y_Position_Description.IsDelete, Y_Position_Description.PostName);
                    object[] values = new object[] { 0, entity.PostName };
                    if (map.SelectCount(whereSql, values, null, conn, ts)>0)
                    {
                        return new ResultU { IsOK = false, Msg = "存在相同职位" };
                    }
                    if (map.Insert(entity, conn, ts) < 1)
                    {
                        return new ResultU { IsOK = false, Msg = "插入失败(影响行数0)" };
                    }
                    ts.Commit();
                    return new ResultU(true);
                }
            }
        }

        public static ResultU Update(Y_Position entity)
        {
            var map = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    string whereSql = string.Format(@"{0}=@{0} and {1}=@{1} and {2}!=@{2}",
                        Y_Position_Description.IsDelete,Y_Position_Description.PostName,Y_Position_Description.PostId);
                    object[] values = new object[] { 0, entity.PostName,entity.PostId };
                    if (map.SelectCount(whereSql, values, null, conn, ts) > 0)
                    {
                        return new ResultU { IsOK = false, Msg = "存在相同职位" };
                    }
                    if (map.Update(entity, conn, ts) < 1)
                    {
                        return new ResultU { IsOK = false, Msg = "更新失败(影响行数0)" };
                    }
                    ts.Commit();
                    return new ResultU(true);
                }
            }
        }

        public static Y_Position SelectById(long postId)
        {
            var map = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
            string whereSql = string.Format(@"{0}=@{0} and {1}=@{1}", Y_Position_Description.IsDelete, Y_Position_Description.PostId);
            object[] values = new object[] { 0, postId };
            var resultList = map.Select(whereSql,values, false, null);
            if (null != resultList && resultList.Count > 0)
            {
                return resultList.First();
            }
            return null;
        }

        public static ResultU DeleteById(string postId)
        {
            var map = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
            var mapPrivilege = SingletonHelper<ModelDAL<Y_Post_Privilege>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    if (mapPrivilege.SelectCount(string.Format(@"{0}=@{0}", Y_Post_Privilege_Description.PostId), new object[] { postId }, null, conn, ts) > 0)
                    {
                        return new ResultU { IsOK = false, Msg = "该职位已经赋权，若要删除请先清除权限设置" };
                    }
                    else
                    {
                        string whereSql = string.Format(@"{0}=@{0} and {1}=@{1}", Y_Position_Description.IsDelete, Y_Position_Description.PostId);
                        object[] values = new object[] { 0, postId };
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add(Y_Position_Description.IsDelete, 1);
                        map.Update(dic, whereSql, values,conn,ts);
                        ts.Commit();
                        return new ResultU(true);
                    }
                }
            }

        }

        #region 目前没用到
        // 根据部门赋权判断那些部门可用
        public static IList<Y_Position> SelectEnablePosition()
        {
            var deptPosiList = BllDeptPosition.Select(new Y_Dept_Position(), true, new string[] { Y_Dept_Position_Description.PostId });
            if (deptPosiList != null && deptPosiList.Count > 0)
            {
                StringBuilder posiIdSb = new StringBuilder("");
                if (deptPosiList.Count == 1)
                {
                    posiIdSb.Append("'" + deptPosiList.First().PostId.ToString() + "'");
                }
                else
                {

                    for (int i = 0; i < deptPosiList.Count - 1; i++)
                    {
                        posiIdSb.Append("'" + deptPosiList[i].PostId.ToString() + "'" + ",");
                    }
                    posiIdSb.Append("'" + deptPosiList.Last().PostId.ToString() + "'");
                }
                var map = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
                return map.Select(string.Format(@"{0}=@{0} and {1} in (" + posiIdSb.ToString() + ")", Y_Position_Description.IsDelete, Y_Position_Description.PostId),
                new object[] { 0 }, false, null);
            }
            return null;
        }
        #endregion

    }
}
