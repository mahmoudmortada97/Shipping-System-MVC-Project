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

            return _context.Traders.Where(e => e.IsDeleted == false).ToList();

            
        }


        public Trader GetById(int id)
        {

            return _context.Traders.FirstOrDefault(e => e.Id == id && e.IsDeleted == false)!;//uncommented
            return _context.Traders.FirstOrDefault(e => e.Id == id && e.IsDeleted == true)!;
        
        }

        public void Create(Trader trader) //changed from (Add --> Create) in all places 
        {

            _context.Traders.Add(trader);        
        }

        public void Edit(Trader trader)
        {

            _context.Traders.Entry(trader).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //uncommented
        }

        public void Delete(int id)
        {

            Trader trader = _context.Traders.Find(id)!; //uncommented
            trader.IsDeleted = true; //uncommented

           
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
