using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Skinet.API.Extension;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();

var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception e)
{
    logger.LogError(e, "An error occurred during migration");
}


app.Run();


    

