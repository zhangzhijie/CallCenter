using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.Util;
using Ad.DA;
using Ad.Model.DbModel;

namespace Ad.Fw
{
    public class BllOperation
    {
        public static IList<Y_Operation> Select()
        {
            var map = SingletonHelper<ModelDAL<Y_Operation>>.Instance.Mapping;
            return map.Select("1=1", null, false, null);
        }
        public static ResultU Insert(List<Y_Operation> operList,bool IsSpecial)
        {
            var map = SingletonHelper<ModelDAL<Y_Operation>>.Instance.Mapping;
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
                        int selectCount = map.SelectCount("1=1", null, null, conn, ts);
                        if (selectCount > 0)
                        {
                            if (IsSpecial)
                            {
                                map.Delete("1=1", null);
                            }
                            else
                            {
                                return new ResultU { IsOK = false, Msg = "已经存在操作，不允许插入" };
                            }
                        }
                        foreach (Y_Operation entity in operList)
                        {
                            if (map.Insert(entity, conn, ts) < 1)
                            {
                                ts.Rollback();
                                return new ResultU { IsOK = false, Msg = "插入失败(影响行数为0)" };
                            }
                        }
                        ts.Commit();
                        return new ResultU(true);
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
