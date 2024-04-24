using FastBase.Email.Interface;
using FastBase.Email.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FastBase.Email.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddEmailService(this IServiceCollection services)
        {
            services.AddScoped<IEmailSenderService, EmailSenderService>();
        }
    }
}
    