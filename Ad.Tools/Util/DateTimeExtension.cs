using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Util
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 添加星期
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="value">添加的星期数</param>
        /// <returns></returns>
        public static DateTime AddWeek(this DateTime dateTime, double value)
        {
            return dateTime.AddDays(value * 7);
        }

        public static string GetAgoString(this DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            if (dateTime.AddMonths(1) < now)
            {
                return dateTime.ToString("YY年");
            }
            if (dateTime.AddDays(1) < now)
            {
                return (now - dateTime).Days + "天前";
            }
            if (dateTime.AddHours(1) < now)
            {
                return (now - dateTime).Hours + "时前";
            }
            else
            {
                return (now - dateTime).Minutes + "分前";
            }
        }
    }
}
