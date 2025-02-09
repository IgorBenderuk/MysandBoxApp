using MySandboxApp.Dal;
using MySandboxApp.Dal.Options;
using MySandBoxApp.Core.Interfaces;
using TeaMarketPlace.EmailService.Services;

namespace MySandBoxApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.Configure<DbOptions>(configuration.GetSection("ConnectionStrings"));

            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddControllersWithViews(); // Додає підтримку MVC
            builder.Services.AddRazorPages();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ISendingMailService, SendingMailService>();
            builder.Services.AddScoped<BirthdayNotificationService>();

            builder.Services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();

            var app = builder.Build();

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
