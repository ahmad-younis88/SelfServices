using SelfServices.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Common.Interface.Services
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompany();
    }
}
