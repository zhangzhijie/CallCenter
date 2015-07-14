using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.VUpload
{
    /// <summary>
    /// 上传验证模型
    /// </summary>
    public class VUploadModel
    {
        /// <summary>
        /// 最多尺寸
        /// </summary>
        public double MaxSize { get; set; }

        /// <summary>
        /// 可用扩展名数组
        /// </summary>
        public string[] Exts { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public EnumFileType FileType { get; set; }

        


       
       /// <summary>
       /// 上传验证模型
       /// </summary>
       /// <param name="maxSize">最多尺寸</param>
       /// <param name="exts">可用扩展名数组</param>
       /// <param name="fileType">文件类型</param>
        public VUploadModel(double maxSize, string[] exts, EnumFileType fileType)
        {
            this.MaxSize = maxSize;
            this.Exts = exts;
            this.FileType = fileType;
        }

        

        public string GetExtsArrString()
        {
            StringBuilder sb = new StringBuilder();
            if (Exts == null)
            {
                return "";
            }
            for (var i = 0; i < Exts.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append("'" + Exts[i] + "'");
            }
            return sb.ToString();
        }
    }
}
