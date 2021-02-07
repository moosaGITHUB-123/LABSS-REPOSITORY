using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class UserType
    {
        public int UserTypeID { get; set; }

        public string UserTypeName { get; set; }

        public bool? UserTypeStatus { get; set; }

        public string UserTypeDescription { get; set; }

        public DateTime? DataEntryDate { get; set; }

        public int? DataEntryUserID { get; set; }

    }

}
