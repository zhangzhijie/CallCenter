using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.BModel
{
    public class Item
    {
        public long? ItemId { get; set; }

        public decimal? ItemNum { get; set; }

        public String ItemName { get; set; }

        public String UnitName { get; set; }
    }
}
