using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class UserDesignation
    {
        public int UserDesigID { get; set; }

        public int UserID { get; set; }

        public int DesigID { get; set; }

        public string UserDesigProgress { get; set; }

        public DateTime? UserDesigAssignDate { get; set; }

        public string UserDesigAssignDesc { get; set; }

        public string UserDesigJobDesc { get; set; }

        public DateTime? UserDesigDesc { get; set; }

        public string recordStatus { get; set; }

        public string recordStatusReason { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntrydBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

    }

}
