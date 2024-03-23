using System.Text.Json.Serialization;
using FastBase.Shared.Extensions;

namespace FastBase.API.Extensions
{
    /// <summary>
    /// Extensions for Web API
    /// </summary>
    public static class WebApiExtensions
    {
        /// <summary>
        /// Add MVC Core with other add-ons to the service collection
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="config">Configuration</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddMvcCoreWithAddOns(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddMvcCore(options =>
                {
                })
                // Convert enums to strings and ignore null values
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                })
                .AddCors()
                .AddApiExplorer();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("LoginNamePolicy", policy => policy.AddRequirements(new LoginNameRequirement()));
            //});

            // Allows for more complex authorization requirements
            //services.AddRoleAuthorizationProviders();
            //services.AddLoginNameAuthorizationProviders();
            //services.AddOneSiteAuthorizationProviders();
            services.AddResponseGeneratorService();
            return services;
        }
    }

}
