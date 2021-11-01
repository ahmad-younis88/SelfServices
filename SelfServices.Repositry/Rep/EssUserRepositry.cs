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
using SelfServices.Common.Dto;

namespace SelfServices.Repositry.Rep
{   
    public class EssUserRepositry : IRepositry , IEssUserRepositry
    {
        #region :: Procedure Name 

        private const string _ValidateUser = "VALIDATE_EMP_USER";

        #endregion

        #region :: Parampter Name

        private const string CompanyId = "@CompanyID";
        private const string UserName = "@UserName";
        private const string Password = "@UserPass";

        #endregion

        private readonly IDapper Dapper;
        public EssUserRepositry(IDapper dapper) 
        {
            Dapper = dapper;
        } 

        public async Task<EssUser> GetEssUser(UserInfo userInfo)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, userInfo.CompanyId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(UserName, userInfo.UserName, DbType.String, ParameterDirection.Input);
            dbparams.Add(Password, userInfo.Password, DbType.String, ParameterDirection.Input);
            EssUser essUser = await Dapper.Get<EssUser>(_ValidateUser, dbparams, commandType: CommandType.StoredProcedure);
            return essUser;
        }
    }
}
