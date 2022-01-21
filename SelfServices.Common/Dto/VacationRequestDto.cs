using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class VacationRequestDto
    {
        public string CompanyID { get; set; }
        public string EmployeeID { get; set; }
        public string VacationTypeID { get; set; }
        public string RequestDate { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Note { get; set; }
        public string FilePath { get; set; }
    }
}
