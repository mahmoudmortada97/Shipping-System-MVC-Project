using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.Repository.AccountRepo;
using MVCProject.Repository.BranchRepo;
using MVCProject.Repository.EmployeeRepo;
using MVCProject.Repository.RepresentativeRepo;
using MVCProject.Repository.RepresentiveRepo;
using MVCProject.Repository.TraderRepo;

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
            builder.Services.AddScoped<ITraderRepository, TraderRepository>();
            builder.Services.AddScoped<IBranchRepository,BranchRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(
                        builder.Configuration.GetConnectionString("CS")));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}