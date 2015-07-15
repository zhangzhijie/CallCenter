using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.VModel
{
    public class VCallLog
    {
        // 分机号码
        public string ExtensionNum { get; set; }

        public DateTime? StartTime1 { get; set; }

        public DateTime? StartTime2 { get; set; }
    }
}
