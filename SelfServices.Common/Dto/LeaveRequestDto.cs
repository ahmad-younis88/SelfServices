using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class LeaveRequestDto
    {
        public int CompanyID { get; set; }
        public string EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string Note { get; set; }
        public string FilePath { get; set; }
	}
}
