using MVCProject.Models;

namespace MVCProject.Repository.GovernorateRepo
{
    public interface IGovernRepository     /* add by salah && Rizk*/
    {
        List<Governorate> GetAll();
        Governorate GetById(int id);
        void Add(Governorate governorate);
        void Edit(Governorate governorate);
        void Delete(int id);
        void Save();
    }
}
