using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SelfServices.Common.Entity;

namespace SelfServices.Common.Interface.Repositry
{
    public interface ICompanyRepositry
    {
        Task<List<Company>> GetCompany();
    }
}
