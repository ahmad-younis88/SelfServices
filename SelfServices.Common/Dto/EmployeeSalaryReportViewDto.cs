using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class EmployeeSalaryReportViewDto
    {
            public int CompanyID { get; set; }

            public string EmployeeID { get; set; }

            public string EmployeeNameA { get; set; }

            public string EmployeeNameE { get; set; }

            public int MonthID { get; set; }

            public int YearID { get; set; }

            public int? OrgID { get; set; }

            public string OrgNameA { get; set; }

            public string OrgNameE { get; set; }

            public float BasicSalary { get; set; }

            public float TempAllowance { get; set; }

            public float TempDeduction { get; set; }

            public float FixedAllowance { get; set; }

            public float FixedDeduction { get; set; }

            public float EmployeeSocialDeduction { get; set; }

            public float CompanySocialDeduction { get; set; }

            public float TotalSalary { get; set; }

            public float NetSalary { get; set; }

            public float VacationDeduct { get; set; }

            public float LeaveDeduct { get; set; }

            public float OverTimeValue { get; set; }

            public DateTime? HireDate { get; set; }

            public string JobDescA { get; set; }

            public float EmpBasicSalary { get; set; }

            public string AccountNo { get; set; }

            public string BranchName { get; set; }

            public string BankName { get; set; }

            public string SocialNumber { get; set; }

            public string SocialDept { get; set; }

            public int EmpTypeID { get; set; }

            public float IncomeTax { get; set; }

            public float IncreaseAmount { get; set; }

            public float LoanAmount { get; set; }

            public bool IsEndService { get; set; }

    }
}
