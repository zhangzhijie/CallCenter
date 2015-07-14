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
    public class BllCustomer
    {
        public static PageListModel<Y_Call_Cust> SplitCurrentDayStorage(VCallCust options, string[] selectProperties, int pageSize = 250, int pageIndex = 1, string orderString = null, IDbConnection conn = null, IDbTransaction ts = null)
        {
            var map = SingletonHelper<ModelDAL<Y_Call_Cust>>.Instance.Mapping;
            List<object> ls = new List<object>();
            StringBuilder sb = new StringBuilder("1=1");
            if (options.AreaId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Call_Cust_Description.AreaId);
                ls.Add(options.AreaId);
            }
            if (!string.IsNullOrWhiteSpace(options.CustName))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_Call_Cust_Description.CustName);
                ls.Add("%"+options.CustName+"%");
            }
            if (options.CustSourceId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Call_Cust_Description.CustSourceId);
                ls.Add(options.CustSourceId);
            }
            if (options.DeptId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Call_Cust_Description.DeptId);
                ls.Add(options.DeptId);
            }
            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_Call_Cust_Description.Email);
                ls.Add("%"+options.Email+"%");
            }
            if (options.EntryDate1 != null)
            {
                sb.AppendFormat(@" and {0}>= @{0}1", Y_Call_Cust_Description.EntryDate);
                ls.Add(options.EntryDate1);
            }
            if (options.EntryDate2 != null)
            {
                sb.AppendFormat(@" and {0}<= @{0}2", Y_Call_Cust_Description.EntryDate);
                ls.Add(options.EntryDate2);
            }
            if (!string.IsNullOrWhiteSpace(options.Job))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_Call_Cust_Description.Job);
                ls.Add("%"+options.Job+"%");
            }
            if (!string.IsNullOrWhiteSpace(options.Phone))
            {
                sb.AppendFormat(@" and ({0} like @{0} or {1} like @{0})",Y_Call_Cust_Description.Phone,Y_Call_Cust_Description.Tel);
                ls.Add("%"+options.Phone.Trim()+"%");
            }
            if(!string.IsNullOrWhiteSpace(options.Product))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_Call_Cust_Description.Product);
                ls.Add("%" + options.Product + "%");
            }
            if (options.ProvinceId != null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Call_Cust_Description.ProvinceId);
                ls.Add(options.ProvinceId);
            }
            if (!string.IsNullOrWhiteSpace(options.Question))
            {
                sb.AppendFormat(@" and {0} like @{0}" , Y_Call_Cust_Description.Question);
                ls.Add("%"+options.Question.Trim()+"%");
            }
            if(options.Sex !=null)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Call_Cust_Description.Sex);
                ls.Add(options.Sex);
            }
            if (!string.IsNullOrWhiteSpace(options.StuffName))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_Call_Cust_Description.StuffName);
                ls.Add("%" + options.StuffName + "%");
            }
            

            if (!string.IsNullOrEmpty(orderString))
            {
                sb.AppendFormat(@" order by {0}", orderString);
            }

            int recordCount, pageCount;
            IList<Y_Call_Cust> datas = null;
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
                return new PageListModel<Y_Call_Cust>(pageSize);
            }
            foreach (var entity in datas)
            {
                entity.SexStr = entity.Sex.Value ? "女" : "男";
            }
            return new PageListModel<Y_Call_Cust>(datas, pageSize, pageIndex, recordCount, pageCount);
        }

        public static Y_Call_Cust BombScreenSelect(string phone)
        {
            var map = SingletonHelper<ModelDAL<Y_Call_Cust>>.Instance.Mapping;
            List<object> ls = new List<object>();
            StringBuilder sb = new StringBuilder("1=1");

            sb.AppendFormat(@" and ({0}=@{0} or {1}=@{1}) order by {2} desc",
                Y_Call_Cust_Description.Tel,Y_Call_Cust_Description.Phone, Y_Call_Cust_Description.EntryDate);
            ls.Add(phone);
            ls.Add(phone);

            //var result = map.SelectTop(null, sb.ToString(), ls.ToArray(), false, top);
            var result = map.Select(sb.ToString(), ls.ToArray(), false, null);
            if (result != null && result.Count > 0)
            {
                return result.First();
            }
            return null;
        }

    }
}
