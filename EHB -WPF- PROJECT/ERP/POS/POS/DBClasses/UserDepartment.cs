using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class UserDepartment
    {
        public int UserDeptID { get; set; }

        public int UserID { get; set; }

        public int DeptID { get; set; }

        public DateTime? UserDeptJoinDate { get; set; }

        public DateTime? UserDeptLeftDate { get; set; }

        public string UserDeptDesc { get; set; }

        public string recordStatus { get; set; }

        public string recordStatusReason { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntrydBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

    }

}
