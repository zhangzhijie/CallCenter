using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Ad.DA;
using Ad.Util;
using Ad.Model.DbModel;

namespace Ad.Fw
{
    public class BllORG_UNIT
    {
        // to import customer's data for checking enum
        // [部门]
        public static IList<ORG_UNIT> GetCheckDept()
        {
            string availableDeptNames = null;
            try
            {
                availableDeptNames = ConfigurationManager.AppSettings["AvailableDeptNames"];
            }catch(Exception){}
            if (string.IsNullOrWhiteSpace(availableDeptNames))
            {
                return null;
            }
            string[] deptNames = availableDeptNames.Split(new char[] { ';', ',', '|' });
            if(deptNames.Length<1)
            {
                return null;
            }
            string whereSql = ORG_UNIT_Description.NAME ;
            if(deptNames.Length>1)
            {
                whereSql += " in (";
                for(int i=0;i<deptNames.Length-1;i++)
                {
                    whereSql+= "'"+deptNames[i]+"',";
                }
                whereSql += "'"+deptNames[deptNames.Length-1]+"')";
            }else
            {
                whereSql += "='"+deptNames[0]+"'";
            }

            var map = SingletonHelper<ModelDAL<ORG_UNIT>>.Instance.Mapping;

            return map.Select(whereSql, null, true, null);
        }
    }
}
