using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.Model.DbModel;
using Ad.Model.VModel;
using Ad.Model;
using Ad.Util;
using Ad.DA;


namespace Ad.Fw
{
    public class BllCallLog
    {
        public static void Insert(Y_Call_Log entity)
        {
            try
            {
                var map = SingletonHelper<ModelDAL<Y_Call_Log>>.Instance.Mapping;
                map.Insert(entity);
            }
            catch (Exception) { }

        }

        public static PageListModel<Y_Call_Log> SelectSplit(VCallLog model,int pageSize = 250, int pageIndex = 1, string orderString = null, IDbConnection conn = null, IDbTransaction ts = null)
        {
            var map = SingletonHelper<ModelDAL<Y_Call_Log>>.Instance.Mapping;
            StringBuilder sb = new StringBuilder("1=1");
            List<object> ls = new List<object>();
            if (!string.IsNullOrWhiteSpace(model.ExtensionNum))
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_Call_Log_Description.SeatPhone);
                ls.Add(model.ExtensionNum);
            }
            if (model.StartTime1 != null)
            {
                sb.AppendFormat(@" and {0}>=@{0}1", Y_Call_Log_Description.StartTime);
                ls.Add(model.StartTime1);
            }
            if (model.StartTime2 != null)
            {
                sb.AppendFormat(@" and {0}<=@{0}2", Y_Call_Log_Description.StartTime);
                ls.Add(model.StartTime2);
            }
            if (!string.IsNullOrWhiteSpace(orderString))
            {
                sb.AppendFormat(@" order by {0}", orderString);
            }
            int recordCount, pageCount;
             IList<Y_Call_Log>  datas = map.SelectSplit(null, sb.ToString(), ls.ToArray(), false, pageIndex, pageSize, out pageCount, out recordCount);
            if (datas == null || datas.Count == 0)
            {
                return new PageListModel<Y_Call_Log>(pageSize);
            }
            else
            {
                return new PageListModel<Y_Call_Log>(datas, pageSize, pageIndex, recordCount, pageCount);
            }

        }
    }
}
