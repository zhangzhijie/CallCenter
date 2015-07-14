using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ad.Model.DbModel;


namespace Ad.Model
{
    public class StaticConst
    {
        // 错误提示
        public static string ImportErrorMsg = "EOF";

        public static Y_User_Info UserInfo { get; set; }

        // 加密key
        public const string EncryKey = "zhangzhijie";

        // 附件最大值
        public const long MaxAllAttachmentSize = 2 * 1024 * 1024 * 1024L;

        // 区域，地区EnumId
        public const long PositionEnumId = 880373495094592175L;

        // 客户来源 EnumId
        public const long CustomerSourceEnumId = 9055787467040575010L;
    }
}
