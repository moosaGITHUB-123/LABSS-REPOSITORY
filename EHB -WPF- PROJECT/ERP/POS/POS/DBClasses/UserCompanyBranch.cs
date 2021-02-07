using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class UserCompanyBranch
    {
        public int UserBranchID { get; set; }

        public int UserID { get; set; }

        public int CompanyBranchID { get; set; }

        public DateTime? UserBranchLeftDate { get; set; }

        public string recordStatus { get; set; }

        public string recordStatusReason { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntrydBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

    }

}
