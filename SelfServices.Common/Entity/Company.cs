using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Entity
{
    public class Company
    {
        public int CompanyId { get; set; }
        public int CompanyGroupId { get; set; }
        public string CompanyNameA { get; set; }
        public string CompanyNameE { get; set; }
        public string ContactPerson { get; set; }
        public string AddressNameA { get; set; }
        public string AddressNameE { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Pobox { get; set; }
        public byte[] ComLogo { get; set; }
        public string Note { get; set; }
        public string TaxNo { get; set; }
    }
}
