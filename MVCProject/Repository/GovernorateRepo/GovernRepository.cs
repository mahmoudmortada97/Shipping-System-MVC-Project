using MVCProject.Models;

namespace MVCProject.Repository.GovernorateRepo
{    
    public class GovernRepository: IGovernRepository          /* add by salah && Rizk*/
    {
        AppDbContext _context;
        public GovernRepository(AppDbContext context)
        {
            _context = context;

        }

        public void Add(Government government)
        {
            _context.governorates.Add(government);
        }

        public void Delete(int id)
        {
            Government governorate = GetById(id);
            _context.governorates.Remove(governorate);

        }

        public void Edit(Government governorate)
        {
            _context.Entry(governorate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Government> GetAll()
        {
            return _context.governorates.ToList();
        }

        public Government GetById(int id)
        {
            return _context.governorates.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
