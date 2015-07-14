using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ad.Model.DbModel;
using Ad.Util;
using Ad.DA;

namespace Ad.Fw
{
    public class BllCTP_ENUM_ITEM
    {

        // to import customer's data for checking enum
        // [客户来源，所在区域，地区]
        public static IList<CTP_ENUM_ITEM> GetCheckEnum(long custSourceEnumId,long positionEnumId)
        {
            var map = SingletonHelper<ModelDAL<CTP_ENUM_ITEM>>.Instance.Mapping;
            //string whereSql = CTP_ENUM_ITEM_Description.REF_ENUMID + "=" + custSourceEnumId + " or " + CTP_ENUM_ITEM_Description.REF_ENUMID + "=" + positionEnumId;
            string where = string.Format(@"{0}=@{0}1 or {0}=@{0}2", CTP_ENUM_ITEM_Description.REF_ENUMID);
            return map.Select(where, new object[] { custSourceEnumId, positionEnumId }, false, null);
            //return map.Select(whereSql, null, true, null);
        }
    }
}
