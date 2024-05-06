using Asp.Versioning;
using Backend.DAL;
using Backend.DAL.Databases;
using Backend.DAL.Repositories;
using Backend.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Version 1",
                    Version = "1",
                    Description = ""
                });
                // For upgrade, configure api version 2
            });

            // API versioning configuration
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version")
                );
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), 
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
            });

            // AutoMapper configuration
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Unit of work configuration
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories configuration
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Services configuration

            return services;
        }
    }
}
