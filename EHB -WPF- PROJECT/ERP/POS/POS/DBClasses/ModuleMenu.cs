using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class ModuleMenu
    {
        public int ModuleMenuID { get; set; }

        public string ModuleMenuName { get; set; }

        public string ModuleShortName { get; set; }

        public string ModuleMenuDesc { get; set; }

        public int? ModuleID { get; set; }

        public string recordStatus { get; set; }

        public string recordStatusReason { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntrydBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

    }

}
