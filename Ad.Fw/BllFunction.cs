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
    public class BllFunction
    {
        public static IList<Y_Function> Select()
        {
            var map = SingletonHelper<ModelDAL<Y_Function>>.Instance.Mapping;
            return map.Select("1=1", null, false, null);
        }

        public static ResultU Insert(List<Y_Function> funList,bool IsSpecial)
        {
            var map = SingletonHelper<ModelDAL<Y_Function>>.Instance.Mapping;
            if (map.SelectCount("1=1", null, null) > 0)
            {
                if (IsSpecial)
                {
                    map.Delete("1=1", null);
                }else
                {
                    return new ResultU { IsOK = false, Msg = "已存在不允许插入" };
                }   
            }
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
                        foreach (Y_Function entity in funList)
                        {
                            if (map.Insert(entity, conn, ts) < 1)
                            {
                                ts.Rollback();
                                return new ResultU { IsOK = false, Msg = "插入错误" };
                            }
                        }
                        ts.Commit();
                        return new ResultU { IsOK = true };
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
