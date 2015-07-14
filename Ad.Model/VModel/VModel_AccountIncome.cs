using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.VModel
{
    public class VModel_AccountIncome
    {
        public DateTime? PayTime_Begin { get; set; }

        public DateTime? PayTime_End { get; set; }

        public String PatientName { get; set; }

        public String DoctorName { get; set; }
    }
}
