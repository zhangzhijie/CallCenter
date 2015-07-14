using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Tool
{
    public class SexHelper
    {
        public static IList<Sex> GetSexList()
        {
            List<Sex> sexlist = new List<Sex>();
            sexlist.Add(new Sex { Value = 0, Name = "男" });
            sexlist.Add(new Sex { Value = 1, Name = "女" });
            return sexlist;
        }

    }

    public class Sex
    {
        public int? Value { get; set; }

        public string Name { get; set; }
    }
   
}
