using Microsoft.Extensions.Configuration;
using SelfServices.Common.Interface;
using SelfServices.Common.Interface.Repositry;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SelfServices.Common.Entity;
using SelfServices.Common.Generic;
using Dapper;
using System.Data;

namespace SelfServices.Repositry.Rep
{   
    public class CompanyRepositry : IRepositry , ICompanyRepositry
    {
        #region :: Procedure Name 

        private const string _GetAllCompany = "SP_GetCompany";

        #endregion

        private readonly IDapper Dapper;
        public CompanyRepositry(IDapper dapper) 
        {
            Dapper = dapper;
        }

        public async Task<List<Company>> GetCompany()
        {
            var dbparams = new DynamicParameters();
            List<Company> lstOfCompany = await Dapper.GetAll<Company>(_GetAllCompany, dbparams, commandType: CommandType.StoredProcedure);
            return lstOfCompany;
        }
    }
}
