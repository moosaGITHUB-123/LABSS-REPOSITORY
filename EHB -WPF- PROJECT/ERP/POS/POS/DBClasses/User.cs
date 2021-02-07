using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class User
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? UserTypeID { get; set; }

        public int? UserIsAllowMultipliLogin { get; set; }

        public int? UserStatusID { get; set; }

        public DateTime? DataEntryDate { get; set; }

        public int? DataEntryStatus { get; set; }

        public int? DataEntryUser { get; set; }

        public int? LoginStatusID { get; set; }

        public string UserLoginMacAddress { get; set; }

        public string UserLoginPCName { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string UserImagePath { get; set; }

    }

}
