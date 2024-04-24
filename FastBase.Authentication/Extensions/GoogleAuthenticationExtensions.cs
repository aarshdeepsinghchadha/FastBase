using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Extensions
{
    public static class GoogleAuthenticationExtensions
    {
        public static void AddGoogleAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var googleOptions = configuration.GetSection("Google");
            var clientId = googleOptions["ClientId"];
            var clientSecret = googleOptions["ClientSecret"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddGoogle(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
            });
        }
    }
}
