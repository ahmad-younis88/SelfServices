using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class EmployeeRequestDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int RequestNumber { get; set; }
        public int RequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public string Note { get; set; }
        public int TypeID { get; set; }
        public string TypeNameA { get; set; }
        public string TypeNameE { get; set; }
        public int IsVacationType { get; set; }
    }
}
