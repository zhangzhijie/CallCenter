using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ad.Util;
using Ad.DA;
using Ad.Model;
using Ad.Model.DbModel;

namespace Ad.Fw
{
    public class BllGenerateKey
    {
        // 读取ID并更新GenerateKey表
        public static string GetID(KeyTypeEnum Type, int length, string prevalue)
        {
            if (Type == null)
            {
                return null;
            }
            if (length <= 0)
            {
                length = 1;
            }
            if(string.IsNullOrWhiteSpace(prevalue)){
                prevalue = "";
            }
            var map = SingletonHelper<ModelDAL<Y_Generate_Key>>.Instance.Mapping;
            using (var conn = map.CreateConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var ts = conn.BeginTransaction())
                {
                    var selectList = map.Select(string.Format("{0}=@{0}", Y_Generate_Key_Description.KeyType), new object[] { (int)Type }, true, conn, ts, null);
                    if (selectList.Count > 0)
                    {
                        #region 更新
                        string dateStr = selectList[0].CurrentDate.Value.ToString(Const.DateFormatString);
                        if (dateStr == DateTime.Now.ToString(Const.DateFormatString))
                        {
                            selectList[0].KeyNumber = selectList[0].KeyNumber.Value + 1;
                            if (map.Update(selectList[0], conn, ts) < 1)
                            {
                                ts.Rollback();
                                return null;
                            }
                            ts.Commit();
                            string serialNum = StringHelper.AddCharToLenStrA(length, '0', selectList[0].KeyNumber.ToString(), true);
                            return prevalue + DateTime.Now.ToString(Const.YYMMDD) + serialNum;
                        }
                        else
                        {
                            selectList[0].CurrentDate = DateTime.Now;
                            selectList[0].KeyNumber = 1;
                            if (map.Update(selectList[0], conn, ts) < 1)
                            {
                                ts.Rollback();
                                return null;
                            }
                            ts.Commit();
                            string serialNum = StringHelper.AddCharToLenStrA(length, '0', selectList[0].KeyNumber.ToString(), true);
                            return prevalue + DateTime.Now.ToString(Const.YYMMDD) + serialNum;
                        }
                        #endregion
                    }
                    else
                    {
                        #region 插入
                        Y_Generate_Key entity = new Y_Generate_Key();
                        entity.KeyType = (int)Type;
                        entity.KeyNumber = 1;
                        entity.PreValue = prevalue;
                        entity.CurrentDate = DateTime.Now;
                        if (map.Insert(entity, conn, ts) < 1)
                        {
                            ts.Rollback();
                            return null;
                        }
                        ts.Commit();
                        string serialNum = StringHelper.AddCharToLenStrA(length, '0', "1", true);
                        return prevalue + DateTime.Now.ToString(Const.YYMMDD) + serialNum;
                        #endregion
                    }
                    
                }
            }
        }

        // 得到当前GenerateKey中KeyNum
        public static int? GetKeyNumForBatch(KeyTypeEnum Type)
        {
            if (Type == null)
            {
                return null;
            }
            var map = SingletonHelper<ModelDAL<Y_Generate_Key>>.Instance.Mapping;
            var selectList = map.Select(string.Format("{0}=@{0}", Y_Generate_Key_Description.KeyType), new object[] { (int)Type }, true, null);
            if (selectList.Count > 0)
            {
                string dateStr = selectList[0].CurrentDate.Value.ToString(Const.DateFormatString);
                if (dateStr == DateTime.Now.ToString(Const.DateFormatString))
                {
                    return selectList[0].KeyNumber.Value;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        // 根据Type，KeyNum跟新到GenerateKey表
        public static string UpdateGenerateTable(KeyTypeEnum Type, int KeyNum, string preValue)
        {
            var map = SingletonHelper<ModelDAL<Y_Generate_Key>>.Instance.Mapping;
            using(var conn = map.CreateConnection()){
                if(conn.State != ConnectionState.Open){
                    conn.Open();
                }
                using(var ts = conn.BeginTransaction())
                {
                    var selectList = map.Select(string.Format(@"{0}=@{0}", Y_Generate_Key_Description.KeyType), new object[] { (int)Type }, true, null);
                    if (selectList.Count > 0)
                    {
                        #region 更新
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add(Y_Generate_Key_Description.KeyNumber, KeyNum);
                        dic.Add(Y_Generate_Key_Description.CurrentDate, DateTime.Now);
                        if (map.Update(dic, string.Format(@"{0}=@{0}", Y_Generate_Key_Description.KeyType), new object[] { (int)Type }, conn, ts) < 1)
                        {
                            ts.Rollback();
                            return "GenerateKey更新失败";
                        }
                        ts.Commit();
                        return null;
                        #endregion
                    }
                    else
                    {
                        #region 插入
                        if (string.IsNullOrWhiteSpace(preValue))
                        {
                            preValue = "";
                        }
                        Y_Generate_Key entity = new Y_Generate_Key();
                        entity.KeyType = (int)Type;
                        entity.KeyNumber = KeyNum + 1;
                        entity.CurrentDate = DateTime.Now;
                        entity.PreValue = preValue;
                        if (map.Insert(entity, conn, ts) < 1)
                        {
                            ts.Rollback();
                            return "GenerateKey插入失败";
                        }
                        ts.Commit();
                        return null;
                        #endregion
                    }
                }
            }
        }

        public static string GetIDNotCommit(KeyTypeEnum Type, int length, string prevalue,IDbConnection conn,IDbTransaction ts)
        {
            if (Type == null)
            {
                return null;
            }
            if (length <= 0)
            {
                length = 1;
            }
            if (string.IsNullOrWhiteSpace(prevalue))
            {
                prevalue = "";
            }
            var map = SingletonHelper<ModelDAL<Y_Generate_Key>>.Instance.Mapping;
            var selectList = map.Select(string.Format("{0}=@{0}", Y_Generate_Key_Description.KeyType), new object[] { (int)Type }, true, conn, ts, null);
            if (selectList.Count > 0)
            {
                #region 更新
                string dateStr = selectList[0].CurrentDate.Value.ToString(Const.DateFormatString);
                if (dateStr == DateTime.Now.ToString(Const.DateFormatString))
                {
                    selectList[0].KeyNumber = selectList[0].KeyNumber.Value + 1;
                    if (map.Update(selectList[0], conn, ts) < 1)
                    {
                        ts.Rollback();
                        return null;
                    }
                    string serialNum = StringHelper.AddCharToLenStrA(length, '0', selectList[0].KeyNumber.ToString(), true);
                    return prevalue + DateTime.Now.ToString(Const.YYMMDD) + serialNum;
                }
                else
                {
                    selectList[0].CurrentDate = DateTime.Now;
                    selectList[0].KeyNumber = 1;
                    if (map.Update(selectList[0], conn, ts) < 1)
                    {
                        ts.Rollback();
                        return null;
                    }
                    string serialNum = StringHelper.AddCharToLenStrA(length, '0', selectList[0].KeyNumber.ToString(), true);
                    return prevalue + DateTime.Now.ToString(Const.YYMMDD) + serialNum;
                }
                #endregion
            }
            else
            {
                #region 插入
                Y_Generate_Key entity = new Y_Generate_Key();
                entity.KeyType = (int)Type;
                entity.KeyNumber = 1;
                entity.PreValue = prevalue;
                entity.CurrentDate = DateTime.Now;
                if (map.Insert(entity, conn, ts) < 1)
                {
                    ts.Rollback();
                    return null;
                }
                string serialNum = StringHelper.AddCharToLenStrA(length, '0', "1", true);
                return prevalue + DateTime.Now.ToString(Const.YYMMDD) + serialNum;
                #endregion
            }
        }
        
    }
}
