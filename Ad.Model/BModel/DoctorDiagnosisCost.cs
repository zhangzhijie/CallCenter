using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Model.BModel
{
    public class DoctorDiagnosisCost
    {
        public decimal? Cost { get; set; }

        public long? DiagnosisId { get; set; }

        public string DiagnosisName { get; set; } 
    }
}
