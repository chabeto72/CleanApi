using Application.Database.User.Commands.CreateUser;
using Application.External.GetTokenJwt;
using Application.External.SendGridEmail;
using External.GetTokenJwt;
using External.SendGridEmail;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection addExternal(this IServiceCollection services, IConfiguration configuration)
        {
            //inyeccion de dependencias Commands           
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            services.AddSingleton<IGetTokenJwtService,GetTokenJwtService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt"])),
                    ValidIssuer = configuration["IssuerJwt"],
                    ValidAudience = configuration["AudienceJwt"]
                };
            });
            return services;
        }
    }
}
