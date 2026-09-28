using Kindergarten.Data;
using Microsoft.EntityFrameworkCore;
using Kindergarten.ApplicationServices.Services;
using Kindergarten.Core.ServiceInterface;

namespace KindergartenCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();

            builder.Services.AddDbContext<KindergartenContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("KindergartenDB")));

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