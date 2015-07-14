using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.Model.DbModel;
using Ad.Model.VModel;
using Ad.DA;
using Ad.Util;

namespace Ad.Fw
{
    public class BllManager
    {
        public static PageListModel<Y_V_Manager> SplitManager(Y_V_Manager model, string[] selectProperties, int pageSize = 250, int pageIndex = 1, string orderString = null, IDbConnection conn = null, IDbTransaction ts = null)
        {
            var map = SingletonHelper<ModelDAL<Y_V_Manager>>.Instance.Mapping;
            List<object> ls = new List<object>();
            StringBuilder sb = new StringBuilder("1=1");

            if (!string.IsNullOrWhiteSpace(model.NAME))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_V_Manager_Description.NAME);
                ls.Add("%" + model.NAME.Trim() +"%");
            }
            if (model.DepartId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_V_Manager_Description.DepartId);
                ls.Add(model.DepartId);
            }
            if (model.PostId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_V_Manager_Description.PostId);
                ls.Add(model.PostId);
            }

            if (!string.IsNullOrEmpty(orderString))
            {
                sb.AppendFormat(@" order by {0}", orderString);
            }

            int recordCount, pageCount;
            IList<Y_V_Manager> datas = null;
            if (conn == null)
            {
                datas = map.SelectSplit(selectProperties, sb.ToString(), ls.ToArray(), false, pageIndex, pageSize, out pageCount, out recordCount);
            }
            else
            {
                datas = map.SelectSplit(selectProperties, sb.ToString(), ls.ToArray(), false, pageIndex, pageSize, out pageCount, out recordCount, conn, ts);
            }
            if (datas == null || datas.Count == 0)
            {
                return new PageListModel<Y_V_Manager>(pageSize);
            }
            return new PageListModel<Y_V_Manager>(datas, pageSize, pageIndex, recordCount, pageCount);
        }

        public static IList<Y_V_Manager> SelectManager(Y_V_Manager model, string[] selectProperties=null, string orderString = null)
        {
            var map = SingletonHelper<ModelDAL<Y_V_Manager>>.Instance.Mapping;
            List<object> ls = new List<object>();
            StringBuilder sb = new StringBuilder("1=1");

            if (!string.IsNullOrWhiteSpace(model.NAME))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_V_Manager_Description.NAME);
                ls.Add("%" + model.NAME.Trim() + "%");
            }
            if (model.DepartId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_V_Manager_Description.DepartId);
                ls.Add(model.DepartId);
            }
            if (model.PostId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_V_Manager_Description.PostId);
                ls.Add(model.PostId);
            }

            if (!string.IsNullOrEmpty(orderString))
            {
                sb.AppendFormat(@" order by {0}", orderString);
            }

            return map.Select(sb.ToString(), ls.ToArray(), false, selectProperties);

        }

        public static ResultU Insert(Y_Manager entity)
        {
            var map = SingletonHelper<ModelDAL<Y_Manager>>.Instance.Mapping;
            try
            {
                if (map.SelectCount(string.Format(@"{0}=@{0}", Y_Manager_Description.LoginName), new object[] { entity.LoginName }, null) > 0)
                {
                    return new ResultU { IsOK = false, Msg = "登陆名已被人注册" };
                }
                if (map.Insert(entity) > 0)
                {
                    return new ResultU(true);
                }
                return new ResultU() { IsOK = false, Msg = "插入错误" };
            }
            catch (Exception e)
            {
                return new ResultU() { IsOK = false, Msg = e.Message };
            }
        }

        public static ResultU Update(Y_Manager entity)
        {
            var map = SingletonHelper<ModelDAL<Y_Manager>>.Instance.Mapping;
            try
            {
                if (map.SelectCount(string.Format(@"{0}=@{0}", Y_Manager_Description.ManagerId), new object[] { entity.ManagerId }, null) == 0)
                {
                    return new ResultU { IsOK = false, Msg = "该记录已经不存在" };
                }
                if (map.SelectCount(string.Format(@"{0}!=@{0} and {1}=@{1}", Y_Manager_Description.ManagerId,Y_Manager_Description.LoginName), 
                    new object[] { entity.ManagerId,entity.LoginName }, null) > 0)
                {
                    return new ResultU { IsOK = false, Msg = "登陆名已被人注册" };
                }
                if (map.Update(entity) > 0)
                {
                    return new ResultU(true);
                }
                return new ResultU() { IsOK = false, Msg = "更新错误" };
            }
            catch (Exception e)
            {
                return new ResultU() { IsOK = false, Msg = e.Message };
            }
        }

        public static ResultU DeleteById(long id)
        {
            var map = SingletonHelper<ModelDAL<Y_Manager>>.Instance.Mapping;
            try
            {
                string whereSql = string.Format(@"{0}=@{0}", Y_Manager_Description.ManagerId);
                object[] values = new object[] { id };
                if (map.SelectCount(whereSql,values, null) == 0)
                {
                    return new ResultU { IsOK = false, Msg = "该记录已经不存在" };
                }
                if (map.Delete(whereSql,values) > 0)
                {
                    return new ResultU(true);
                }
                return new ResultU() { IsOK = false, Msg = "删除错误" };
            }
            catch (Exception e)
            {
                return new ResultU() { IsOK = false, Msg = e.Message };
            }
        }

        public static Y_V_Manager Login(string loginName, string pwd)
        {
            var map = SingletonHelper<ModelDAL<Y_V_Manager>>.Instance.Mapping;
            try
            {
                string whereSql = string.Format(@"{0}=@{0} and {1}=@{1}", Y_V_Manager_Description.LoginName, Y_V_Manager_Description.Pwd);
                object[] values = new object[] { loginName,pwd };
                var result = map.Select(whereSql, values, false, null);
                if (result == null || result.Count == 0)
                {
                    return null;
                }

                return result.First();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static ResultU ChangePwd(VManagerPwd model)
        {
            var map = SingletonHelper<ModelDAL<Y_Manager>>.Instance.Mapping;
            string whereSql = string.Format(@"{0}=@{0} and {1}=@{1}", Y_Manager_Description.ManagerId, Y_Manager_Description.Pwd);
            object[] values = new object[]{model.ManagerId,model.OriPwd};
            try
            {
                if (map.SelectCount(whereSql, values, null) == 0)
                {
                    return new ResultU { IsOK = false, Msg = "原始密码错误" };
                }
                Dictionary<string, object> upDir = new Dictionary<string, object>();
                upDir.Add(Y_Manager_Description.Pwd, model.NewPwd);
                if (map.Update(upDir,whereSql,values) > 0)
                {
                    return new ResultU(true);
                }
                return new ResultU { IsOK = false, Msg = "修改密码错误" };
            }
            catch (Exception e)
            {
                return new ResultU { IsOK = false, Msg = e.Message };
            }
            
        }
    }
}
