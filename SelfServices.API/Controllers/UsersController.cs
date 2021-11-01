using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SelfServices.API.Generic;
using SelfServices.Common.Dto;
using SelfServices.Common.Entity;
using SelfServices.Common.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServices.API.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private TokenServices TokenServices;
        private IEssUserService EssUserService;

        public UsersController(TokenServices tokenServices, IEssUserService essUserService)
        {
            TokenServices = tokenServices;
            EssUserService = essUserService;
        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] UserInfo userInfo)
        {
            try
            {
                #region :: Validate Employee Of User Is Exist Or Not

                EssUser essUser = await EssUserService.GetEssUser(userInfo);
                if (essUser == null)
                {
                    return Ok(new { isSuccess = false, Message = "User Name Or Password Not Exists Please Try Again" });
                }

                #endregion

                string jwtToken = TokenServices.GenerateToken(userInfo);
                return Ok(new { isSuccess = true, Message = "", token = jwtToken });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
