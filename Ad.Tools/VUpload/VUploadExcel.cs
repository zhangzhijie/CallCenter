using Ad.IO;
using Ad.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.VUpload
{
    public class VUploadExcel : VUploadModel
    {
         /// <summary>
        /// Excel上传验证模型
        /// </summary>
        /// <param name="maxSize">最多尺寸</param>
        public VUploadExcel(double maxSize = FileSizeConvert.ONE_GB)
            : base(maxSize, new string[] { ".xlsx", ".xls" }, EnumFileType.Excel)
        {
        }

    }
}
