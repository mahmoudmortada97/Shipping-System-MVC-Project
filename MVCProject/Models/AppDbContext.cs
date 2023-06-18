using Microsoft.EntityFrameworkCore;

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
    }
}
