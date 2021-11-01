using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Dto
{
    public class EmployeeViewDto
    {
        public int CompanyID { get; set; }

        public string EmployeeID { get; set; }

        public string EmployeeNameA { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public DateTime? HireDate { get; set; }

        public string ReligionNameA { get; set; }

        public string NationalityNameA { get; set; }

        public string IdentityTypeNameA { get; set; }

        public string IdentityNo { get; set; }

        public string JobDescA { get; set; }

        public string Address { get; set; }

        public string OrgNameA { get; set; }

        public string JobTitleNameA { get; set; }

        public float? NoOfExperince { get; set; }

        public float BasicSalary { get; set; }

        public float SocialSalary { get; set; }

        public DateTime? SocialJoiningDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int? MaterialStatus { get; set; }

        public int? Age { get; set; }

        public bool IsEndService { get; set; }
    }
}
