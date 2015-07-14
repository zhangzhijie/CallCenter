using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Util
{
    public static class Const
    {
        public const string DateTimeFormatString = "yyyy-MM-dd HH:mm:ss";
        public const string DateFormatString = "yyyy-MM-dd";
        public const string TimeFormatString = "HH:mm:ss";
        public const string YYMMDD = "yyMMdd";
        /// <summary>
        /// 输出0.00格式
        /// </summary>
        public const string PriceFormatString = "f2"; //0.00

        public const string PriceRmbFormatString = "C2"; // ￥1,234.00

        public const string KnowledgeBaseDir = "KnowLedgeBase";

        // 部门根节点编号
        public const string DeptRootCode = "0000";

        public const string DeptRootName = "部门";

        // 最大部门分层4 (根节点不算)
        public const int DeptMaxLevel = 5;

        // 默认密码(采用m5加密)
        public const string InitPwd = "123456";

        // 密码加密Key
        //public const string PwdEncryptKey = "lm180808";


        public const string GodUserName = "zhangzhijie";

        public const string GodUserPwd = "abc123";

        // TelephoneControl 名称前缀
        public const string TelControlPrefix = "Tlc";

        // cmsSelf各项 名称前缀
        public const string SelfContextMenuPrefix = "CmsSelf";

        // cmsOther各项 名称前缀
        public const string OtherContextMenuPrefix = "CmsOther";
    }
}
