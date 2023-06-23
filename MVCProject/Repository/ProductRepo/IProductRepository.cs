using MVCProject.Models;

namespace MVCProject.Repository.ProductRepo
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Edit(Product pProduct);
        void Delete(int id);
        void Save();
    }
}
