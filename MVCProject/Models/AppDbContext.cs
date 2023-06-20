using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Governorate> governorates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DiscountType> DiscountTypes { get; set; }
        public DbSet<Trader> Traders { get; set; }
        public DbSet<TraderSpecialPriceForCities>traderSpecialPriceForCities { get; set; }

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MVCProject.Models.Trader> Trader { get; set; } = default!;
    }
}
