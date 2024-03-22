using FastBase.SchemaBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

try
{
    var hostConfiguration = HostConfiguration.Build(args);
    ILogger<Program> logger = hostConfiguration.LoggerFactory.CreateLogger<Program>();

    string connectionString = hostConfiguration.Configuration.GetConnectionString("FastBaseDB") ?? throw new ArgumentNullException(nameof(connectionString));
    string environment = hostConfiguration.Configuration.GetValue<string>("Environment");

    logger.LogInformation("Environment: {Environment}", environment);

    DataContextFactory factory = new DataContextFactory();
    DataContext dbContext = factory.CreateDbContext(args);

    if (dbContext.Database.CanConnect())
    {
        var availableMigrations = dbContext.Database.GetMigrations();
        foreach (var migration in availableMigrations)
        {
            logger.LogInformation("Available migration: {Migration}", migration);
        }

        var appliedMigrations = dbContext.Database.GetAppliedMigrations();
        foreach (var migration in appliedMigrations)
        {
            logger.LogInformation("Previously applied migration: {Migration}", migration);
        }

        //await ApplyPreSqlScriptsAsync(logger, connectionString, environment);
    }
    else
    {
        logger.LogInformation("Unable to connect to database.");
    }
    dbContext.Database.Migrate();

    //await ApplyPostSqlScriptsAsync(logger, connectionString, environment);

    Thread.Sleep(500); // Sleep to let the logger flush
}
catch (Exception e)
{
    Console.WriteLine($"Error during migration: {e.Message}");
    throw;
}