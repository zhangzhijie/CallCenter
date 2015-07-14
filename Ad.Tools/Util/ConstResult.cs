using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Util
{
    public static class ConstResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int success = 1;

        /// <summary>
        /// 失败
        /// </summary>
        public const int fail = 0;

        /// <summary>
        /// 权限错误
        /// </summary>
        public const int fail_right = -1;

        /// <summary>
        /// 异常错误
        /// </summary>
        public const int fail_exception = -2;

        /// <summary>
        /// 非法操作错误
        /// </summary>
        public const int fail_illegal = -3;

        /// <summary>
        /// 登录过期
        /// </summary>
        public const int fail_expire = -4;

        /// <summary>
        /// 参数错误
        /// </summary>
        public const int fail_params = -5;

        /// <summary>
        /// 不存在
        /// </summary>
        public const int fail_notexist = -6;

        /// <summary>
        /// 已存在
        /// </summary>
        public const int fail_exist = -7;

        /// <summary>
        /// 尺寸过大
        /// </summary>
        public const int fail_sizebig = -8;

        /// <summary>
        /// 尺寸过小
        /// </summary>
        public const int fail_sizesmall = -9;

        /// <summary>
        /// 格式问题
        /// </summary>
        public const int fail_format = -10;

        /// <summary>
        /// 移动文件
        /// </summary>
        public const int fail_movefile = -11;

        /// <summary>
        /// 保持文件
        /// </summary>
        public const int fail_savefile = -12;

        /// <summary>
        /// 删除文件
        /// </summary>
        public const int fail_deletefile = -13;
    }
}
