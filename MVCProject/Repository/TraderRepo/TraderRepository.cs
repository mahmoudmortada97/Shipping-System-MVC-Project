using MVCProject.Models;
using MVCProject.Repository.TraderRepo;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace MVCProject.Repository.TraderRepo
{
    public class TraderRepository : ITraderRepository
    {
        AppDbContext _context;

        public TraderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Trader> GetAll()
        {
            return _context.Traders.Where(e => e.IsDeleted == false).ToList(); //uncommented
        }


        public Trader GetById(int id)
        {

            return _context.Traders.FirstOrDefault(e => e.Id == id && e.IsDeleted == false)!;//uncommented

            //return traders.FirstOrDefault(t => t.Id == id && t.IsDeleted == true)!; //commented

        }

        public void Create(Trader trader) //changed from (Add --> Create) in all places 
        {
            _context.Traders.Add(trader); //uncommented

        }

        public void Edit(Trader trader)
        {

            //var traderFromDb = traders.FirstOrDefault(t => t.Id == trader.Id); //commented

            _context.Traders.Entry(trader).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //uncommented
            //var traderFromDb = traders.FirstOrDefault(t => t.Id == trader.Id);

            //traderFromDb.Name = trader.Name;
            //traderFromDb.Email = trader.Email;
            //traderFromDb.Password = trader.Password;
            //traderFromDb.IsDeleted = trader.IsDeleted;
            //traderFromDb.Phone = trader.Phone;
            //traderFromDb.Address = trader.Address;
            //traderFromDb.StoreName = trader.StoreName;
            //traderFromDb.SpecialPickupCost = trader.SpecialPickupCost;

            //traderFromDb.TraderTaxForRejectedOrders = trader.TraderTaxForRejectedOrders;  //commented


            //Id = 1,
            //        Name = "Ali",
            //        Email = "mohamed123@google.com",
            //        Password = "password1234",
            //        IsDeleted = false,
            //        Phone = 01554592044,
            //        Address = "Alex",
            //        StoreName = "CairoStore",
            //        SpecialPickupCost = 50,
            //        TraderToleranceForRejectedOrders = 100  // still commented as past

        }

        public void Delete(int id)
        {
            Trader trader = _context.Traders.Find(id)!; //uncommented
            trader.IsDeleted = true; //uncommented

            //var trader = traders.FirstOrDefault(t => t.Id == id); //commented
            //trader.IsDeleted = true;//commented
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
