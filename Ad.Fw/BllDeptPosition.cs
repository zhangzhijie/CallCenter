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
    public class BllDeptPosition
    {
        public static IList<Y_Dept_Position> Select(Y_Dept_Position entity, bool isDistinct=false, string[] selectProperties=null)
        {
            var map = SingletonHelper<ModelDAL<Y_Dept_Position>>.Instance.Mapping;
            string whereSql = "1=1 ";
            List<object> ls = new List<object>();

            if (entity.DepartId!=null)
            {
                whereSql += string.Format(@" and {0}=@{0}", Y_Dept_Position_Description.DepartId);
                ls.Add(entity.DepartId.Value);
            }
            if (entity.PostId != null)
            {
                whereSql += string.Format(@" and {0}=@{0}", Y_Dept_Position_Description.PostId);
                ls.Add(entity.PostId.Value);
            }
            if (entity.PermissionId != null)
            {
                whereSql += string.Format(@" and {0}=@{0}", Y_Dept_Position_Description.PermissionId);
                ls.Add(entity.PermissionId.Value);
            }

            return map.Select(whereSql, ls.ToArray(), isDistinct, selectProperties);
        }


        public static ResultU Update(List<Y_Dept_Position> deptPostList,long deptId)
        {
            var map = SingletonHelper<ModelDAL<Y_Dept_Position>>.Instance.Mapping;
            var managerMap = SingletonHelper<ModelDAL<Y_Manager>>.Instance.Mapping;
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
                        string whereSql = string.Format(@"{0}=@{0}", Y_Dept_Position_Description.DepartId);
                        object[] values = new object[] { deptId };
                        var selectList = map.Select(whereSql, values, false, conn, ts,null);
                        if (selectList != null && selectList.Count>0)
                        {
                            if (deptPostList == null || deptPostList.Count == 0)
                            {
                                if (map.Delete(whereSql, values, conn, ts) <= 0)
                                {
                                    ts.Rollback();
                                    return new ResultU() { IsOK = false, Msg = "删除时发生错误" };
                                }
                                ts.Commit();
                                return new ResultU(true);
                            }
                            
                            List<Y_Dept_Position> delList = new List<Y_Dept_Position>();
                            List<Y_Dept_Position> insList = new List<Y_Dept_Position>();
                            foreach (var item in selectList)
                            {
                                if (!deptPostList.Where(m => m.PostId == item.PostId).Any())
                                {
                                    delList.Add(item);
                                }
                            }

                            foreach (var item in deptPostList)
                            {
                                if (!selectList.Where(m => m.PostId == item.PostId).Any())
                                {
                                    insList.Add(item);
                                }
                            }
                            if (delList.Count > 0)
                            {
                                string delWhereSql = string.Format(@"{0}=@{0} and {1}=@{1}",Y_Dept_Position_Description.DepartId,Y_Dept_Position_Description.PostId);
                                string selManWhereSql = string.Format(@"{0}=@{0}", Y_Manager_Description.PermissionId);
                                foreach (var item in delList)
                                {
                                    if (item.PermissionId != null)
                                    {
                                        // 从员工表查询
                                        if (managerMap.SelectCount(selManWhereSql, new object[] { item.PermissionId }, null, conn, ts) > 0)
                                        {
                                            ts.Rollback();
                                            return new ResultU() { IsOK = false, Msg = "{0} 已分配人员，不允许删除", Data = item.PostId };
                                        }
                                    }
                                    if (map.Delete(delWhereSql, new object[]{item.DepartId,item.PostId}, conn, ts) <= 0)
                                    {
                                        ts.Rollback();
                                        return new ResultU() { IsOK = false, Msg = "删除时发生错误" };
                                    }
                                }
                            }
                            if (insList.Count > 0)
                            {

                                foreach (var item in insList)
                                {
                                    if (map.Insert(item, conn, ts) <= 0)
                                    {
                                        ts.Rollback();
                                        return new ResultU() { IsOK = false, Msg = "插入1时发生错误" };
                                    }
                                }
                            }

                            ts.Commit();
                            return new ResultU(true);
                        }
                        else
                        {
                            if (deptPostList == null || deptPostList.Count == 0)
                            {
                                return new ResultU(true);
                            }
                            else
                            {
                                foreach (var item in deptPostList)
                                {
                                    if (map.Insert(item, conn, ts) <= 0)
                                    {
                                        ts.Rollback();
                                        return new ResultU() { IsOK = false, Msg = "插入2时发生错误" };
                                    }
                                }
                                ts.Commit();
                                return new ResultU(true);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        return new ResultU(){IsOK=false,Msg=e.Message};
                    }
                    
                }
            }
        }
    }
}
