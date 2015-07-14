using Ad.IO;
using Ad.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.VUpload
{
    public class VUploadAttachment : VUploadModel
    {
         /// <summary>
        /// 附件
        /// </summary>
        /// <param name="maxSize">最多尺寸</param>
        public VUploadAttachment(double maxSize = FileSizeConvert.ONE_MB * 20)
            : base(maxSize, new string[] { ".doc", ".xls", ".docx", ".xlsx", ".zip", ".rar" }, EnumFileType.Attachment)
        {
        }

    }
}
