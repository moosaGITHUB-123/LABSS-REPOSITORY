using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class SoftwareMenu
    {
        public int SoftwareMenuId { get; set; }

        public string Name { get; set; }

        public string SoftwareMenuType { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }

        public string UserInfo { get; set; }

        public int? SoftwareMenuParentId { get; set; }

    }

}
