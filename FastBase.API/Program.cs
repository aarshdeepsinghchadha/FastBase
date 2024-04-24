using FastBase.API.Extensions;
using FastBase.Domain.Admin;
using FastBase.SchemaBuilder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
//builder.Services.AddTransient<TokenManagerMiddleware>();
builder.Services.AddTransient<Seed>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddService(builder.Configuration);
builder.Services.AddAuthenticaionService(builder.Configuration);
builder.Services.AddMvcCoreWithAddOns(builder.Configuration);

// Add Swashbuckle's Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();
app.UseRouting();
app.UseDefaultFiles();
app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    //.WithOrigins("http://127.0.0.1:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DataContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
await context.Database.MigrateAsync();
await Seed.SeedData(context, userManager, roleManager);

app.UseSwagger();
// Enable Swagger UI
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.DocExpansion(DocExpansion.None);
});

app.Run();
