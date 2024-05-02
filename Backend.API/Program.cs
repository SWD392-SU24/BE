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
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalHandlingExceptionMiddleware>(); 
            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
