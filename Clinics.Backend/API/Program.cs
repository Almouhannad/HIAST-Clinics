using API.Options.Database;
using Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Context;
using Persistence.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

#region Add Database context
// First, get database options
builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

builder.Services.AddDbContext<ClinicsDbContext>(
    (serviceProvider, dbContectOptionsBuilder) =>
    {
        // Now, get options just like any other service
        var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

        dbContectOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
        {
            sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

            sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
        });

        // Be careful with this option, true only in development process!

        dbContectOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
    });
#endregion

// Add services to the container.

#region Link repositories
// AddTransient: Created on demand, every time they are requested, not shared across requests or components.
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repositroy<>));
#endregion

#region Link controllers with presentation layer
var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;
builder.Services.AddControllers()
    .AddApplicationPart(presentationAssembly);
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
