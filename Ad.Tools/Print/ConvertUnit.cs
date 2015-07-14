using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Print
{
    public static class ConvertUnit
    {
        public static int GetInchPercent(double cm)
        {
            return (int)(cm / 25.4 * 100);
        }
    }
}
