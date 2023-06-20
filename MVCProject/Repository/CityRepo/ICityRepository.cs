using MVCProject.Models;

namespace MVCProject.Repository.CityRepo
{
    public interface ICityRepository    /* add by salah && Rizk*/
    {
        List<City> GetAll();
        City GetById(int id);
        void Add(City city);
        void Edit(City city);
        void Delete(int id);
        void Save();
    }
}
