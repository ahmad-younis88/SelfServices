using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Entity
{
    public class EssUser
    {
        public int CompanyID { get; set; }
        public long UserNo { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string TenantID { get; set; }
        public int? EmpID { get; set; }
        public string EmpNameA { get; set; }
        public string EmpNameE { get; set; }
        public int? ProfileID { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public byte[] ImageName { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsManager { get; set; }
        public bool AllowNotification { get; set; }
    }
}
