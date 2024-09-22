using Application.External.GetTokenJwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace External.GetTokenJwt
{
    
    public class GetTokenJwtService: IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Execute (string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string key = _configuration["SecretKeyJwt"] ??string.Empty;
            var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,id)
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(signinkey,SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["IssuerJwt"],
                Audience = _configuration["AudienceJwt"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;

        }
    }
}
