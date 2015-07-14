using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Ad.Model.DbModel;
using Ad.Fw;

namespace FormUI.Tool
{
    public class AnswerHelper
    {
        // 测试线路
        public static short CurrentChannelId = 0;

        public static string CurrentSeatPhone = "601";

        // 不断刷新其他线路信息
        public static System.Threading.Thread RefreshTelStateThread;

        // 当前选择的ToolStripMenuItem
        public static  FormUI.Plug.TelephoneControl SelectedTelControl = null;

        private static IList<UserChannel> AllEnableChannels;

        public static List<UserChannel> AllChannelEntityList = new List<UserChannel>();

        public static IList<UserChannel> GetAllEnableChannels()
        {
            if (AllEnableChannels != null && AllEnableChannels.Count > 0)
                return AllEnableChannels;

            var ls = BllManager.SelectManager(new Y_V_Manager(), null, null);
            List<UserChannel> managerChannelsList = new List<UserChannel>();
            if (ls == null || ls.Count == 0)
                return managerChannelsList;

            foreach (var item in ls)
            {
                try
                {
                    string channelStr = item.Channel;
                    string[] channelArr = channelStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < channelArr.Length; i++)
                    {
                        if (!managerChannelsList.Where(m => m.Equals(channelArr[i])).Any())
                        {
                            var ucEnumList = AllChannelEntityList.Where(m => m.dstPhone.Equals(channelArr[i]));
                            if (ucEnumList.Any())
                            {
                                var uc = ucEnumList.First();
                                uc.pUserId = item.ManagerId;
                                uc.pUserName = item.NAME;
                                managerChannelsList.Add(uc);
                            }
                            
                        }
                    }
                }
                catch (Exception) { }
            }
            AllEnableChannels = managerChannelsList;
            return managerChannelsList;
        }

        // 计时器
        public static Stopwatch CallTimer = new Stopwatch();

        // 通话号码
        public static string PhoneNum;

        // 通话开始时间
        public static DateTime StartTime;

    }
}
