using API.Options.Database;
using API.Options.JWT;
using API.SeedDatabaseHelper;
using Application.Behaviors;
using FluentValidation;
using Infrastructure;
using Infrastructure.NotificationsHubs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

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
            //sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

            //sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
        });

        // Be careful with this option, true only in development process!

        dbContectOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
    });
#endregion

#region Add SignalR
builder.Services.AddSignalR();
#endregion

#region Add CORS
builder.Services.AddCors();
#endregion

#region Link interfaces implemented in infrastructre
// Using Scrutor library
builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(Persistence.AssemblyReference.Assembly,
            Infrastructure.AssemblyReference.Assembly
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

#region Swagger with JWT authorization
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

#endregion

#region Authentication options
builder.Services.ConfigureOptions<JWTOptionsSetup>();
builder.Services.ConfigureOptions<JWTBearerOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
#endregion

var app = builder.Build();

#region Seed database
await SeedHelper.Seed(app);
await SeedAdminUserHelper.Seed(app);
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Map notification HUB
app.MapHub<DoctorsNotificationsHub>("api/Notifications/Doctors");
app.MapHub<ReceptionistsNotificationsHub>("api/Notifications/Receptionists");
#endregion

#region CORS
// TODO: Configure allows
app.UseCors(policy =>
    policy
        .AllowAnyHeader().AllowAnyMethod().AllowAnyHeader()
        .AllowCredentials().SetIsOriginAllowed(origin => true));

#endregion



app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
