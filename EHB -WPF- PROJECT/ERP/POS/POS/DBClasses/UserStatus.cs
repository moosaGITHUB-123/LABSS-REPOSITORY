using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class UserStatusClass
    {
        public int UserStatusID { get; set; }

        public string UserStatus { get; set; }

        public string UserStatusDescription { get; set; }

        public DateTime? DataEntryDate { get; set; }

        public int? DateEntryUserID { get; set; }

    }


}
