using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ad.Model;
using Ad.Model.DbModel;
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
    }
}
