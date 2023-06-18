using MVCProject.Models;
using MVCProject.Repository.RepresentiveRepo;

namespace MVCProject.Repository.RepresentativeRepo
{
    public class RepresentativeRepository : IRepresentativeRepository
    {
        private readonly AppDbContext _context;
        public RepresentativeRepository(AppDbContext context)
        {

            _context = context;

        }

        public void Add(Representative rep)
        {
            _context.Representatives.Add(rep);
        }

        public void Edit(Representative rep)
        {
            _context.Representatives.Entry(rep).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        
        public List<Representative> GetAll()
        {
            return _context.Representatives.ToList();
        }

        public Representative GetById(int id)
        {
            return _context.Representatives.Find(id);
        }

        public void Delete(int id)
        {
            Representative rep = GetById(id);
            rep.IsDeleted = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
