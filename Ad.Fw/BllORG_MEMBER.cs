using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ad.Util;
using Ad.DA;
using Ad.Model.DbModel;
using Ad.Model.VModel;

namespace Ad.Fw
{
    public class BllORG_MEMBER
    {
        // to import customer's data for checking enum
        // [录入人员]
        public static IList<ORG_MEMBER> GetCheckStuff()
        {
            var map = SingletonHelper<ModelDAL<ORG_MEMBER>>.Instance.Mapping;
            string where = string.Format(@"{0}!=@{0}1", ORG_MEMBER_Description.ORG_DEPARTMENT_ID);
            return map.Select(where, new object[] { -1L }, true, null);
        }

        public static IList<Y_V_ORG_MEMBER> SearchManagerForAdd(VManagerSel model)
        {
            var selManList = BllManager.SelectManager(new Y_V_Manager(),new string[]{Y_V_Manager_Description.ManagerId});
            bool isHasManager = false;
            if (selManList != null && selManList.Count > 0)
            {
                isHasManager = true;
            }

            var map = SingletonHelper<ModelDAL<Y_V_ORG_MEMBER>>.Instance.Mapping;
            StringBuilder sb = new StringBuilder("1=1");
            List<object> ls = new List<object>();
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                sb.AppendFormat(@" and {0} like @{0}", Y_V_ORG_MEMBER_Description.NAME);
                ls.Add("%" + model.UserName.Trim() + "%");
            }
            if (null != model.DeptId)
            {
                sb.AppendFormat(@" and {0}=@{0}", Y_V_ORG_MEMBER_Description.ORG_DEPARTMENT_ID);
                ls.Add(model.DeptId);
            }
            if (isHasManager)
            {
                StringBuilder managerIdSb = new StringBuilder("");
                for (int i = selManList.Count - 1; i > 0; i--)
                {
                    managerIdSb.Append("'" + selManList[i].ManagerId + "',");
                }
                managerIdSb.Append("'" +selManList[0].ManagerId+ "'");
                sb.AppendFormat(@" and {0} not in (" + managerIdSb.ToString() + ")", Y_V_ORG_MEMBER_Description.ID);
            }

            return map.Select(sb.ToString(), ls.ToArray(), false, null);
        }


        public static Y_V_ORG_MEMBER SelectByManagerId(long managerId)
        {
            var map = SingletonHelper<ModelDAL<Y_V_ORG_MEMBER>>.Instance.Mapping;
            string where = string.Format(@"{0}=@{0}", Y_V_ORG_MEMBER_Description.ID);
            try
            {
                var result = map.Select(where, new object[] { managerId }, true, null);
                if (result == null && result.Count == 0)
                    return null;
                return result.First();
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
