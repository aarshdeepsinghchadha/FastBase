using FastBase.Authentication.Interface;
using FastBase.Authentication.Repository;
using FastBase.Authentication.Service;
using FastBase.Email.Interface;
using FastBase.Email.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddAuthService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        }
    }
}
