using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Entity
{
    public class SelfServiceSetting
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public string AboutApp { get; set; }
        public string PrivacyPolicyApp { get; set; }
        public string HelpSupportApp { get; set; }
    }
}
