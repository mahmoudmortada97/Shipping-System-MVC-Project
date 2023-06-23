using MVCProject.Models;

namespace MVCProject.Repository.GovernorateRepo
{
    public interface IGovernRepository     /* add by salah && Rizk*/
    {
        List<Government> GetAll();
        Government GetById(int id);
        void Add(Government governorate);
        void Edit(Government governorate);
        void Delete(int id);
        void Save();
    }
}
