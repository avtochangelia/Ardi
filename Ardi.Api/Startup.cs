using Ardi.Application.ProductManagement.Commands.CreateProduct;
using Ardi.Application.Shared.Behaviors;
using Ardi.Application.Shared.Middlewares;
using Ardi.Domain.PolicyHolderManagement.Repositories;
using Ardi.Domain.PolicyManagement.Repositories;
using Ardi.Domain.ProductManagement.Repositories;
using Ardi.Domain.Shared;
using Ardi.Infrastructure.DataAccess;
using Ardi.Infrastructure.Repositories.PolicyHolderManagement;
using Ardi.Infrastructure.Repositories.PolicyManagement;
using Ardi.Infrastructure.Repositories.ProductManagement;
using FluentValidation;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Ardi.Api;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<EFDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("Default")));

        services.AddScoped<IDbConnection>(provider => new SqlConnection(_configuration.GetConnectionString("Default")));

        services.AddScoped<DapperDbContext>();
        services.AddScoped<IPolicyHolderRepository, PolicyHolderRepository>();
        services.AddScoped<IPolicyRepository, PolicyRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddMediatR(new[]
        {
            typeof(CreateProduct).GetTypeInfo().Assembly,
        });

        services.AddValidatorsFromAssembly(typeof(CreateProductValidator).GetTypeInfo().Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.Run();
    }
}