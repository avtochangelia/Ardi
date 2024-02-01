using Ardi.Application.Shared.Behaviors;
using Ardi.Application.Shared.Configurations.Validators;
using Ardi.Application.Shared.Configurations;
using Ardi.Application.Shared.Exceptions;
using Ardi.Application.Shared.Options;
using Ardi.Domain.Shared;
using Ardi.Infrastructure.DataAccess;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ardi.DI;

public class DependencyResolver(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public IServiceCollection Resolve(IServiceCollection services)
    {
        services ??= new ServiceCollection();

        var appsettings = new AppSettings();
        Configuration.Bind(appsettings);
        ValidateConfiguration(appsettings);

        services.AddDbContext<EFDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Default")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.Configure<TypicodeConfig>(Configuration.GetSection("TypicodeConfig"));

        //services.AddMediatR(new[]
        //{
        //    typeof(CreateUser).GetTypeInfo().Assembly,
        //});

        services.AddValidatorsFromAssembly(typeof(AppSettingsValidator).GetTypeInfo().Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        ConfgiureJwt(services, Configuration);

        return services;
    }

    public static void ConfgiureJwt(IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(JwtOptions.ConfigSection).Get<JwtOptions>();

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.Audience = jwtOptions!.ValidAudience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.ValidIssuer,
                ValidAudiences = jwtOptions.ValidAudiences,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
            };
        });
    }

    internal static void ValidateConfiguration(AppSettings appSettings)
    {
        var validator = new AppSettingsValidator();
        var validationResult = validator.Validate(appSettings);
        if (!validationResult.IsValid)
        {
            throw new MissingAppsettingsException(validationResult.Errors.Select(error => error.ErrorMessage).ToArray());
        }
    }
}