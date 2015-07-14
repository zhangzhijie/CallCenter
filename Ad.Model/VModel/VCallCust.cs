using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.VModel
{
    public class VCallCust
    {
        public Int64? DeptId { get;set;}

        public String StuffName { get;set;}

        public DateTime? EntryDate1 { get;set;}
        public DateTime? EntryDate2 { get; set; }

        public String CustName { get;set;}

        public Int64? AreaId { get;set;}

        public Int64? ProvinceId { get;set;}

        public int? Sex { get;set;}

        public Int64? CustSourceId { get;set;}

        public String Phone { get;set;}

        public String Email { get;set;}

        public String Job { get;set;}

        public String Product { get;set;}

        public String Question { get;set;} 
    }
}

