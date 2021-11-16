using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SelfServices.Common.Dto;
using SelfServices.Common.Entity;

namespace SelfServices.Common.Interface.Services
{
    public interface IEssUserService
    {
        Task<EssUser> GetEssUser(UserInfo userInfo);
        Task<int> ChangeEssUserPassword(EmployeeChangePasswordDto employeeChangePasswordDto);
        Task<int> UpdateEssUserProfile(EmployeeUpdateProfileDto employeeUpdateProfileDto);
    }
}
