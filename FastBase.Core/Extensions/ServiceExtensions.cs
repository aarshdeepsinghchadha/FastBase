using FastBase.Core.Interface;
using FastBase.Core.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Core.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddTokenService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITokenManager, TokenManager>();
        }
    }
}
