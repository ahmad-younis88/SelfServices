using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SelfServices.API.Generic;
using SelfServices.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServices.API.Controllers
{
    public class UsersController : Controller
    {
        private IConfiguration Configuration;
        private TokenServices TokenServices;

        public UsersController(IConfiguration configuration, TokenServices tokenServices)
        {
            Configuration = configuration;
            TokenServices = tokenServices;
        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] UserInfo userInfo)
        {
            try
            {
                string jwtToken = TokenServices.GenerateToken(userInfo);
                return Ok(new { token = jwtToken });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
