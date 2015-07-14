using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.BModel
{
    [Serializable]
    public class ItemPay
    {
        public string Key { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Cost{get;set;}

        public decimal Discount{get;set;}
    }
}
