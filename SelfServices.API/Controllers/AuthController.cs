﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelfServices.Common.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SelfServices.API.GenericServices;

namespace SelfServices.API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration Configuration;
        private TokenServices TokenServices;
        public AuthController(IConfiguration configuration, TokenServices tokenServices)
        {
            this.Configuration = configuration;
            this.TokenServices = tokenServices;
        }


        [HttpPost]
        [Route("generate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GenerateToken([FromBody] UserInfo userInfo)
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

        [HttpPost]
        [Route("validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ValidateToken([FromBody] UserInfo userInfo)
        {
            try
            {
                if (Request.Headers.Keys.Contains("Authorization"))
                {
                    userInfo.Token = Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                }

                bool IsValidTokenByUser = TokenServices.ValidateToken(userInfo);
                return Ok(new { isValid = IsValidTokenByUser.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost]
        [Route("refershToken")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RefershToken([FromBody] UserInfo userInfo)
        {
            try
            {
                string NewToken = "";

                // check if token is expire or not
                if (!Request.Headers.Keys.Contains("Authorization"))
                {
                    return BadRequest(new { message = "old Token not exists" });
                }

                userInfo.Token = Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();

                bool IsValidTokenByUser = TokenServices.ValidateToken(userInfo);
                if (!IsValidTokenByUser)
                {
                    NewToken = TokenServices.GenerateToken(userInfo);
                    userInfo.Token = NewToken;
                    return Ok(new { isSuccess = true, Message = "success", data = userInfo });
                }

                return BadRequest(new { isSuccess = false, Message = "not_expire" });

            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
