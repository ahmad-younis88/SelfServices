using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class EmployeeSalaryFilterDto
    {
        public int CompanyId { get; set; }
        public string EmployeeId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
    }
}
