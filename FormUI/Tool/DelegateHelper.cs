using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Tool
{
    public class DelegateHelper
    {
        public delegate void SelfContextItemFun();

        public delegate void OtherContextItemFun(string d);
    }
}
