using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DBClasses
{
    public class CompanyBranch
    {
        public int CompanyBranchID { get; set; }

        public string BranchName { get; set; }

        public string BranchShortName { get; set; }

        public string BranchAddress { get; set; }

        public string BranchRegistrationDetail { get; set; }

        public string BranchContactNo { get; set; }

        public string BranchEmail { get; set; }

        public string BranchStatus { get; set; }

        public string BranchDesc { get; set; }

        public string CompanyName { get; set; }

        public string CompanyShortName { get; set; }

        public string CompanyWorkNature { get; set; }

        public string CompanyNTN { get; set; }

        public string CompanyTaxRegNo { get; set; }

        public string CompanyImage1 { get; set; }

        public string CompanyImage2 { get; set; }

        public string CompanyWeb { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyDesc { get; set; }

        public string recordStatus { get; set; }

        public string recordStatusReason { get; set; }

        public int? recordLastModifiedBy { get; set; }

        public DateTime? recordLastModifiedDate { get; set; }

        public int? recordEntrydBy { get; set; }

        public DateTime? recordEntryDate { get; set; }

    }

}
