using MVCProject.Models;
using MVCProject.Repository.TraderRepo;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace MVCProject.Repository.TraderRepo
{
    public class TraderRepository : ITraderRepository
    {
        AppDbContext _context;

        public List<Trader> traders = new List<Trader>()
            {

            // Fake Database (For testing):
                new Trader()
                {
                    Id = 1,
                    Name = "Ali",
                    Email = "mohamed123@google.com",
                    Password = "password1234",
                    IsDeleted = false,
                    Phone= "01554592044",
                    Address = "Alex",
                    StoreName = "CairoStore",
                    SpecialPickupCost = 50,
                    TraderTaxForRejectedOrders =100

                },
                 new Trader()
                {
                    Id = 2,
                    Name = "Amro",
                    Email = "mohamed123456@google.com",
                    Password = "password123454",
                    IsDeleted = false,
                    Phone= "01224592044",
                    Address = "Giza",
                    StoreName = "GizaStore",
                    SpecialPickupCost = 50,
                    TraderTaxForRejectedOrders =100
                }


            };

        public TraderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Trader> GetAll()
        {
            //return _context.Traders.Where(e => e.IsDeleted == false).ToList();

            return traders.Where(e => e.IsDeleted == false).ToList();

        }


        public Trader GetById(int id)
        {
            //return _context.Traders.FirstOrDefault(e => e.Id == id && e.IsDeleted == true)!;
            return traders.FirstOrDefault(t => t.Id == id && t.IsDeleted == true)!;
        }

        public void Add(Trader trader)
        {
            //_context.Traders.Add(trader);

            traders.Add(trader);

        }

        public void Edit(Trader trader)
        {
            //_context.Traders.Entry(trader).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var traderFromDb = traders.FirstOrDefault(t => t.Id == trader.Id);

            traderFromDb.Name = trader.Name;
            traderFromDb.Email = trader.Email;
            traderFromDb.Password = trader.Password;
            traderFromDb.IsDeleted = trader.IsDeleted;
            traderFromDb.Phone = trader.Phone;
            traderFromDb.Address = trader.Address;
            traderFromDb.StoreName = trader.StoreName;
            traderFromDb.SpecialPickupCost = trader.SpecialPickupCost;
            traderFromDb.TraderTaxForRejectedOrders = trader.TraderTaxForRejectedOrders;

            //Id = 1,
            //        Name = "Ali",
            //        Email = "mohamed123@google.com",
            //        Password = "password1234",
            //        IsDeleted = false,
            //        Phone = 01554592044,
            //        Address = "Alex",
            //        StoreName = "CairoStore",
            //        SpecialPickupCost = 50,
            //        TraderToleranceForRejectedOrders = 100

        }

        public void Delete(int id)
        {
            //Trader trader = _context.Traders.Find(id)!;
            //trader.IsDeleted = true;
            var trader = traders.FirstOrDefault(t => t.Id == id);
            trader.IsDeleted = true;

        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
