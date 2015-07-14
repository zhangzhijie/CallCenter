using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.DbModel
{
    public partial class Y_Department
    {
        private bool? hasChild;

        public bool? HasChild { 
            get
            {
                return hasChild.GetValueOrDefault();
            }
            set
            {
                if (value != null)
                {
                    hasChild = value;
                }
                else
                {
                    hasChild = false;
                }
                
            }
        }
    }
}
