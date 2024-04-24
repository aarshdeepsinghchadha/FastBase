using FastBase.Shared.Interface;
using FastBase.Shared.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Shared.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddResponseGeneratorService(this IServiceCollection services)
        {
            services.AddScoped<IResponseGeneratorService, ResponseGeneratorService>();
        }
    }
}
