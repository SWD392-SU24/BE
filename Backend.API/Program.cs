using Backend.API.Extensions;
using Backend.API.Middlewares;

namespace Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Register(builder.Configuration);
            
            builder.Services.AddTransient<GlobalHandlingExceptionMiddleware>();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "DentiCare v1");
                    //options.SwaggerEndpoint("/swagger/v2/swagger.json", "DentiCare v2");
                });
            }

            app.UseMiddleware<GlobalHandlingExceptionMiddleware>();
            // Use CORS
            app.UseCors("DentiCare");
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
