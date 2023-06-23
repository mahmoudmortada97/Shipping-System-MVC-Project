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

        public void Add(Governorate government)
        {
            _context.governorates.Add(government);
        }

        public void Delete(int id)
        {
            Governorate governorate = GetById(id);
            _context.governorates.Remove(governorate);

        }

        public void Edit(Governorate governorate)
        {
            _context.Entry(governorate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Governorate> GetAll()
        {
            return _context.governorates.ToList();
        }

        public Governorate GetById(int id)
        {
            return _context.governorates.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
