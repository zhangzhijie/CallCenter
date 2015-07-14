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
    public class BllPositionPrivilege
    {
        public static IList<Y_Post_Privilege> Select(Y_Post_Privilege entity)
        {
            var map = SingletonHelper<ModelDAL<Y_Post_Privilege>>.Instance.Mapping;
            StringBuilder sb = new StringBuilder("1=1");
            List<object> ls = new List<object>();
            if (entity.PostId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Post_Privilege_Description.PostId);
                ls.Add(entity.PostId);
            }
            if (entity.FunctionId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Post_Privilege_Description.FunctionId);
                ls.Add(entity.FunctionId);
            }
            if (entity.OperationId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Post_Privilege_Description.OperationId);
                ls.Add(entity.OperationId);
            }
            return map.Select(sb.ToString(), ls.ToArray(), false, null);
        }

        public static ResultU UpdateAll(List<Y_Post_Privilege> postPriList,long postId,int funId)
        {
            var map = SingletonHelper<ModelDAL<Y_Post_Privilege>>.Instance.Mapping;
            var mapPosition = SingletonHelper<ModelDAL<Y_Position>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    string whereSql = string.Format(@"{0}=@{0} and {1}=@{1}", Y_Post_Privilege_Description.PostId,Y_Post_Privilege_Description.FunctionId);
                    object[] values = new object[] { postId,funId };
                    Dictionary<string, object> dir = new Dictionary<string, object>();

                    try
                    {
                        if (mapPosition.SelectCount(string.Format(@"{0}=@{0} and {1}=@{1}", Y_Position_Description.IsDelete, Y_Position_Description.PostId),
                       new object[] { 0, postId }, null, conn, ts) == 0)
                        {
                            return new ResultU { IsOK = false, Msg = "该职位已不存在" };
                        }

                        map.Delete(whereSql, values, conn, ts);


                        if (postPriList != null && postPriList.Count > 0)
                        {
                            foreach (var item in postPriList)
                            {
                                if (map.Insert(item, conn, ts) == 0)
                                {
                                    ts.Rollback();
                                    return new ResultU { IsOK = false, Msg = "更新功能操作错误" };
                                }
                            }
                            dir.Add(Y_Position_Description.IsDistribution, 1);
                            mapPosition.Update(dir, string.Format(@"{0}=@{0} and {1}=@{1}", Y_Position_Description.IsDelete, Y_Position_Description.PostId),
                                new object[] { 0, postId }, conn, ts);
                            ts.Commit();
                            return new ResultU(true);
                        }
                        else
                        {
                            if (map.SelectCount(string.Format(@"{0}=@{0}", Y_Post_Privilege_Description.PostId), new object[] { postId }, null, conn, ts) > 0)
                            {
                                dir.Add(Y_Position_Description.IsDistribution, 1);
                            }
                            else
                            {
                                dir.Add(Y_Position_Description.IsDistribution, 0);
                            }
                            mapPosition.Update(dir, string.Format(@"{0}=@{0} and {1}=@{1}", Y_Position_Description.IsDelete, Y_Position_Description.PostId),
                                new object[] { 0, postId }, conn, ts);
                            ts.Commit();
                            return new ResultU(true);
                        }
                    }
                    catch (Exception e)
                    {
                        ts.Rollback();
                        return new ResultU { IsOK = false, Msg = e.Message };
                    }


                   
                }
            }
        }
    }
}
