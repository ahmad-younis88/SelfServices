using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SelfServices.Common.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.API.Generic
{
    public class TokenServices
    {
        private IConfiguration Configuration;
        public TokenServices(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateToken(UserInfo userInfo)
        {
            string Token;
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:SecretKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                            new Claim("userName", userInfo.UserName),
                            new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                    Expires = DateTime.UtcNow.AddHours(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                string jwtToken = jwtTokenHandler.WriteToken(token);
                
                Token = jwtToken;
            }
            catch
            {
                Token = string.Empty;
            }

            return Token;
        }

        public bool ValidateToken(UserInfo userInfo)
        {
            bool isValid = false;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:SecretKey"]);
                tokenHandler.ValidateToken(userInfo.Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var _UserName = jwtToken.Claims.First(x => x.Type == "userName").Value;
                if (userInfo.UserName == _UserName)
                {
                    isValid = true;
                }
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
