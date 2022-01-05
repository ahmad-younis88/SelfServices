using SelfServices.Common.Interface.Services;
using SelfServices.Common.Interface.Repositry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SelfServices.Common.Generic;
using SelfServices.Common.Entity;

namespace SelfServices.Services.Service
{
    public class SettingService : IServices , ISettingService
    {
        private ISettingRepositry SettingRepositry;
        public SettingService(ISettingRepositry settingRepositry)
        {
            SettingRepositry = settingRepositry;
        }

        public async Task<SelfServiceSetting> GetSetting(int CompanyId)
        {
            SelfServiceSetting setting = await SettingRepositry.GetSetting(CompanyId);
            return setting;
        }
    }
}
