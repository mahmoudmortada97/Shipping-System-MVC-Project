using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MVCProject.Models.Trader> Trader { get; set; } = default!;
    }
}
