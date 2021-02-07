using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class Department
    {
        public int DeptID { get; set; }

        public string DeptName { get; set; }

        public string DeptShortName { get; set; }

        public string DeptDesc { get; set; }

        public string recordStatus { get; set; }

        public string recordStatusReason { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntrydBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

    }

}
