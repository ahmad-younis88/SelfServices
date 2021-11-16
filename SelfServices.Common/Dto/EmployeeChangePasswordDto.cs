using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class EmployeeChangePasswordDto
    {
        public int CompanyId { get; set; }
        public long UserNo { get; set; }
        public string Password { get; set; }
    }
}
