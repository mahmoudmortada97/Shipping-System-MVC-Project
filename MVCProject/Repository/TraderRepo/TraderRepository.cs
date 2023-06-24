using MVCProject.Models;
using MVCProject.Repository.TraderRepo;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace MVCProject.Repository.TraderRepo
{
    public class TraderRepository : ITraderRepository
    {
        AppDbContext _context;

<<<<<<< HEAD
=======
        //public List<Trader> traders = new List<Trader>()
        //    {

        //    // Fake Database (For testing):
        //        new Trader()
        //        {
        //            Id = 1,
        //            Name = "Ali",
        //            Email = "mohamed123@google.com",
        //            Password = "password1234",
        //            IsDeleted = false,
        //            Phone= "01554592044",
        //            Address = "Alex",
        //            StoreName = "CairoStore",
        //            SpecialPickupCost = 50,
        //            TraderTaxForRejectedOrders =100

        //        },
        //         new Trader()
        //        {
        //            Id = 2,
        //            Name = "Amro",
        //            Email = "mohamed123456@google.com",
        //            Password = "password123454",
        //            IsDeleted = false,
        //            Phone= "01224592044",
        //            Address = "Giza",
        //            StoreName = "GizaStore",
        //            SpecialPickupCost = 50,
        //            TraderTaxForRejectedOrders =100
        //        }


        //    };

>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1
        public TraderRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Trader> GetAll()
        {
<<<<<<< HEAD
            return _context.Traders.Where(e => e.IsDeleted == false).ToList(); //uncommented
=======
            return _context.Traders.Where(e => e.IsDeleted == false).ToList();

            //return traders.Where(e => e.IsDeleted == false).ToList();

>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1
        }


        public Trader GetById(int id)
        {
<<<<<<< HEAD

            return _context.Traders.FirstOrDefault(e => e.Id == id && e.IsDeleted == false)!;//uncommented

            //return traders.FirstOrDefault(t => t.Id == id && t.IsDeleted == true)!; //commented

=======
            return _context.Traders.FirstOrDefault(e => e.Id == id && e.IsDeleted == true)!;
            //return traders.FirstOrDefault(t => t.Id == id && t.IsDeleted == true)!;
>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1
        }

        public void Create(Trader trader) //changed from (Add --> Create) in all places 
        {
<<<<<<< HEAD
            _context.Traders.Add(trader); //uncommented
=======
            _context.Traders.Add(trader);

            //traders.Add(trader);
>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1

        }

        public void Edit(Trader trader)
        {
<<<<<<< HEAD

            //var traderFromDb = traders.FirstOrDefault(t => t.Id == trader.Id); //commented

            _context.Traders.Entry(trader).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //uncommented
            //var traderFromDb = traders.FirstOrDefault(t => t.Id == trader.Id);

=======
            _context.Traders.Entry(trader).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //var traderFromDb = traders.FirstOrDefault(t => t.Id == trader.Id);

>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1
            //traderFromDb.Name = trader.Name;
            //traderFromDb.Email = trader.Email;
            //traderFromDb.Password = trader.Password;
            //traderFromDb.IsDeleted = trader.IsDeleted;
            //traderFromDb.Phone = trader.Phone;
            //traderFromDb.Address = trader.Address;
            //traderFromDb.StoreName = trader.StoreName;
            //traderFromDb.SpecialPickupCost = trader.SpecialPickupCost;
<<<<<<< HEAD

            //traderFromDb.TraderTaxForRejectedOrders = trader.TraderTaxForRejectedOrders;  //commented

=======
            //traderFromDb.TraderTaxForRejectedOrders = trader.TraderTaxForRejectedOrders;
>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1

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
<<<<<<< HEAD
            Trader trader = _context.Traders.Find(id)!; //uncommented
            trader.IsDeleted = true; //uncommented
=======
            Trader trader = _context.Traders.Find(id)!;
            trader.IsDeleted = true;
            //var trader = traders.FirstOrDefault(t => t.Id == id);
            //trader.IsDeleted = true;
>>>>>>> aaf6d917aed8a49390cb37fa016f1db0c536f0f1

            //var trader = traders.FirstOrDefault(t => t.Id == id); //commented
            //trader.IsDeleted = true;//commented
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
