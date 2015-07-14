using Ad.IO;
using Ad.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.VUpload
{
    /// <summary>
    /// 图片上传验证模型
    /// </summary>
    public class VUploadImg : VUploadModel
    {
        /// <summary>
        /// 图片上传验证模型
        /// </summary>
        /// <param name="maxSize">最多尺寸</param>
        /// <param name="exts">可用扩展名数组</param>
        /// <param name="isChangeImageSize">是否改变图片大小</param>
        /// <param name="imageWidth">图片宽度</param>
        /// <param name="imageHeight">图片高度</param>
        /// <param name="imageChangeType">图片改变方式</param>
        public VUploadImg(double maxSize = FileSizeConvert.ONE_MB, bool isChangeImageSize = false, int imageWidth = 0, int imageHeight = 0, EnumImageChangeType imageChangeType = EnumImageChangeType.Scale)
            : base(maxSize, new string[] { ".png", ".jpg", ".jpeg", ".gif" }, EnumFileType.Image)
        {
            this.IsChangeImageSize = isChangeImageSize;
            this.ImageWidth = imageWidth;
            this.ImageHeight = imageHeight;
            this.ImageChangeType = imageChangeType;
        }

        /// <summary>
        /// 是否改变图片大小
        /// </summary>
        public bool IsChangeImageSize { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        public int ImageWidth { get; set; }

        /// <summary>
        /// 图片高度
        /// </summary>
        public int ImageHeight { get; set; }

        /// <summary>
        /// 图片改变方式
        /// </summary>
        public EnumImageChangeType ImageChangeType { get; set; }
    }
}
