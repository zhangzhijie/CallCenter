using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.VUpload
{
    /// <summary>
    /// 图形变形方式
    /// </summary>
    public enum EnumImageChangeType
    {
        [Description("剪切")]
        Clip = 1,
        [Description("缩放")]
        Scale = 2
    }
}
