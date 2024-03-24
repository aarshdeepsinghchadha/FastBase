using AutoMapper;
using FastBase.Domain.Admin;
using Microsoft.AspNetCore.Identity;
using FastBase.Email.Extensions;

namespace FastBase.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpContextAccessor();

            //Setup Services
            services.AddScoped<UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();


            // Register AutoMapper and add the mapping profile
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new RegisterMappingConfiguration());
            //    // Add other profiles if needed
            //});


            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            //Setup External services
            services.AddEmailService();

            return services;
        }
    }
}
