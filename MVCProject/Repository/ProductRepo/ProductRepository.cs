using MVCProject.Models;

namespace MVCProject.Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(int id)
        {
            Product product = GetById(id);
            product.IsDeleted = true;

        }

        public void Edit(Product product)
        {
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
