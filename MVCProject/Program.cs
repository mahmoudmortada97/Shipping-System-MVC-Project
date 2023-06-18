using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.Repository.EmployeeRepo;
using MVCProject.Repository.RepresentativeRepo;
using MVCProject.Repository.RepresentiveRepo;

namespace MVCProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IRepresentativeRepository, RepresentativeRepository>();
            builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(
                        builder.Configuration.GetConnectionString("CS")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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