using Asp.Versioning;
using Backend.BLL.Features.Areas;
using Backend.BLL.Features.Auth;
using Backend.BLL.Features.Certificates;
using Backend.BLL.Features.Clinics;
using Backend.BLL.Features.Dentists;
using Backend.BLL.Features.Users;
using Backend.DAL;
using Backend.DAL.Databases;
using Backend.DAL.Repositories;
using Backend.DAL.Repositories.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.JsonSerializerOptions.WriteIndented = true;
                // Handling circular reference
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
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

            // Register database
            services.RegisterDbContext(configuration);

            // Configure CORS
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
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDentistRepository, DentistRepository>();
                        
            // Services configuration
            services.AddTransient<ITokenService, TokenService>();   // processing Jwt tokens
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IDentistService, DentistService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
