using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    /// ------------ Menu Generator Class   ///////

    public class MenuGenerator
    {
       
            public int ModuleID { get; set; }
            public string Parent { get; set; }
            public int ModuleMenuID { get; set; }
            public string Child { get; set; }
            public int ModuleSubMenuID { get; set; }
            public string ModuleSubMenuName { get; set; }
            public string GrandChild { get; set; }

    }

    /// ----------------  Menu Generator Closed -----------------------////////

}
