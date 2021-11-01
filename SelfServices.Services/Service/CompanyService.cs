using SelfServices.Common.Interface.Services;
using SelfServices.Common.Interface.Repositry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SelfServices.Common.Generic;
using SelfServices.Common.Entity;

namespace SelfServices.Services.Service
{
    public class CompanyService : IServices , ICompanyService
    {
        private ICompanyRepositry CompanyRepositry;
        public CompanyService(ICompanyRepositry companyRepositry)
        {
            CompanyRepositry = companyRepositry;
        }

        public async Task<List<Company>> GetCompany()
        {
            List<Company> companies = await CompanyRepositry.GetCompany();
            return companies;
        }

    }
}
