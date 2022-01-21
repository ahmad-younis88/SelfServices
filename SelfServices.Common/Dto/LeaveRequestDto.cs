using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class LeaveRequestDto
    {
        public string CompanyID { get; set; }
        public string EmployeeID { get; set; }
        public string LeaveTypeID { get; set; }
        public string RequestDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Note { get; set; }
        public string FilePath { get; set; }
	}
}
