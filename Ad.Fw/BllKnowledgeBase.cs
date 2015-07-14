using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Ad.Model.DbModel;
using Ad.Model.VModel;
using Ad.DA;
using Ad.Util;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XWPF.UserModel;

namespace Ad.Fw
{
    public class BllKnowledgeBase
    {
        // 插入
        public static ResultU Insert(VM_KnowledgeBase model)
        {
            try
            {
                var map = SingletonHelper<ModelDAL<Y_KnowledgeBase>>.Instance.Mapping;

                if (map.SelectCount(string.Format(@"{0}=@{0}", Y_KnowledgeBase_Description.Title), new object[] { model.Title }) > 0)
                {
                    return new ResultU { IsOK = false, Msg = "标题重复" };
                }
                Y_KnowledgeBase entity = new Y_KnowledgeBase();
                entity.Title = model.Title;
                entity.KeyWords = model.KeyWords;
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = entity.CreateDate;
                entity.Suffix = model.FilePath.Substring(model.FilePath.LastIndexOf('.') + 1);

                string zipFilePath = FileUpLoad.GetZipFileFullPath();
                if (!FileUpLoad.ZipFile(model.FilePath, zipFilePath, null))
                {
                    return new ResultU { Msg = "压缩时错误", IsOK = false };
                }
                byte[] fileByte = FileUpLoad.GetBinaryArray(zipFilePath);

                entity.Content = fileByte;

                if (map.Insert(entity) > 0)
                {
                    return new ResultU { IsOK = true };
                }
                return new ResultU { IsOK = false, Msg = "未插入" };
            }
            catch (Exception e)
            {
                return new ResultU { Msg = e.Message, IsOK = false };
            }
        }

        // 查询
        public static IList<Y_KnowledgeBase> Select(string[] selectProperties, string whereSql, object[] values, bool isDistinct=false,IDbConnection conn=null, IDbTransaction trans=null)
        {
            var map = SingletonHelper<ModelDAL<Y_KnowledgeBase>>.Instance.Mapping;
            if(conn!=null && trans!=null)
            {
                return map.Select(whereSql,values,isDistinct,conn,trans);
            }else
            {
                return map.Select(whereSql, values, isDistinct, selectProperties);
            }
        }

        // 分页查询
        public static PageListModel<Y_KnowledgeBase> SelectSplit(VM_KnowledgeBase model,string[] selectProperties, int pageSize = 250, int pageIndex = 1, string orderString = null, IDbConnection conn = null, IDbTransaction ts = null)
        {
            var map = SingletonHelper<ModelDAL<Y_KnowledgeBase>>.Instance.Mapping;
            List<object> ls = new List<object>();
            StringBuilder sb = new StringBuilder("1=1");

            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                sb.AppendFormat(@" and {0} like @{0}1 ", Y_KnowledgeBase_Description.Title);
                ls.Add("%" + model.Title.Trim() + "%");
            }
            if (!string.IsNullOrWhiteSpace(model.KeyWords))
            {
                sb.AppendFormat(@" and {0} like @{0}1 ", Y_KnowledgeBase_Description.KeyWords);
                ls.Add("%" + model.KeyWords.Trim() + "%");
            }
            if (!string.IsNullOrEmpty(orderString))
            {
                sb.AppendFormat(@" order by {0} ", orderString);
            }
            int recordCount, pageCount;
            IList<Y_KnowledgeBase> datas = null;
            if (conn == null)
            {
                datas = map.SelectSplit(selectProperties, sb.ToString(), ls.ToArray(), false, pageIndex, pageSize, out pageCount, out recordCount);
            }
            else
            {
                datas = map.SelectSplit(selectProperties, sb.ToString(), ls.ToArray(), false, pageIndex, pageSize, out pageCount, out recordCount, conn, ts);
            }
            if (datas == null || datas.Count == 0)
            {
                return new PageListModel<Y_KnowledgeBase>(pageSize);
            }
            return new PageListModel<Y_KnowledgeBase>(datas, pageSize, pageIndex, recordCount, pageCount);
        }

        // 更新
        public static ResultU Update(VM_KnowledgeBase model)
        {
            try
            {
                var map = SingletonHelper<ModelDAL<Y_KnowledgeBase>>.Instance.Mapping;
                if (map.SelectCount(string.Format(@"{0}=@{0} and {1}!=@{1}", Y_KnowledgeBase_Description.Title,Y_KnowledgeBase_Description.KnowledgeCode), 
                    new object[] { model.Title,model.KnowledgeCode }) > 0)
                {
                    return new ResultU { IsOK = false, Msg = "标题重复" };
                }

                Dictionary<string,object> setDir = new Dictionary<string,object>();
                setDir.Add(Y_KnowledgeBase_Description.Title,model.Title);
                setDir.Add(Y_KnowledgeBase_Description.KeyWords,model.KeyWords);

                if (!string.IsNullOrWhiteSpace(model.FilePath))
                {
                    string zipFilePath = FileUpLoad.GetZipFileFullPath();
                    if (!FileUpLoad.ZipFile(model.FilePath, zipFilePath, null))
                    {
                        return new ResultU { Msg = "压缩时错误", IsOK = false };
                    }
                    byte[] fileByte = FileUpLoad.GetBinaryArray(zipFilePath);
                    setDir.Add(Y_KnowledgeBase_Description.Content,fileByte);
                }

                setDir.Add(Y_KnowledgeBase_Description.UpdateDate,DateTime.Now);

                ;
                if (map.Update(setDir, string.Format(@"{0}=@{0}", Y_KnowledgeBase_Description.KnowledgeCode), new object[] { model.KnowledgeCode }) > 0)
                {
                    return new ResultU { IsOK = true };
                }
                return new ResultU { IsOK = false, Msg = "未更新" };
            }
            catch (Exception e)
            {
                return new ResultU { Msg = e.Message, IsOK = false };
            }
        }

        // 删除
        public static ResultU Delete(string code)
        {
            try
            {
                var map = SingletonHelper<ModelDAL<Y_KnowledgeBase>>.Instance.Mapping;

                if (map.DeleteById(code)>0)
                {
                    return new ResultU { IsOK = true };
                }
                return new ResultU { IsOK = false, Msg = "未删除" };
            }
            catch (Exception e)
            {
                return new ResultU { IsOK = false, Msg = e.Message };
            }
        }
    }
}
