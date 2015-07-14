using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.DbModel
{
    public partial class Y_Position
    {
        public string DistributionStr
        {
            get
            {
                return this.IsDistribution.Value ? "Y" : "N";
            }
        }

        public bool? IsChoice { get; set; }

        public Int64? PermissionId { get; set; }
    }
}
