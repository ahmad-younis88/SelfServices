using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Entity
{
    public class Employee
    {
        public int CompanyID { get; set; }

        public string EmployeeID { get; set; }

        public int? IdentityType { get; set; }

        public string IdentityNo { get; set; }

        public string FirstNameA { get; set; }

        public string SecondNameA { get; set; }

        public string ThirdNameA { get; set; }

        public string FamilyNameA { get; set; }

        public string FirstNameE { get; set; }

        public string SecondNameE { get; set; }

        public string ThirdNameE { get; set; }

        public string FamilyNameE { get; set; }

        public string EmployeeNameA { get; set; }

        public string EmployeeNameE { get; set; }

        public string MotherName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public int? RelgionID { get; set; }

        public DateTime? HireDate { get; set; }

        public int? NationalityID { get; set; }

        public string Address { get; set; }

        public int OrgID { get; set; }

        public int? JobTitleID { get; set; }

        public int? JobID { get; set; }

        public float? NoOfExperince { get; set; }

        public string JobDesc { get; set; }

        public float BasicSalary { get; set; }

        public float SocialSalary { get; set; }

        public int? SocialPolicyID { get; set; }

        public DateTime? SocialJoiningDate { get; set; }

        public int? SexID { get; set; }

        public int? MaterialStatus { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public byte[] EmpImage { get; set; }

        public bool IsEndService { get; set; }

        public int? CurrID { get; set; }

        public bool IsSelfService { get; set; }

        public int? DirectManagerID { get; set; }

        public string SocialNumber { get; set; }

        public string SocialDept { get; set; }

        public int EmpTypeID { get; set; }
    }
}
