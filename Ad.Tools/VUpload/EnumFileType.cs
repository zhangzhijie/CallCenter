using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.VUpload
{
    /// <summary>
    /// 文件类型
    /// </summary>
    public enum EnumFileType
    {
        /// <summary>
        /// 图片
        /// </summary>
        Image = 1,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 2,

        /// <summary>
        /// Excel
        /// </summary>
        Excel = 3,
        Word = 4,
        /// <summary>
        /// 附件
        /// </summary>
        Attachment = 99
    }
}
