using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class ModuleSubMenuClass
    {
        public int ModuleSubMenuID { get; set; }

        public string ModuleSubMenuName { get; set; }

        public string ModuleSubMenuShortName { get; set; }

        public string ModuleSubMenu { get; set; }

        public int? ModuleMenuID { get; set; }

        public string recordStatus { get; set; }

        public string recordStatusReason { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntrydBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

    }

}
