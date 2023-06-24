using MVCProject.Models;

namespace MVCProject.Repository.OrderTypeRepo
{
    public class OrderTypeRepository : IOrderTypeRepository
    {
        AppDbContext _context;

        public OrderTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<OrderType> GetAll()
        {
            return _context.OrderTypes.ToList();
        }
    }
}
