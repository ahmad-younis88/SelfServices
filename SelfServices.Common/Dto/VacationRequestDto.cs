using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class VacationRequestDto
    {
        public int CompanyID { get; set; }
        public string EmployeeID { get; set; }
        public int VacationTypeID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Note { get; set; }
        public string FilePath { get; set; }
    }
}
