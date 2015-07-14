using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ad.Model
{
    /// <summary>
    /// 抹零方式
    /// </summary>
    public enum ZeroTypeEnum
    {
        /// <summary>
        /// 四舍五入
        /// </summary>
        [Description("四舍五入")]
        Round = 1,

        /// <summary>
        /// 返回大于或等于指定的十进制数的最小整数值
        /// </summary>
        [Description("大于或等于指定的十进制数的最小整数值")]
        Ceiling = 2,

        /// <summary>
        /// 小于或等于指定小数的最大整数
        /// </summary>
        [Description("小于或等于指定小数的最大整数")]
        Floor = 3
    }
}
