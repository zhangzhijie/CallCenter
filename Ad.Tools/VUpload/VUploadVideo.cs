using Ad.IO;
using Ad.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.VUpload
{
    public class VUploadVideo : VUploadModel
    {
         /// <summary>
        /// 图片上传验证模型
        /// </summary>
        /// <param name="maxSize">最多尺寸</param>
        public VUploadVideo(double maxSize = FileSizeConvert.ONE_GB)
            : base(maxSize, new string[] { ".flv", ".mp4" }, EnumFileType.Video)
        {
        }

    }
}
