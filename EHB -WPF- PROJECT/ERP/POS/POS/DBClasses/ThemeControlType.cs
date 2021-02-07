using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class ThemeControlType
    {
        public int ThemeControlTypeID { get; set; }

        public string ThemeControlTypeName { get; set; }

        public string ThemeControlTypeCode { get; set; }

        public DateTime? EntryDate { get; set; }

        public bool? status { get; set; }

    }

}
