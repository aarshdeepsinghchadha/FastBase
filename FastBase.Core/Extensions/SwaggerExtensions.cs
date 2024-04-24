using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using NSwag;
using NJsonSchema.Generation;

namespace FastBase.Core.Extensions
{
    /// <summary>
    /// Extensions for Swagger
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Add Swagger documentation to service collection
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="config">Configuration</param>
        /// <param name="applicationName">Application name</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration config, string applicationName)
        {
            if (!config.GetSection("Swagger:Enabled").Get<bool>()) return services;


            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            //var authority = config.GetValue<string>("");

            //var apiScope = config.GetValue<string>("");
            //var scopes = apiScope.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            //var additionalScopes = config.GetValue<string>("");
            //scopes.AddRange(additionalScopes.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList());

            //var oauthScopeDic = new Dictionary<string, string>();
            //foreach (var scope in scopes)
            //{
            //    oauthScopeDic.Add(scope, $"Scope access: {scope}");
            //}

            foreach (var description in provider.ApiVersionDescriptions)
            {
                services.AddOpenApiDocument(options =>
                {
                    options.Title = $"{applicationName} {description.ApiVersion}";
                    options.Version = description.ApiVersion.ToString();
                    options.DocumentName = description.GroupName;
                    options.ApiGroupNames = new[] { description.GroupName };

                    options.SchemaSettings.AllowReferencesWithProperties = true;
                    options.SchemaSettings.IgnoreObsoleteProperties = true;

                    options.AddSecurity("bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            //AuthorizationCode = new OpenApiOAuthFlow
                            //{
                            //    AuthorizationUrl = $"{authority}/connect/authorize",
                            //    TokenUrl = $"{authority}/connect/token",
                            //    Scopes = oauthScopeDic
                            //}
                        }
                    });
                });
            }

            return services;
        }

        /// <summary>
        /// Use Swagger documentation for the application
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="config">Configuration</param>
        /// <param name="provider">API description provider</param>
        /// <returns>Application builder</returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, IConfiguration config, IApiVersionDescriptionProvider provider)
        {
            if (!config.GetSection("Swagger:Enabled").Get<bool>()) return app;

            var clientId = config.GetValue<string>("");
            app
                .UseOpenApi(configure => configure.PostProcess = (document, _) => document.Schemes = new[] { OpenApiSchema.Https })
                .UseSwaggerUi(settings =>
                {
                    settings.DocExpansion = "list";
                    settings.OAuth2Client = new OAuth2ClientSettings
                    {
                        UsePkceWithAuthorizationCodeGrant = true,
                        ClientId = clientId
                    };
                });

            return app;
        }
    }
}
