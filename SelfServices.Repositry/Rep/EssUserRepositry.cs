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
        private const string _ChangePassword = "CHANGE_EMP_USER_PASSWORD";
        private const string _UpdateUserProfile = "UPDATE_USER_PROFILE";


        #endregion

        #region :: Parampter Name

        private const string CompanyId = "@CompanyID";
        private const string UserNo = "@UserNo";
        private const string UserName = "@UserName";
        private const string Password = "@UserPass";
        private const string EmpNameA = "@EmpNameA";
        private const string EmpNameE = "@EmpNameE";
        private const string IsActive = "@IsActive";

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

        public async Task<int> ChangeEssUserPassword(EmployeeChangePasswordDto employeeChangePasswordDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeChangePasswordDto.CompanyId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(UserNo, employeeChangePasswordDto.UserNo, DbType.Int64, ParameterDirection.Input);
            dbparams.Add(Password, employeeChangePasswordDto.Password, DbType.String, ParameterDirection.Input);
            int nResult = await Dapper.Update(_ChangePassword, dbparams, commandType: CommandType.StoredProcedure);
            return nResult;
        }

        public async Task<int> UpdateEssUserProfile(EmployeeUpdateProfileDto employeeUpdateProfileDto)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(CompanyId, employeeUpdateProfileDto.CompanyId, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(UserNo, employeeUpdateProfileDto.UserNo, DbType.Int64, ParameterDirection.Input);
            dbparams.Add(EmpNameA, employeeUpdateProfileDto.EmpNameA, DbType.String, ParameterDirection.Input);
            dbparams.Add(EmpNameE, employeeUpdateProfileDto.EmpNameE, DbType.String, ParameterDirection.Input);
            dbparams.Add(IsActive, employeeUpdateProfileDto.IsActive, DbType.Boolean, ParameterDirection.Input);
            int nResult = await Dapper.Update(_UpdateUserProfile, dbparams, commandType: CommandType.StoredProcedure);
            return nResult;
        }
    }
}
