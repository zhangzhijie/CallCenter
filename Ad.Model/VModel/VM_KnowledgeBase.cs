using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ad.Model.VModel
{
    public class VM_KnowledgeBase
    {
        public Int64? KnowledgeCode { get; set; }

        public DateTime? CreateDate { get; set; }

        public String Title { get; set; }

        public String KeyWords { get; set; }

        public String Content { get; set; }

        public DateTime? UpdateDate { get; set; }

        public String FilePath { get; set; }

        public String Suffix { get; set; }
    }
}
