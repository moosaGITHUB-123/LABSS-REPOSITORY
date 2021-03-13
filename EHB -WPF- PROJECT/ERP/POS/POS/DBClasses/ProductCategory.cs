using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class ProductCategory
    {
        public int CategoryID { get; set; }

        public string CategoryParentID { get; set; }

        public string CategoryFullName { get; set; }

        public string CategoryShortName { get; set; }

        public string CategoryDescription { get; set; }

        public int? recordStatusID { get; set; }

        public string recordStatusCause { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntryBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

        public string recordStatusName { get; set; }

    }

}
