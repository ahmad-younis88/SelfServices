using SelfServices.Common.Interface.Services;
using SelfServices.Common.Interface.Repositry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SelfServices.Common.Generic;
using SelfServices.Common.Entity;
using SelfServices.Common.Dto;

namespace SelfServices.Services.Service
{
    public class EssUserService : IServices , IEssUserService
    {
        private IEssUserRepositry EssUserRepositry;
        public EssUserService(IEssUserRepositry essUserRepositry)
        {
            EssUserRepositry = essUserRepositry;
        }

        public async Task<EssUser> GetEssUser(UserInfo userInfo)
        {
            EssUser essUser = await EssUserRepositry.GetEssUser(userInfo);
            return essUser;
        }
    }
}
