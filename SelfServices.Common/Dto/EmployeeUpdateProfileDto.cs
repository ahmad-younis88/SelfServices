using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class EmployeeUpdateProfileDto
    {
        public int CompanyId { get; set; }
        public long UserNo { get; set; }
        public string EmpNameA { get; set; }
        public string EmpNameE { get; set; }
        public bool IsActive { get; set; }
    }
}
