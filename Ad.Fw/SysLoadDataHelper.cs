using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ad.Model;
using Ad.Model.DbModel;

namespace Ad.Fw
{
    public static class SysLoadDataHelper
    {
        // 导入客户资料时 【部门】
        private static IList<ORG_UNIT> importCustDeptList;

        public static IList<ORG_UNIT> ImportCustDeptList { get { return importCustDeptList; } }

        // 导入客户资料时 【录入人员】
        private static IList<ORG_MEMBER> importCustomerList;

        public static IList<ORG_MEMBER> ImportCustomerList { get { return importCustomerList; } }

        // 枚举类型 【所在区域，地区，客户来源】
        private static IList<CTP_ENUM_ITEM> importEnumList;

        public static IList<CTP_ENUM_ITEM> ImportEnumList { get { return importEnumList; } }

        // 【客户来源】
        public static IList<CTP_ENUM_ITEM> CustomerSourcList
        {
            get
            {
                var result = importEnumList.Where(m => m.REF_ENUMID == StaticConst.CustomerSourceEnumId);
                if (result.Any())
                {
                    return result.ToList();
                }
                return null;
            }
        }

        //【区域】
        public static IList<CTP_ENUM_ITEM> AreaList
        {
            get
            {
                var result = importEnumList.Where(m => m.REF_ENUMID == StaticConst.PositionEnumId && m.PARENT_ID == 0);
                if (result.Any())
                {
                    return result.ToList();
                }
                return null;
            }
        }

        //【地区】
        public static IList<CTP_ENUM_ITEM> GetProviceList(string parentIdString)
        {
            var result = importEnumList.Where(m => m.REF_ENUMID == StaticConst.PositionEnumId && m.PARENT_ID.ToString() == parentIdString);
            if (result.Any())
            {
                return result.ToList();
            }
            return null;
        }

        static SysLoadDataHelper()
        {
            importCustDeptList = BllORG_UNIT.GetCheckDept();

            importCustomerList = BllORG_MEMBER.GetCheckStuff();

            importEnumList = BllCTP_ENUM_ITEM.GetCheckEnum(StaticConst.CustomerSourceEnumId, StaticConst.PositionEnumId);
        }
    }
}
