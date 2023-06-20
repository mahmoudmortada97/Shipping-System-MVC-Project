using MVCProject.Models;

namespace MVCProject.Repository.DiscountTypeRepo
{
    public interface IDiscountTypeRepository    /* add by salah && Rizk*/
    {
        List<DiscountType> GetAll();
        DiscountType GetById(int id);
        void Add(DiscountType discount);
        void Edit(DiscountType discount);
        void Delete(int id);
        void Save();
    }
}
