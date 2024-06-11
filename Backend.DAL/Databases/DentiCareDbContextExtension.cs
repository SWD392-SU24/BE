using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.DAL.Databases
{
    public static class DentiCareDbContextExtension
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DenticareContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
            });

            return services;
        }
    }
}
