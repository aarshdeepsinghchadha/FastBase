﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Core.Extensions
{
    /// <summary>
    /// Extensions for API versioning
    /// </summary>
    public static class VersionExtensions
    {
        /// <summary>
        /// Adds API versioning to the service collection
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
    }
}
