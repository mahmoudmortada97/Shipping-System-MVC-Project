using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.ViewModel;
using System.Reflection.Emit;

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

        public DbSet<WeightSetting> WeightSetting { get; set; }
        public DbSet<DeliverType> DeliverTypes { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<TraderSpecialPriceForCities>TraderSpecialPriceForCities { get; set; }



        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<MVCProject.ViewModel.OrderReporttWithOrderByStatusDateViewModel> OrderReporttWithOrderByStatusDateViewModel { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(m => m.creationDate).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Branch>().Property(m => m.CreationDate).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Order>().Property(m => m.creationDate).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Representative>().Property(m => m.creationDate).HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Trader>().Property(m => m.creationDate).HasDefaultValueSql("GetDate()");


            modelBuilder.Entity<Branch>().Property(m => m.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Employee>().Property(m => m.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Order>().Property(m => m.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Product>().Property(m => m.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Representative>().Property(m => m.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Trader>().Property(m => m.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<TraderSpecialPriceForCities>().Property(m => m.IsDeleted).HasDefaultValue(false);



            modelBuilder.Entity<Governorate>().HasData(new Governorate { Id=10 , Name="Matrooh",});

            modelBuilder.Entity<DeliverType>().HasData(new DeliverType { Id=1,Type="Normal",Price=0 });
            modelBuilder.Entity<DeliverType>().HasData(new DeliverType { Id=2,Type="2 Days",Price=30 });
            modelBuilder.Entity<DeliverType>().HasData(new DeliverType { Id=3,Type="24 Hours",Price=50 });


            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 1, Name="New" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 2, Name="Waiting" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 3, Name= "Delivered to the representative" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 4, Name= "Delivered to the client" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 5, Name="Cannot reach" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 6, Name= "Postponed" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 7, Name= "Partially delivered" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 8, Name= "Canceled by the client" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 9, Name= "Declined but Paid" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 10, Name= "Declined but Partially Paid" });
            modelBuilder.Entity<OrderState>().HasData(new OrderState { Id = 11, Name= "Declined without Payment" });



            modelBuilder.Entity<OrderType>().HasData(new OrderType { Id = 1, Name= "From Branch" });
            modelBuilder.Entity<OrderType>().HasData(new OrderType { Id = 2, Name= "From Trader" });

            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod { Id = 1, Name = "Cash" });
            modelBuilder.Entity<PaymentMethod>().HasData(new PaymentMethod { Id = 2, Name = "Visa" });

            modelBuilder.Entity<WeightSetting>().HasData(new WeightSetting { Id = 1, DefaultSize=10,PriceForEachExtraKilo=100 });





        }
    }
}
