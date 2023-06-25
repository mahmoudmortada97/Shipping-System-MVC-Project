using MVCProject.Models;

namespace MVCProject.Repository.OrderStateRepo
{
    public class OrderStateRepository : IOrderStateRepository
    {
        AppDbContext _context;

        public OrderStateRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<OrderState> GetAll()
        {
            return _context.OrderStates.ToList();
        }
    }
}
