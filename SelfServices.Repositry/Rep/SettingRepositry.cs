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
    public class SettingRepositry : IRepositry , ISettingRepositry
    {
        #region :: Procedure Name 

        private const string _GetSetting = "GET_SELF_SERVICE_SETTING";

        #endregion

        private const string ParamCompanyId = "@P_COMPANY_ID";

        private readonly IDapper Dapper;
        public SettingRepositry(IDapper dapper) 
        {
            Dapper = dapper;
        }

        public async Task<SelfServiceSetting> GetSetting(int CompanyId)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(ParamCompanyId, CompanyId, DbType.Int32, ParameterDirection.Input);
            SelfServiceSetting selfServiceSetting = await Dapper.Get<SelfServiceSetting>(_GetSetting, dbparams, commandType: CommandType.StoredProcedure);
            return selfServiceSetting;
        }
    }
}
