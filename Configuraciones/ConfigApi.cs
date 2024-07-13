using HttpCall;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Base;
using Repository.Models;

namespace Configuraciones
{
    public class ConfigApi
    {

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<AppDbContext>(
                    (DbContextOptionsBuilder options) =>
                    {
                        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                    });

            // Repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            // Llamadas Http
            builder.Services.AddHttpClient<IApiAuthService, ApiAuthService>(service =>
            {
                service.BaseAddress = new Uri("https://localhost:7213/api/Domain/");
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void ConfigureApp(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    }
}
