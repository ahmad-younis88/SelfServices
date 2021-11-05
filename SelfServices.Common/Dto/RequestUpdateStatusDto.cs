using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class RequestUpdateStatusDto
    {
        public int RequestNo { get; set; }
        public int CompanyID { get; set; }
        public int EmployeeID { get; set; }
        public int RequestStatus { get; set; }
    }
}
