using MVCProject.Models;

namespace MVCProject.Repository.GovernorateRepo
{
    public interface IGovernRepository     /* add by salah && Rizk*/
    {
        List<Governorate> GetAll();
        Governorate GetById(int id);
        void Add(Governorate governmate);
        void Edit(Governorate governmate);
        void Delete(int id);
        void Save();
    }
}
