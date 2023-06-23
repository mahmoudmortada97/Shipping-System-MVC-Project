using MVCProject.Models;

namespace MVCProject.Repository.CityRepo
{
    public class CityRepository: ICityRepository    /* add by salah && Rizk*/
    {
        AppDbContext _context;
        public CityRepository(AppDbContext context)
        {
            _context = context;

        }

        public void Add(City city)
        {
            _context.Cities.Add(city);
        }

        public void Delete(int id)
        {
            City City = GetById(id);
            _context.Cities.Remove(City);

        }

        public List<City> GetAllCitiesByGovId(int id)
        {
            return _context.Cities.Where(c => c.GoverId == id).ToList();
        }

        public void Edit(City city)
        {
            _context.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public City GetById(int id)
        {
            return _context.Cities.Find( id );
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        
    }

}
