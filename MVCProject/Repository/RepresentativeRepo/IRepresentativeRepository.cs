using MVCProject.Models;

namespace MVCProject.Repository.RepresentiveRepo
{
    public interface IRepresentativeRepository
    {
        List<Representative> GetAll();
        Representative GetById(int id);
        void Add(Representative rep);
        void Edit(Representative rep);
        void Delete(int id);
        void Save();
    }
}
