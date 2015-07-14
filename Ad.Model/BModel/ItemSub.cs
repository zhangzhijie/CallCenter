using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.BModel
{
    public class ItemSub
    {
        public string Name { get; set; }
        public string Unit { get; set; }

        public ItemSub(string name, string unit)
        {
            this.Name = name;
            this.Unit = unit;
        }
    }
}
