using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.Model;
using Ad.Model.DbModel;
using Ad.Util;
using Ad.DA;

namespace Ad.Fw
{
    public class BllCallCust
    {
        // 系统录入
        public static ResultU Insert(Y_Call_Cust entity)
        {
            var map = SingletonHelper<ModelDAL<Y_Call_Cust>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if(conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    try
                    {
                        string custId = BllGenerateKey.GetIDNotCommit(KeyTypeEnum.CustKey_Sys, 5, PreValueType.CustPre_Sys, conn, ts);
                        entity.CustCode = custId;
                        if (map.Insert(entity, conn, ts) > 0)
                        {
                            ts.Commit();
                            return new ResultU(true);
                        }
                        return new ResultU { IsOK = false, Msg = "插入错误" };
                    }
                    catch (Exception e)
                    {
                        return new ResultU { IsOK = false, Msg = e.Message };
                    }
                }
            }
        }
    }
}
