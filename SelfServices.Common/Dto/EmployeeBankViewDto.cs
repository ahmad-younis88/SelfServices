using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class EmployeeBankViewDto
    {
        public int CompanyID { get; set; }

        public string EmployeeID { get; set; }

        public string EmployeeNameA { get; set; }

        public int? BankID { get; set; }

        public string BankName { get; set; }

        public int? BranchID { get; set; }

        public string BranchName { get; set; }

        public string AccountNo { get; set; }

        public float? TransferRate { get; set; }

        public int MonthID { get; set; }

        public int YearID { get; set; }

        public float TotalSalary { get; set; }

        public float NetSalary { get; set; }

        public string IdentityNo { get; set; }

        public int EmpTypeID { get; set; }
    }
}
