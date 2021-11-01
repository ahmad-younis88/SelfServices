using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfServices.Services.Service;
using SelfServices.Common.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using SelfServices.Common.Entity;

namespace SelfServices.API.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService CompanyService;
        public CompanyController(ICompanyService companyService)
        {
            CompanyService = companyService;
        }

        [HttpGet]
        [Route("all-company")]
        public async Task<List<Company>> GetCompanies()
        {
            List<Company> companies = await CompanyService.GetCompany();
            return companies.ToList();
        }
    }
}
