using Asp.Versioning;
using Backend.BLL.Features.Auth;
using Backend.BLL.Features.Users;
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
                    Title = "DentiCare API",
                    Version = "v1",
                    Description = "Endpoints for DentiCare web application"
                });
                //options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                //{
                //    Title = "DentiCare API",
                //    Version = "v2",
                //    Description = "Upgrade version"
                //});
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

            services.AddCors(options =>
            {
                options.AddPolicy("DentiCare", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // AutoMapper configuration
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Unit of work configuration
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories configuration
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Services configuration
            services.AddTransient<ITokenService, TokenService>();   // processing Jwt tokens
            services.AddScoped<IUserService, UserService>();

            services.AddHttpContextAccessor();
            return services;
        }
    }
}
