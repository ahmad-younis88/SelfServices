using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SelfServices.Common.Dto;
using SelfServices.Common.Entity;

namespace SelfServices.Common.Interface.Repositry
{
    public interface ISettingRepositry
    {
        Task<SelfServiceSetting> GetSetting(int CompanyId);
    }
}
