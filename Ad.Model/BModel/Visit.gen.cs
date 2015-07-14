using System;
using Ad.DA;

namespace Ad.Model.BModel
{


    public partial class Visit
    {
        public int? VisitType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? DateNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? DateDoctorNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? VisitId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? DoctorId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? PatientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DoctorKey { get; set; }

    }
}
