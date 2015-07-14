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
    public class BllUserInfo
    {
        public static Y_User_Info GetUserInfoByID(long id)
        {
            var map = SingletonHelper<ModelDAL<Y_User_Info>>.Instance.Mapping;
            var userList = map.Select(string.Format(@"{0}=@{0}", Y_User_Info_Description.UserId), new object[] { id }, false, null);
            if (userList != null && userList.Count > 0) 
            {
                return userList[0];
            }
            return null;
        }

        public static int UpdateUserInfoByID(long id, Dictionary<string, object> updateDic)
        {
            if (updateDic == null || updateDic.Count < 1)
            {
                return 0;
            }
            var map = SingletonHelper<ModelDAL<Y_User_Info>>.Instance.Mapping;
            return map.Update(updateDic, string.Format(@"{0}=@{0}", Y_User_Info_Description.UserId), new object[] { id });
        }

        public static int InitUserInfo(long id)
        {
            var map = SingletonHelper<ModelDAL<Y_User_Info>>.Instance.Mapping;
            var userList = map.Select(string.Format(@"{0}=@{0}", Y_User_Info_Description.UserId), new object[] { id }, false, null);
            if (userList == null || userList.Count < 1)
            {
                Y_User_Info entity = new Y_User_Info();
                entity.UserId = id;
                entity.EmailIsLogin = false;
                return map.Insert(entity);
            }
            else
            {
                return 1;
            }
        }

        public static Y_User_Info InitUserInfoByID(long id,string name)
        {
            var map = SingletonHelper<ModelDAL<Y_User_Info>>.Instance.Mapping;
            var userList = map.Select(string.Format(@"{0}=@{0}", Y_User_Info_Description.UserId), new object[] { id }, false, null);
            if (userList == null || userList.Count < 1)
            {
                Y_User_Info entity = new Y_User_Info();
                entity.UserId = id;
                entity.UserName = name;
                entity.EmailIsLogin = false;
                entity.HoldEmailPwd = false;
                if (map.Insert(entity) < 1)
                {
                    return null;
                }
                else
                {
                    return entity;
                }
            }
            else
            {
                return userList[0];
            }
        }
    }
}
