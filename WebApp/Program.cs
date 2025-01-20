using WebApp.Models;
using WebApp.Models.Movies;
using WebApp.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();

 
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite("Data Source=c:\\data\\contacts.db");
            });

    
            builder.Services.AddDbContext<MoviesContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("MoviesDatabase"));
            });

           
            builder.Services.AddTransient<IContactService, EFContactService>();

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}