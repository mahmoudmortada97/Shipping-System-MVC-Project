using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.Repository.TraderRepo;

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
            return _context.Traders.Where(t => t.IsDeleted == false)
                .Include(t => t.Governorate)
                .Include(t =>t.City)
                .Include(t =>t.Branch).ToList();
        }

        public Trader GetById(int id, bool includeRelatedEntities = true)
        {
            if (includeRelatedEntities)
            {
                return _context.Traders
                    .Include(t => t.Branch)
                    .Include(t => t.Governorate)
                    .Include(t => t.City)
                    .FirstOrDefault(t => t.Id == id)!;
            }
            return _context.Traders.FirstOrDefault(t => t.Id == id && t.IsDeleted == false)!;
        }

        public void Create(Trader trader) 
        {
            _context.Traders.Add(trader); 
        }

        public void Edit(Trader trader)
        {
            _context.Traders.Entry(trader).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Trader trader = _context.Traders.Find(id);
            _context.Traders.Remove(trader);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Trader> GetAllTradersByBranchId(int id)
        {
            return _context.Traders.Where(c => c.BranchId == id).ToList();
        }
    }
}