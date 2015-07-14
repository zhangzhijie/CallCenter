using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.BModel
{
    [Serializable]
    public class ItemPrices
    {
        public string Key { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal Cost
        {
            get
            {
                return Price * DiscountPercent;
            }
        }

        public decimal Discount
        {
            get
            {
                return Price * (1 - this.DiscountPercent);
            }
        }
    }
}
