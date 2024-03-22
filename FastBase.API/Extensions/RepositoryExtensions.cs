using FastBase.SchemaBuilder;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace FastBase.API.Extensions
{
    public static class RepositoryExtensions
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            var enableDataLogging = config.GetValue<bool>("Logging:EnableEFCoreLogging");
            var dataContextBuilder = new DbContextOptionsBuilder<DataContext>();

            #region postgres
            services
                .AddScoped<IDbConnection>(p => new NpgsqlConnection(config.GetConnectionString("FastBaseDb")));
            #endregion

            #region postgres
            var dataContextOptions = dataContextBuilder
                .UseNpgsql(config.GetConnectionString("FastBaseDb"), providerOptions => providerOptions.EnableRetryOnFailure())
                .EnableSensitiveDataLogging(enableDataLogging)
                .Options;
            #endregion

            #region sql
            //var dataContextOptions = dataContextBuilder
            //  .UseSqlServer(config.GetConnectionString("FastBaseSQLDb"), providerOptions => providerOptions.EnableRetryOnFailure())
            //  .EnableSensitiveDataLogging(enableDataLogging)
            //  .Options;
            #endregion

            var dataContextNoRetryBuilder = new DbContextOptionsBuilder<DataContext>();

            #region postgres
            var rentReminderNoRetryOptions = dataContextNoRetryBuilder
                .UseNpgsql(config.GetConnectionString("FastBaseDb"))
                .EnableSensitiveDataLogging(enableDataLogging)
                .Options;
            #endregion

            #region sql
            //var dataContextNoRetryOptions = dataContextNoRetryBuilder
            //                .UseSqlServer(config.GetConnectionString("FastBaseSQLDb"))
            //                .EnableSensitiveDataLogging(enableDataLogging)
            //                .Options;
            #endregion

            // Setup repositories 
            services.AddScoped<DataContext>(_ => new DataContext(dataContextOptions));


            return services;
        }
    }
}
