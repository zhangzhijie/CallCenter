using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Tool
{
    public class UserChannel
    {
        public string cardType { get; set; }
        public short dstID { get; set; }
        public string dstPhone { get; set; }
        public short dstStatu { get; set; }
        public string dstUserName { get; set; }
        public short dstUserType { get; set; }
        public short iD { get; set; }
        public short mixdata { get; set; }
        public short moduleStatus { get; set; }
        public string morningCallTime { get; set; }
        public short signal { get; set; }
        public short simStatus { get; set; }
        public short srvCls { get; set; }
        public short userType { get; set; }

        public string pUserName { get; set; }
        public long? pUserId { get; set; }
    }
}
