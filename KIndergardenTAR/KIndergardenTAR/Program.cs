using Kindergarden.Data;
using Microsoft.EntityFrameworkCore;
using Kindergarden.ApplicationServices.Services;
using Kindergarden.Core.ServiceInterface;

namespace KindergardenTAR
{
    public class Program
    {

        [STAThread]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IKindergardenServices, KindergardenServices>();

            builder.Services.AddDbContext<KindergardenContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("KindergardenDB")));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
