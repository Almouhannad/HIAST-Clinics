using API.Options.Database;
using API.SeedDatabaseHelper;
using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Context;

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

#region Link interfaces implemented in persistence
// Using Scrutor library
builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(Persistence.AssemblyReference.Assembly
            // Add other assemblies here
            )
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );
#endregion

#region Add MadiatR
builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

#region Add validation pipeline
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
builder.Services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly);
#endregion

#endregion

#region Link controllers with presentation layer
builder.Services.AddControllers()
    .AddApplicationPart(Presentation.AssemblyReference.Assembly);
#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region Seed database
await SeedHelper.Seed(app);
#endregion

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
